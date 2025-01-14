//27_Đỗ Đình Tuấn_21103100756
#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
#include <algorithm>
using namespace std;

int ChuyenSo(string BangChuCai, char Chuoi) {
    for (size_t i = 0; i < BangChuCai.length(); i++) {
        if (BangChuCai[i] == Chuoi) {
            return i;
        }
    }
    return -1;
}

string MaHoaDichVong(string BangChuCai, string Chuoi, int k) {
    string MaChu = "";
    for (size_t i = 0; i < Chuoi.length(); i++) {
        int MaSo = ChuyenSo(BangChuCai, Chuoi[i]);
        int temp = (MaSo + k) % 26;
        MaChu += BangChuCai[temp];
    }
    return MaChu;
}

string GiaiMaDichVong(string BangChuCai, string Chuoi, int k) {
    string GiaiMa = "";
    for (size_t i = 0; i < Chuoi.length(); i++) {
        int MaSo = ChuyenSo(BangChuCai, Chuoi[i]);
        int temp = (MaSo - k + 26) % 26;
        GiaiMa += BangChuCai[temp];
    }
    return GiaiMa;
}

string MaHoaThayThe(string BangChuCai, string BangThayThe, string Chuoi) {
    string MaChu = "";
    for (size_t i = 0; i < Chuoi.length(); i++) {
        int MaSo = ChuyenSo(BangChuCai, Chuoi[i]);
        MaChu += BangThayThe[MaSo];
    }
    return MaChu;
}

string GiaiMaThayThe(string BangChuCai, string BangThayThe, string Chuoi) {
    string GiaiMa = "";
    for (size_t i = 0; i < Chuoi.length(); i++) {
        int MaSo = ChuyenSo(BangThayThe, Chuoi[i]);
        GiaiMa += BangChuCai[MaSo];
    }
    return GiaiMa;
}

int gcd(int a, int b) {
    while (b != 0) {
        int c = a % b;
        a = b;
        b = c;
    }
    return a;
}

int modInverse(int a, int m) {
    for (int x = 1; x < m; x++) {
        if ((a * x) % m == 1) return x;
    }
    return -1;
}

string MaHoaAffine(string BangChuCai, string Chuoi, int a, int b) {
    string MaChu = "";
    for (size_t i = 0; i < Chuoi.length(); i++) {
        char x = toupper(Chuoi[i]) - 'A';
        char MaSo = (a * x + b) % 26;
        MaChu += BangChuCai[MaSo];
    }
    return MaChu;
}

string GiaiMaAffine(string BangChuCai, string Chuoi, int a, int b) {
    string GiaiMa = "";
    int a_inv = modInverse(a, 26);
    if (a_inv == -1) {
        cout << "Khong co nghich dao modular cho a. Giai ma that bai!" << endl;
        return "";
    }

    for (size_t i = 0; i < Chuoi.length(); i++) {
        char y = toupper(Chuoi[i]) - 'A';
        char MaSo = (a_inv * (y - b + 26)) % 26;
        GiaiMa += BangChuCai[MaSo];
    }
    return GiaiMa;
}

string MaHoaVigenere(string BangChuCai, string Chuoi, string khoa) {
    string MaChu = "";
    int m = khoa.length();
    
    for (size_t i = 0; i < Chuoi.length(); i++) {
        int MaSo = ChuyenSo(BangChuCai, Chuoi[i]);
        int KhoaSo = ChuyenSo(BangChuCai, khoa[i % m]);
        int temp = (MaSo + KhoaSo) % 26;
        MaChu += BangChuCai[temp];
    }
    return MaChu;
}

string GiaiMaVigenere(string BangChuCai, string Chuoi, string khoa) {
    string GiaiMa = "";
    int m = khoa.length();
    
    for (size_t i = 0; i < Chuoi.length(); i++) {
        int MaSo = ChuyenSo(BangChuCai, Chuoi[i]);
        int KhoaSo = ChuyenSo(BangChuCai, khoa[i % m]);
        int temp = (MaSo - KhoaSo + 26) % 26;
        GiaiMa += BangChuCai[temp];
    }
    return GiaiMa;
}

