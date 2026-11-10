# BÁO CÁO BÀI TẬP / ĐỒ ÁN

## THÔNG TIN SINH VIÊN
- **Họ và tên:** Nguyễn Khánh Đức
- **Mã số sinh viên:** 24810320072
- **Lớp:** D19QTANM1
- **Tên môn học:** Lập trình C# / Windows Forms
- **Tên bài tập:** BÀI 6.5: HỆ THỐNG QUẢN LÝ ĐẶT PHÒNG & DỊCH VỤ KARAOKE
(KARAOKE MANAGEMENT SYSTEM)

---

## KẾT QUẢ THỰC HÀNH

- Giao diện chính
<img width="1375" height="885" alt="Screenshot 2026-11-10 191952" src="https://github.com/user-attachments/assets/2a8e7ebc-c706-4e73-8fb0-09e826a74c48" />

- Xác nhận đặt phòng
<img width="1382" height="865" alt="Screenshot 2026-11-10 192000" src="https://github.com/user-attachments/assets/7ac49226-9ece-4b6e-9a76-34535ea08d01" />

- Giao diện phòng khi có người đặt
<img width="1381" height="883" alt="Screenshot 2026-11-10 192006" src="https://github.com/user-attachments/assets/683aab70-b9cc-44cd-bd96-8133fad224db" />

- Tính tổng tiền + thanh toán
<img width="1395" height="876" alt="Screenshot 2026-11-10 192013" src="https://github.com/user-attachments/assets/633ff003-9739-4495-98e6-2456466713f3" />

## HƯỚNG DẪN CÀI ĐẶT VÀ CHẠY DỰ ÁN:
1. **Khởi tạo CSDL**:
   - Mở file `Database.sql` có sẵn trong thư mục dự án bằng SQL Server Management Studio (SSMS) hoặc Visual Studio.
   - Chạy toàn bộ script (Execute) để tự động tạo CSDL `KaraokeDB` cùng các bảng và dữ liệu mẫu.

2. **Cấu hình chuỗi kết nối**:
   - Mở file `Dbhelper.cs`.
   - Kiểm tra và đổi lại `Data Source` cho khớp với tên SQL Server trên máy chấm (Mặc định đang để kết nối tới `(localdb)\MSSQLLocalDB`).

3. **Chạy chương trình**:
   - Nhấn **F5** (hoặc nút Start) trên Visual Studio để chạy hệ thống.
