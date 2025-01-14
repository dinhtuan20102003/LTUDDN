using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<char, int> dic1 = new Dictionary<char, int>();
    static Dictionary<int, char> dic2 = new Dictionary<int, char>();

    static void KhoiTaoDanhSach()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for (int i = 0; i < chars.Length; i++)
        {
            dic1[chars[i]] = i;
            dic2[i] = chars[i];
        }
    }

    static int TinhDinhThuc(int[,] matrix, int Z)
    {
        int n = matrix.GetLength(0);
        if (n == 2)
        {
            int det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            det %= Z;
            return det < 0 ? det + Z : det;
        }

        int result = 0;
        for (int j = 0; j < n; j++)
        {
            int[,] subMatrix = new int[n - 1, n - 1];
            for (int i = 1; i < n; i++)
            {
                for (int k = 0, col = 0; k < n; k++)
                {
                    if (k == j) continue;
                    subMatrix[i - 1, col++] = matrix[i, k];
                }
            }
            result += matrix[0, j] * (int)Math.Pow(-1, j) * TinhDinhThuc(subMatrix, Z);
        }
        result %= Z;
        return result < 0 ? result + Z : result;
    }

    static int UCLN(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static bool KiemTraNghichDao(int[,] matrix, int Z)
    {
        int det = TinhDinhThuc(matrix, Z);
        return UCLN(Z, det) == 1;
    }

    static int TinhNghichDao(int m, int b)
    {
        int a1 = 1, a2 = 0, a3 = m;
        int b1 = 0, b2 = 1, b3 = b;
        while (b3 != 0 && b3 != 1)
        {
            int q = a3 / b3;
            int t1 = a1 - q * b1;
            int t2 = a2 - q * b2;
            int t3 = a3 - q * b3;
            a1 = b1; a2 = b2; a3 = b3;
            b1 = t1; b2 = t2; b3 = t3;
        }
        return b3 == 1 ? (b2 + m) % m : 0;
    }

    static int[,] TinhMaTranPhuHop(int[,] matrix, int Z)
    {
        int n = matrix.GetLength(0);
        int[,] adj = new int[n, n];
        int det = TinhDinhThuc(matrix, Z);
        int inverseDet = TinhNghichDao(Z, det);

        if (n == 2)
        {
            adj[0, 0] = matrix[1, 1] * inverseDet % Z;
            adj[0, 1] = (Z - matrix[0, 1]) * inverseDet % Z;
            adj[1, 0] = (Z - matrix[1, 0]) * inverseDet % Z;
            adj[1, 1] = matrix[0, 0] * inverseDet % Z;
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int[,] subMatrix = new int[n - 1, n - 1];
                    for (int x = 0, xi = 0; x < n; x++)
                    {
                        if (x == i) continue;
                        for (int y = 0, yj = 0; y < n; y++)
                        {
                            if (y == j) continue;
                            subMatrix[xi, yj++] = matrix[x, y];
                        }
                        xi++;
                    }
                    adj[j, i] = (int)Math.Pow(-1, i + j) * TinhDinhThuc(subMatrix, Z) * inverseDet % Z;
                    if (adj[j, i] < 0) adj[j, i] += Z;
                }
            }
        }
        return adj;
    }

    static List<int> ChuyenTextSangVector(string text)
    {
        var vec = new List<int>();
        foreach (char ch in text)
        {
            vec.Add(dic1[ch]);
        }
        return vec;
    }

    static string ChuyenVectorSangText(List<int> vec)
    {
        var text = "";
        foreach (int num in vec)
        {
            text += dic2[num];
        }
        return text;
    }

    static string MaHoa(string nhap, int[,] key)
    {
        int n = key.GetLength(0);
        var inputVec = ChuyenTextSangVector(nhap);

        int padding = (n - inputVec.Count % n) % n;
        for (int i = 0; i < padding; i++)
        {
            inputVec.Add(dic1['X']);  
        }

        var kqVec = new List<int>(new int[inputVec.Count]);
        for (int i = 0; i < inputVec.Count; i += n)
        {
            for (int j = 0; j < n; j++)
            {
                kqVec[i + j] = 0;
                for (int k = 0; k < n; k++)
                {
                    kqVec[i + j] += key[j, k] * inputVec[i + k];
                    kqVec[i + j] %= 26;
                }
            }
        }

        string encryptedText = ChuyenVectorSangText(kqVec);
        encryptedText = encryptedText.Substring(0, encryptedText.Length - padding);

        return encryptedText;
    }



    static string GiaiMa(string nhap, int[,] invKey, int originalLength)
    {
        int n = invKey.GetLength(0);
        var inputVec = ChuyenTextSangVector(nhap);

        int padding = (n - inputVec.Count % n) % n;
        for (int i = 0; i < padding; i++)
        {
            inputVec.Add(dic1['X']);  
        }

        var kqVec = new List<int>(new int[inputVec.Count]);

        for (int i = 0; i < inputVec.Count; i += invKey.GetLength(0))
        {
            for (int j = 0; j < invKey.GetLength(0); j++)
            {
                kqVec[i + j] = 0;
                for (int k = 0; k < invKey.GetLength(0); k++)
                {
                    kqVec[i + j] += invKey[j, k] * inputVec[i + k];
                    kqVec[i + j] %= 26;
                }
            }
        }

        string decryptedText = ChuyenVectorSangText(kqVec);
        decryptedText = decryptedText.Substring(0, originalLength);

        return decryptedText;
    }



    static void Main()
    {
        KhoiTaoDanhSach();
        while (true)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Chuong trinh ma hoa va giai ma theo Thuat toan Hill");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Chon chuc nang:");
            Console.WriteLine("1. Ma hoa");
            Console.WriteLine("2. Giai ma");
            Console.WriteLine("3. Thoat");
            Console.Write("Nhap lua chon cua ban: ");
            int chon = int.Parse(Console.ReadLine());

            if (chon == 3)
            {
                Console.WriteLine("Cam on ban da su dung chuong trinh!");
                break;
            }

            Console.Write("\nNhap chuoi can xu ly: ");
            string nhap = Console.ReadLine();
            int originalLength = nhap.Length; 

            Console.Write("\nNhap kich thuoc ma tran: ");
            int n = int.Parse(Console.ReadLine());

            int[,] key = new int[n, n];
            Console.WriteLine("\nNhap ma tran khoa: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    key[i, j] = int.Parse(Console.ReadLine());
                }
            }

            if (KiemTraNghichDao(key, 26))
            {
                int[,] invKey = TinhMaTranPhuHop(key, 26);

                if (chon == 1)
                {
                    string encryptedText = MaHoa(nhap, key);
                    Console.WriteLine("\nChuoi ma hoa: " + encryptedText);
                }
                else if (chon == 2)
                {
                    string decryptedText = GiaiMa(nhap, invKey, originalLength);
                    Console.WriteLine("\nChuoi giai ma: " + decryptedText);
                }
            }
            else
            {
                Console.WriteLine("\nMa tran khoa khong co nghich dao trong Z26. Vui long nhap lai.");
            }
        }
    }
}