void DocVaXuLy(string loaiMaHoa, string tenTepNhap, string tenTepXuat, bool laMaHoa, int k = 0, int a = 0, int b = 0, string khoa = "") {
    ifstream fileNhap(tenTepNhap);
    ofstream fileXuat(tenTepXuat);
    string BangChuCai = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string BangThayThe = "QWERTYUIOPLKJHGFDSAZXCVBNM";
    string Chuoi, ketQua;

    if (fileNhap.is_open()) {
        getline(fileNhap, Chuoi);
        fileNhap.close();

        if (loaiMaHoa == "DichVong") {
            ketQua = laMaHoa ? MaHoaDichVong(BangChuCai, Chuoi, k) : GiaiMaDichVong(BangChuCai, Chuoi, k);
        } else if (loaiMaHoa == "ThayThe") {
            ketQua = laMaHoa ? MaHoaThayThe(BangChuCai, BangThayThe, Chuoi) : GiaiMaThayThe(BangChuCai, BangThayThe, Chuoi);
        } else if (loaiMaHoa == "Affine") {
            ketQua = laMaHoa ? MaHoaAffine(BangChuCai, Chuoi, a, b) : GiaiMaAffine(BangChuCai, Chuoi, a, b);
        } else if (loaiMaHoa == "Vigenere") {
            ketQua = laMaHoa ? MaHoaVigenere(BangChuCai, Chuoi, khoa) : GiaiMaVigenere(BangChuCai, Chuoi, khoa);
        }

        fileXuat << ketQua;
        fileXuat.close();
    } else {
        cout << "Khong the mo tep " << tenTepNhap << endl;
    }
}

void InGiaoDien() {
    cout << "===============================" << endl;
    cout << "      CHUONG TRINH MA HOA      " << endl;
    cout << "===============================" << endl;
    cout << "1. Dich Vong" << endl;
    cout << "2. Thay The" << endl;
    cout << "3. Affine" << endl;
    cout << "4. Vigenere" << endl;
    cout << "===============================" << endl;
}

void ChonMaHoaHayGiaiMa() {
    cout << "\nBan muon thuc hien: " << endl;
    cout << "1. Ma hoa" << endl;
    cout << "2. Giai ma" << endl;
    cout << "Lua chon: ";
}

int main() {
    string tenTepNhap, tenTepXuat, khoa;
    int chon, k, a, b, thaoTac;

    InGiaoDien();

    cout << "Nhap ten tep dau vao: ";
    cin >> tenTepNhap;
    cout << "Nhap ten tep dau ra: ";
    cin >> tenTepXuat;

    cout << "Chon loai ma hoa: ";
    cin >> chon;

    ChonMaHoaHayGiaiMa();
    cin >> thaoTac;

    bool laMaHoa = (thaoTac == 1);

    switch (chon) {
        case 1: {
            cout << "Nhap khoa Dich vong: ";
            cin >> k;
            DocVaXuLy("DichVong", tenTepNhap, tenTepXuat, laMaHoa, k);
            break;
        }
        case 2: {
            DocVaXuLy("ThayThe", tenTepNhap, tenTepXuat, laMaHoa);
            break;
        }
        case 3: {
            cout << "Nhap khoa a: ";
            cin >> a;
            cout << "Nhap khoa b: ";
            cin >> b;
            DocVaXuLy("Affine", tenTepNhap, tenTepXuat, laMaHoa, 0, a, b);
            break;
        }
        case 4: {
            cout << "Nhap khoa Vigenere: ";
            cin >> khoa;
            DocVaXuLy("Vigenere", tenTepNhap, tenTepXuat, laMaHoa, 0, 0, 0, khoa);
            break;
        }
        default: {
            cout << "Lua chon khong hop le!" << endl;
            break;
        }
    }

    cout << "Ket qua da luu vao tep " << tenTepXuat << endl;
    cout << "===============================" << endl;
    cout << "          HOAN TAT             " << endl;
    cout << "===============================" << endl;

    return 0;
}
