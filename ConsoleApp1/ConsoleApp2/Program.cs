using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

public class AlgorithmRSA
{
    private BigInteger n, d, e;

    // Các thuộc tính công khai để truy cập giá trị n, d, e
    public BigInteger N
    {
        get { return n; }
        set { n = value; }
    }

    public BigInteger D
    {
        get { return d; }
        set { d = value; }
    }

    public BigInteger E
    {
        get { return e; }
        set { e = value; }
    }

    // Constructor nhận n và e
    public AlgorithmRSA(BigInteger n1, BigInteger e1)
    {
        n = n1;
        e = e1;
    }

    // Constructor mặc định
    public AlgorithmRSA() { }

    // Phương thức tạo khóa RSA (Khóa công khai và khóa bí mật)
    public void KeyRSA()
    {
        Console.WriteLine("Nhập số nguyên tố p:");
        BigInteger p = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine("Nhập số nguyên tố q:");
        BigInteger q = BigInteger.Parse(Console.ReadLine());

        // Tính n = p * q
        n = p * q;
        BigInteger phi = (p - 1) * (q - 1);

        Console.WriteLine($"Giá trị n (p * q): {n}");
        Console.WriteLine($"Giá trị phi(n) = (p-1) * (q-1): {phi}");

        // Chọn e sao cho gcd(e, phi) = 1
        do
        {
            Console.WriteLine("Nhập giá trị e sao cho gcd(e, phi(n)) = 1:");
            e = BigInteger.Parse(Console.ReadLine());
        } while (BigInteger.GreatestCommonDivisor(e, phi) != 1);

        // Tính d là nghịch đảo của e mod phi(n)
        d = ModInverse(e, phi);

        Console.WriteLine($"Khóa công khai (e, n): ({e}, {n})");
        Console.WriteLine($"Khóa bí mật (e, n): ({e}, {n})");  // Hiển thị khóa bí mật (vẫn là e, n)
        Console.WriteLine($"Khóa bí mật (d): {d}");  // Và khóa bí mật (d) sẽ là thông số cần thiết để giải mã
    }

    // Phương thức mã hóa thông điệp
    public string Encrypt(string plaintext)
    {
        // Chuyển chuỗi văn bản thành BigInteger
        byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
        BigInteger m = new BigInteger(plaintextBytes);

        // Mã hóa thông điệp với khóa công khai (e, n)
        BigInteger c = BigInteger.ModPow(m, e, n);

        return c.ToString();
    }

    // Phương thức giải mã
    public string Decrypt(string ciphertext)
    {
        // Giải mã chuỗi đã mã hóa (ciphertext) thành BigInteger
        BigInteger c = BigInteger.Parse(ciphertext);

        // Giải mã thông điệp với khóa bí mật (d)
        BigInteger m = BigInteger.ModPow(c, d, n);

        // Chuyển đổi giá trị BigInteger ra chuỗi byte
        byte[] decryptedBytes = m.ToByteArray();

        // Chuyển chuỗi byte thành chuỗi UTF8
        return Encoding.UTF8.GetString(decryptedBytes).TrimEnd('\0');
    }

    // Phương thức tính nghịch đảo modular
    private BigInteger ModInverse(BigInteger a, BigInteger m)
    {
        BigInteger m0 = m, t, q;
        BigInteger x0 = 0, x1 = 1;

        while (a > 1)
        {
            q = a / m;
            t = m;
            m = a % m; a = t;
            t = x0;
            x0 = x1 - q * x0;
            x1 = t;
        }

        if (x1 < 0)
            x1 += m0;

        return x1;
    }

    // Phương thức chính để chạy chương trình
    public static void Main(string[] args)
    {
        AlgorithmRSA rsa = new AlgorithmRSA();
        Console.OutputEncoding = Encoding.UTF8;

        // Tạo khóa RSA với số bit nhập vào từ người dùng
        rsa.KeyRSA();

        while (true)
        {
            Console.WriteLine("\nChọn thao tác:");
            Console.WriteLine("1. Mã hóa");
            Console.WriteLine("2. Giải mã");
            Console.WriteLine("3. Thoát");
            Console.Write("Lựa chọn của bạn: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Mã hóa
                Console.Write("Nhập chuỗi cần mã hóa: ");
                string plaintext = Console.ReadLine();
                string ciphertext = rsa.Encrypt(plaintext);
                Console.WriteLine($"Chuỗi đã mã hóa: {ciphertext}");
            }
            else if (choice == "2")
            {
                // Giải mã
                Console.Write("Nhập chuỗi đã mã hóa: ");
                string ciphertext = Console.ReadLine();
                string decrypted = rsa.Decrypt(ciphertext);
                Console.WriteLine($"Chuỗi đã giải mã: {decrypted}");
            }
            else if (choice == "3")
            {
                // Thoát chương trình
                Console.WriteLine("Thoát chương trình.");
                break;
            }
            else
            {
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
            }
        }
    }
}
