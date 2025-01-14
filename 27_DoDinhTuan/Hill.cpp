#include <iostream>
#include <vector>
#include <unordered_map>
#include <string>
#include <cmath>

using namespace std;

unordered_map<char, int> dic1; // Bộ từ điển mã hóa
unordered_map<int, char> dic2; // Bộ từ điển giải mã

// Hàm tính định thức của ma trận (mod Z)
int tinh_dinh_thuc(vector<vector<int>>& matrix, int Z) {
    int det = 0;
    int n = matrix.size();

    if (n == 2) {
        det = matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
    } else {
        for (int j = 0; j < n; j++) {
            vector<vector<int>> subMatrix(n - 1, vector<int>(n - 1));
            for (int i = 1; i < n; i++) {
                int colIndex = 0;
                for (int k = 0; k < n; k++) {
                    if (k == j) continue;
                    subMatrix[i - 1][colIndex++] = matrix[i][k];
                }
            }
            det += matrix[0][j] * pow(-1, j) * tinh_dinh_thuc(subMatrix, Z);
        }
    }
    det = det % Z;
    return (det < 0) ? det + Z : det;
}
// Hàm tìm UCLN của hai số a và b
int _UCLN(int a, int b) {
    while (b != 0) {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

// Hàm kiểm tra xem ma trận có nghịch đảo hay không
bool kiem_tra_nghich_dao(vector<vector<int>>& matrix, int Z) {
    int det = tinh_dinh_thuc(matrix, Z);
        if (_UCLN(Z, det) > 1) return false; // Ma trận không có nghịch đảo khi UCLN(Z, det) > 1
    return true; 
}

// Hàm khởi tạo từ điển mã hóa và giải mã
void khoi_tao_danh_sach() {
    string chars = "";
    for (int i = 32; i < 127; i++) { // Chỉ lấy ký tự ASCII từ 32 đến 126
        chars += static_cast<char>(i);
    }
    for (size_t i = 0; i < chars.size(); i++) { 
        dic1[chars[i]] = i;
        dic2[i] = chars[i];
    }
}

// Hàm tính giá trị nghịch đảo theo modulo
int tinh_nghich_dao(int m, int b) {
    int a1 = 1, a2 = 0, a3 = m;
    int b1 = 0, b2 = 1, b3 = b;
    while (b3 != 0 && b3 != 1) {
        int q = a3 / b3;
        int t1 = a1 - q * b1;
        int t2 = a2 - q * b2;
        int t3 = a3 - q * b3;
        a1 = b1; a2 = b2; a3 = b3;
        b1 = t1; b2 = t2; b3 = t3;
    }
    return (b3 == 1) ? (b2 + m) % m : 0;
}

// Hàm tính ma trận phụ hợp (mod Z)
vector<vector<int>> tinh_ma_tran_phu_hop(vector<vector<int>>& matrix, int Z) {
    int n = matrix.size();
    vector<vector<int>> adj(n, vector<int>(n, 0));
    int det = tinh_dinh_thuc(matrix, Z);
    int inverse_det = tinh_nghich_dao(Z, det);

    if (n == 2) {
        adj[0][0] = matrix[1][1] * inverse_det % Z;
        adj[0][1] = (Z - matrix[0][1]) * inverse_det % Z;
        adj[1][0] = (Z - matrix[1][0]) * inverse_det % Z;
        adj[1][1] = matrix[0][0] * inverse_det % Z;
    } else {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                vector<vector<int>> subMatrix(n - 1, vector<int>(n - 1));
                for (int x = 0, xi = 0; x < n; x++) {
                    if (x == i) continue;
                    for (int y = 0, yj = 0; y < n; y++) {
                        if (y == j) continue;
                        subMatrix[xi][yj++] = matrix[x][y];
                    }
                    xi++;
                }
                adj[j][i] = (int)pow(-1, i + j) * tinh_dinh_thuc(subMatrix, Z) * inverse_det % Z;
                if (adj[j][i] < 0) adj[j][i] += Z;
            }
        }
    }
    return adj;
}

