using System;
using System.Security.Cryptography;
using System.Text;

namespace DigitalSignatureApp
{
    class Program
    {
        static long n, phi, e, d;

      
        static long ModPow(long baseValue, long exponent, long mod)
        {
            long result = 1;
            while (exponent > 0)
            {
                if ((exponent % 2) == 1)
                    result = (result * baseValue) % mod;

                baseValue = (baseValue * baseValue) % mod;
                exponent /= 2;
            }
            return result;
        }

       
        static bool IsPrime(long num)
        {
            if (num <= 1) return false;
            for (long i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

       
        static string HashMessage(string message)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(message));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

      
        static long GenerateSignature(long z, long d, long n)
        {
            return ModPow(z, d, n);
        }

        
        static long DecryptSignature(long y, long e, long n)
        {
            return ModPow(y, e, n);
        }

       
        static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

      
        static long ModInverse(long a, long m)
        {
            for (long x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                    return x;
            }
            return -1; 
        }

      
        static void GenerateRSAKeys()
        {
            do
            {
                Console.Write("Nhập số nguyên tố p: ");
                long p = long.Parse(Console.ReadLine());
                if (!IsPrime(p)) { Console.WriteLine("p không phải số nguyên tố. Vui lòng nhập lại."); continue; }

                Console.Write("Nhập số nguyên tố q: ");
                long q = long.Parse(Console.ReadLine());
                if (!IsPrime(q)) { Console.WriteLine("q không phải số nguyên tố. Vui lòng nhập lại."); continue; }

                n = p * q;
                phi = (p - 1) * (q - 1);

                Console.WriteLine($"n = {n}, phi(n) = {phi}");

                do
                {
                    Console.Write($"Nhập khóa công khai e (1 < e < {phi} và gcd(e, phi) = 1): ");
                    e = long.Parse(Console.ReadLine());

                    if (e <= 1 || e >= phi)
                    {
                        Console.WriteLine($"e phải nằm trong khoảng (1, {phi}). Vui lòng nhập lại.");
                    }
                    else if (GCD(e, phi) != 1)
                    {
                        Console.WriteLine($"e và phi(n) phải có UCLN = 1. Vui lòng nhập lại.");
                    }
                } while (e <= 1 || e >= phi || GCD(e, phi) != 1);

                d = ModInverse(e, phi);
                if (d == e)
                {
                    Console.WriteLine("Khóa bí mật d không được bằng e. Vui lòng nhập lại.");
                    continue;
                }

                Console.WriteLine($"Khóa công khai (e, n): ({e}, {n})");
                Console.WriteLine($"Khóa bí mật (d, n): ({d}, {n})");
                break;
            } while (true);
        }

        static void DisplayKeys()
        {
            Console.WriteLine("\n=== THÔNG TIN KHÓA RSA ===");
            Console.WriteLine($"Khóa công khai (e, n): ({e}, {n})");
            Console.WriteLine($"Khóa bí mật (d, n): ({d}, {n})\n");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
           
            Console.WriteLine("==== BẮT ĐẦU CHƯƠNG TRÌNH ====");
            Console.WriteLine("Bước 1: Tạo khóa RSA");
            GenerateRSAKeys();

         
            int choice;
            do
            {
                Console.Clear();
                DisplayKeys();
                Console.WriteLine("======= MENU =======");
                Console.WriteLine("1. Ký số thông điệp");
                Console.WriteLine("2. Xác minh chữ ký");
                Console.WriteLine("3. Thoát");
                Console.Write("Nhập lựa chọn (1-3): ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Nhập thông điệp cần ký: ");
                        string message = Console.ReadLine();
                        string hash = HashMessage(message);
                        long z = Convert.ToInt64(hash.Substring(0, 15), 16) % n; 
                        long signature = GenerateSignature(z, d, n);
                        Console.WriteLine($"Thông điệp băm z: {z}");
                        Console.WriteLine($"Chữ ký số y: {signature}");
                        Console.WriteLine("Nhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("Nhập thông điệp cần xác minh: ");
                        string receivedMessage = Console.ReadLine();
                        Console.Write("Nhập chữ ký số (y): ");
                        long receivedSignature = long.Parse(Console.ReadLine());

                        long decryptedZ = DecryptSignature(receivedSignature, e, n);
                        Console.WriteLine($"Giải mã chữ ký số y, thu được z': {decryptedZ}");

                        string hashedMessageB = HashMessage(receivedMessage);
                        long h_x = Convert.ToInt64(hashedMessageB.Substring(0, 15), 16) % n;
                        Console.WriteLine($"Băm thông điệp x, thu được h(x): {h_x}");

                        if (decryptedZ == h_x)
                        {
                            Console.WriteLine("Thông điệp x còn nguyên vẹn và được gửi từ A.");
                        }
                        else
                        {
                            Console.WriteLine("Thông điệp x bị thay đổi hoặc không đến từ A.");
                        }
                        Console.WriteLine("Nhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            } while (choice != 3);
        }
    }
}
