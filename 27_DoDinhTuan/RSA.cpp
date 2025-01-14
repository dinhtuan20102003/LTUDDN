//27_Đỗ Đình Tuấn_21103100756
#include <iostream>
#include <cmath>
#include <cstdlib>

using namespace std;

// Ham tinh luy thua mu mod
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

// Ham tinh uoc chung lon nhat
long long uocChungLonNhat(long long a, long long b) {
    while (b != 0) {
        long long t = b;
        b = a % b;
        a = t;
    }
    return a;
}

// Ham tim nghich dao mod
long long timNghichDaoMod(long long a, long long m) {
    for (long long x = 1; x < m; x++) {
        if ((a * x) % m == 1) return x;
    }
    return -1; // Neu khong tim duoc nghich dao
}

// Ham kiem tra so nguyen to
bool kiemTraSoNguyenTo(long long n) {
    if (n <= 1) return false;
    for (long long i = 2; i <= sqrt(n); i++) {
        if (n % i == 0) {
            return false;
        }
    }
    return true;
}

// Ham sinh cap khoa RSA
void sinhCapKhoa(long long &e, long long &d, long long &n, long long &phi_n) {
    long long p, q;
    // Nhap p va q (2 so nguyen to)
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

    // Cho phep nguoi dung nhap e sao cho 1 < e < phi(n) va gcd(e, phi(n)) = 1
    do {
        cout << "Nhap gia tri e (1 < e < " << phi_n << " va gcd(e, " << phi_n << ") = 1): ";
        cin >> e;
        if (e <= 1 || e >= phi_n || uocChungLonNhat(e, phi_n) != 1) {
            cout << "Gia tri e khong hop le. Vui long nhap lai." << endl;
        }
    } while (e <= 1 || e >= phi_n || uocChungLonNhat(e, phi_n) != 1);

    // Tinh d sao cho (d * e) % phi(n) = 1
    d = timNghichDaoMod(e, phi_n);
}

// Ham ky so
long long kySoThongDiep(long long thongDiep, long long e, long long n) {
    return tinhLuyThuaMod(thongDiep, e, n); 
}

// Ham xac minh chu ky
bool xacMinhChuKy(long long thongDiep, long long chuKy, long long d, long long n) {
    return tinhLuyThuaMod(chuKy, d, n) == thongDiep; 
}

int main() {
    long long e, d, n, phi_n;
    long long thongDiep, chuKy;

    // Sinh cap khoa RSA
    sinhCapKhoa(e, d, n, phi_n);

    // Hien thi cac gia tri trung gian
    cout << "\n===== CAC GIA TRI TRUNG GIAN =====" << endl;
    cout << "  * Gia tri p va q la cac so nguyen to" << endl;
    cout << "  * Gia tri n (p * q)     : " << n << endl;
    cout << "  * Gia tri phi(n)        : " << phi_n << endl;
    cout << "  * Gia tri e (gcd(e, phi(n)) = 1): " << e << endl;
    cout << "  * Gia tri d ((d * e) % phi(n) = 1): " << d << endl;

    // Hien thi khoa cong khai va khoa bi mat
    cout << "\n===== KHOA RSA =====" << endl;
    cout << "  Khoa cong khai  (e, n): (" << e << ", " << n << ")" << endl;
    cout << "  Khoa bi mat     (d, n): (" << d << ", " << n << ")" << endl;

    // Ma hoa va ky so
    cout << "\nNhap thong diep (so nguyen) de ky: ";
    cin >> thongDiep;
    chuKy = kySoThongDiep(thongDiep, e, n);
    cout << "Chu ky so cua thong diep: " << chuKy << endl;

    // Xac minh chu ky
    cout << "\n===== XAC MINH CHU KY =====" << endl;
    if (xacMinhChuKy(thongDiep, chuKy, d, n)) {
        cout << "Chu ky hop le!" << endl;
        cout << "Thong diep goc la: " << thongDiep << endl;
    } else {
        cout << "Chu ky khong hop le!" << endl;
    }

    return 0;
}