// Hàm nhân hai ma trận
vector<vector<int>> nhan_ma_tran(vector<vector<int>>& A, vector<vector<int>>& B, int Z) {
    int n = A.size();
    vector<vector<int>> result(n, vector<int>(n, 0));

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            for (int k = 0; k < n; k++) {
                result[i][j] = (result[i][j] + A[i][k] * B[k][j]) % Z;
            }
        }
    }
    return result;
}

// Hàm chuyển văn bản sang vector số nguyên
vector<int> chuyen_text_sang_vector(const string& text) {
    vector<int> vec;
    for (char ch : text) {
        vec.push_back(dic1[ch]);
    }
    return vec;
}

// Hàm chuyển vector số nguyên thành văn bản
string chuyen_vector_sang_text(const vector<int>& vec) {
    string text = "";
    for (int num : vec) {
        text += dic2[num];
    }
    return text;
}

// Hàm mã hóa bằng thuật toán Hill
string ma_hoa(const string& inputText, vector<vector<int>>& key) {
    int n = key.size();
    vector<int> inputVec = chuyen_text_sang_vector(inputText);
    vector<int> resultVec(inputVec.size());

    for (size_t i = 0; i < inputVec.size(); i += n) {  
        for (int j = 0; j < n; j++) {
            resultVec[i + j] = 0;
            for (int k = 0; k < n; k++) {
                resultVec[i + j] = (resultVec[i + j] + key[j][k] * inputVec[i + k]) % dic1.size();
            }
        }
    }
    return chuyen_vector_sang_text(resultVec);
}

// Hàm giải mã bằng thuật toán Hill
string giai_ma(const string& inputText, vector<vector<int>>& invKey) {
    cout << "\nMa tran nghich dao:\n";
    for (size_t i = 0; i < invKey.size(); i++) {
        for (size_t j = 0; j < invKey[i].size(); j++) {
            cout << invKey[i][j] << " ";
        }
        cout << endl;
    }

    return ma_hoa(inputText, invKey); // Sử dụng hàm ma_hoa với khóa nghịch đảo
}

int main() {
    khoi_tao_danh_sach();
    bool continueRunning = true;

    while (continueRunning) {
        cout << "---------------------------------------------------" << endl;
        cout << "Chuong trinh ma hoa va giai ma theo Thuat toan Hill" << endl;
        cout << "---------------------------------------------------" << endl;
        cout << "Chon chuc nang:" << endl;
        cout << "1. Ma hoa" << endl;
        cout << "2. Giai ma" << endl;
        cout << "3. Thoat" << endl;
        cout << "Nhap lua chon cua ban: ";
        int choice;
        cin >> choice;

        // Điều hướng đến các chức năng dựa trên lựa chọn
        if (choice == 3) {
            cout << "Cam on ban da su dung chuong trinh!" << endl;
            break;
        }

        cin.ignore(); // Xóa bộ đệm đầu vào
        cout << "\nNhap chuoi can xu ly: ";
        string inputText;
        getline(cin, inputText);

        cout << "\nNhap kich thuoc ma tran khoa (n x n): ";
        int n;
        cin >> n;

        if (n < 2) {
            cout << "Ma tran phai co kich thuoc tu 2x2 tro len!" << endl;
            continue;
        }

        vector<vector<int>> keyMatrix(n, vector<int>(n));
        cout << "\nNhap ma tran khoa:" << endl;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                cout << "Phan tu [" << i << "," << j << "]: ";
                cin >> keyMatrix[i][j];
            }
        }

        cout << "\nMa tran khoa:" << endl;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                cout << keyMatrix[i][j] << " ";
            }
            cout << endl;
        }

        if (!kiem_tra_nghich_dao(keyMatrix, dic1.size())) {
            cout << "Ma tran khoa khong co nghich dao!" << endl;
            continue;
        }

        vector<vector<int>> invKey = tinh_ma_tran_phu_hop(keyMatrix, dic1.size());

        string resultText;
        if (choice == 1) {
            resultText = ma_hoa(inputText, keyMatrix);
            cout << "\nChuoi ma hoa: " << resultText << endl;
        } else if (choice == 2) {
            resultText = giai_ma(inputText, invKey);
            cout << "\nChuoi giai ma: " << resultText << endl;
        }
    }
    return 0;
}
