// 27_Đỗ Đình Tuấn_21103100756
#include <iostream>
#include <cmath>
#include <cstdlib>
#include <openssl/sha.h> // Thư viện OpenSSL
#include <iomanip>
#include <sstream>

using namespace std;

// Hàm tính lũy thừa cơ số lớn theo modulo
long long tinhLuyThuaMod(long long coSo, long long soMu, long long mod) {
    long long ketQua = 1;
    while (soMu > 0) {
        if (soMu % 2 == 1) {
            ketQua = (ketQua * coSo) % mod;
        }
        coSo = (coSo * coSo) % mod;
        soMu /= 2;
    }
    return ketQua;
}

// Tìm ước chung lớn nhất (gcd)
long long uocChungLonNhat(long long a, long long b) {
    while (b != 0) {
        long long t = b;
        b = a % b;
        a = t;
    }
    return a;
}

// Tìm nghịch đảo modular
long long timNghichDaoMod(long long a, long long m) {
    for (long long x = 1; x < m; x++) {
        if ((a * x) % m == 1) return x;
    }
    return -1;
}

// Kiểm tra số nguyên tố
bool kiemTraSoNguyenTo(long long n) {
    if (n <= 1) return false;
    for (long long i = 2; i <= sqrt(n); i++) {
        if (n % i == 0) {
            return false;
        }
    }
    return true;
}

// Hàm băm SHA-256
std::string tinhHamBamSHA256(const std::string& thongDiep) {
    unsigned char hash[SHA256_DIGEST_LENGTH];
    SHA256((unsigned char*)thongDiep.c_str(), thongDiep.size(), hash);

    std::ostringstream oss;
    for (int i = 0; i < SHA256_DIGEST_LENGTH; i++) {
        oss << std::hex << std::setw(2) << std::setfill('0') << (int)hash[i];
    }
    return oss.str();
}

// Sinh cặp khóa RSA
void sinhCapKhoa(long long& e, long long& d, long long& n, long long& phi_n) {
    long long p, q;
    do {
        cout << "Nhap so nguyen to p: ";
        cin >> p;
        if (!kiemTraSoNguyenTo(p)) {
            cout << "So " << p << " khong phai la so nguyen to. Vui long nhap lai." << endl;
        }
    } while (!kiemTraSoNguyenTo(p));

    do {
        cout << "Nhap so nguyen to q: ";
        cin >> q;
        if (!kiemTraSoNguyenTo(q)) {
            cout << "So " << q << " khong phai la so nguyen to. Vui long nhap lai." << endl;
        }
    } while (!kiemTraSoNguyenTo(q));

    n = p * q;
    phi_n = (p - 1) * (q - 1);

    do {
        cout << "Nhap gia tri e (1 < e < " << phi_n << " va gcd(e, " << phi_n << ") = 1): ";
        cin >> e;
        if (e <= 1 || e >= phi_n || uocChungLonNhat(e, phi_n) != 1) {
            cout << "Gia tri e khong hop le. Vui long nhap lai." << endl;
        }
    } while (e <= 1 || e >= phi_n || uocChungLonNhat(e, phi_n) != 1);

    d = timNghichDaoMod(e, phi_n);
}

// Ký số thông điệp
long long kySoThongDiep(long long thongDiep, long long e, long long n) {
    return tinhLuyThuaMod(thongDiep, e, n);
}

// Xác minh chữ ký
bool xacMinhChuKy(long long thongDiep, long long chuKy, long long d, long long n) {
    return tinhLuyThuaMod(chuKy, d, n) == thongDiep;
}

// Chương trình chính
int main() {
    long long e, d, n, phi_n;
    long long chuKy;

    // Sinh cặp khóa
    sinhCapKhoa(e, d, n, phi_n);

    cout << "\n===== CAC GIA TRI TRUNG GIAN =====" << endl;
    cout << "  * Gia tri n = (p * q)             : " << n << endl;
    cout << "  * Gia tri phi(n) = (p-1) * (q-1)  : " << phi_n << endl;
    cout << "  * Gia tri e (gcd(e, phi(n)) = 1)  : " << e << endl;
    cout << "  * Gia tri d ((d * e) % phi(n) = 1): " << d << endl;

    cout << "\n============= KHOA RSA =============" << endl;
    cout << "  Khoa cong khai  (e, n): (" << e << ", " << n << ")" << endl;
    cout << "  Khoa bi mat     (d, n): (" << d << ", " << n << ")" << endl;

    int luaChon;
    do {
        cout << "\n============= MENU =============" << endl;
        cout << "1. Nhap thong diep de ky" << endl;
        cout << "2. Xac minh chu ky" << endl;
        cout << "3. Thoat" << endl;
        cout << "Nhap lua chon (1-3): ";
        cin >> luaChon;

        switch (luaChon) {
        case 1: {
            std::string thongDiepChuoi;
            cout << "\nNhap thong diep de ky: ";
            cin.ignore();
            getline(cin, thongDiepChuoi);

            // Tính giá trị hàm băm
            std::string hashThongDiep = tinhHamBamSHA256(thongDiepChuoi);
            cout << "Gia tri ham bam SHA-256 cua thong diep: " << hashThongDiep << endl;

            // Ký giá trị hàm băm
            long long thongDiepBam = std::stoll(hashThongDiep.substr(0, 15), nullptr, 16); // Lấy 15 ký tự đầu
            chuKy = kySoThongDiep(thongDiepBam, e, n);
            cout << "Chu ky so cua thong diep: " << chuKy << endl;

            cout << "Nhan phim bat ki de tiep tuc..." << endl;
            system("pause");
            break;
        }
        case 2: {
            std::string thongDiepChuoi;
            cout << "\nNhap thong diep ban dau: ";
            cin.ignore();
            getline(cin, thongDiepChuoi);

            cout << "Nhap chu ky de xac minh: ";
            cin >> chuKy;

            // Tính giá trị hàm băm
            std::string hashThongDiep = tinhHamBamSHA256(thongDiepChuoi);
            long long thongDiepBam = std::stoll(hashThongDiep.substr(0, 15), nullptr, 16);

            // Xác minh chữ ký
            if (xacMinhChuKy(thongDiepBam, chuKy, d, n)) {
                cout << "Chu ky hop le!" << endl;
                cout << "Thong diep goc la: " << thongDiepChuoi << endl;
            }
            else {
                cout << "Chu ky khong hop le!" << endl;
            }

            cout << "Nhan phim bat ki de tiep tuc..." << endl;
            system("pause");
            break;
        }
        case 3:
            cout << "Thoat chuong trinh." << endl;
            break;
        default:
            cout << "Lua chon khong hop le. Vui long chon lai." << endl;
        }
    } while (luaChon != 3);

    return 0;
}
