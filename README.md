# SplitMateAPI

SplitMateAPI là một dự án API được xây dựng bằng ngôn ngữ C# nhằm hỗ trợ việc chia sẻ hóa đơn, chi phí hoặc các khoản tài chính giữa nhiều người một cách dễ dàng và minh bạch.

## Tính năng chính

- Tạo nhóm chia sẻ chi phí.
- Thêm/sửa/xóa thành viên trong nhóm.
- Quản lý các khoản chi tiêu, ghi nhận ai trả tiền và ai cần thanh toán lại.
- Tổng hợp và chia đều hoặc tùy chỉnh số tiền từng thành viên cần trả.
- API linh hoạt, dễ tích hợp vào các ứng dụng mobile/web.

## Cấu trúc dự án

```
SplitMateAPI/
├── .gitignore
├── SplitMateAPI.sln
└── SplitMateAPI/
    └── ... (Source code C#)
```
- `.gitignore`: Cấu hình loại trừ file không cần thiết.
- `SplitMateAPI.sln`: File giải pháp của dự án .NET.
- `SplitMateAPI/`: Thư mục chứa mã nguồn chính của dự án.

## Yêu cầu hệ thống

- .NET SDK mới nhất (khuyến nghị .NET 6 trở lên)
- C# (dự án dạng Web API)

## Hướng dẫn khởi động

1. Clone repository về máy:
   ```
   git clone https://github.com/Toan-LD/SplitMateAPI.git
   ```
2. Mở bằng Visual Studio hoặc sử dụng terminal:
   ```
   dotnet restore
   dotnet build
   dotnet run
   ```
3. Truy cập endpoint API qua địa chỉ được cấu hình (thường là `http://localhost:5000` hoặc tương tự).

## Đóng góp

Nếu bạn muốn đóng góp hoặc báo lỗi, hãy tạo issue hoặc gửi pull request trên repository này.

---

**Tác giả:** [Toan-LD](https://github.com/Toan-LD)  
**Liên hệ:** Thành Phố Hồ Chí Minh
