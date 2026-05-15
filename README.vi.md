# Full-Stack Monorepo Template

[![CI/CD Pipeline](https://github.com/phatom2005/nextjs-dotnet-monorepo-template/actions/workflows/main.yml/badge.svg)](https://github.com/phatom2005/nextjs-dotnet-monorepo-template/actions)
[![CodeQL](https://github.com/phatom2005/nextjs-dotnet-monorepo-template/actions/workflows/github-code-scanning/codeql/badge.svg)](https://github.com/phatom2005/nextjs-dotnet-monorepo-template/actions/workflows/github-code-scanning/codeql)
![Security Status](https://img.shields.io/badge/Security-Snyk_Protected-blueviolet?logo=snyk)
![License](https://img.shields.io/badge/License-MIT-green)

*Đọc bằng ngôn ngữ khác: [English](README.md)*

> **Lean, Secure, and Scalable.** 
> Một bộ khung dự án hoàn chỉnh sử dụng **Next.js** và **.NET 9**.

Đây là một template dự án mạnh mẽ được thiết kế dưới dạng monorepo, kết hợp Frontend hiện đại (Next.js) và Backend hiệu suất cao (.NET 9), được cấu hình sẵn môi trường Docker cho cả hai phía cùng cơ sở dữ liệu PostgreSQL.

## Tech Stack

- **Frontend:** Next.js 15 (App Router), Tailwind CSS
- **Backend:** .NET 9 Web API, Entity Framework Core
- **Database:** PostgreSQL
- **DevOps:** Docker, Docker Compose, GitHub Actions
- **Security:** Snyk Security Scanning

## Cấu trúc dự án

```text
.
├── project/
│   ├── frontend/         # Mã nguồn Next.js 15
│   └── backend/          # Mã nguồn .NET 9 Web API
├── docker-compose.yml    # File cấu hình để build & chạy toàn bộ hệ thống
├── .env                  # Tệp chứa biến môi trường (Database Password)
└── README.md
```

## Hướng dẫn cài đặt & Khởi chạy

### 1. Yêu cầu hệ thống (Prerequisites)
- [Docker & Docker CLI](https://www.docker.com/) (Khuyến nghị dùng Docker để chạy môi trường đồng bộ).
- [Node.js](https://nodejs.org/) (Nếu muốn tự chạy frontend riêng).
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (Nếu muốn phát triển và test backend cục bộ).

### 2. Khởi chạy bằng Docker (Môi trường Development)
Cách đơn giản nhất là khởi chạy đồng loạt cả Frontend, Backend và Database bằng một câu lệnh duy nhất:

1. Đảm bảo file `.env` đã có các thiết lập cần thiết (Mặc định cần có `DB_PASSWORD=YourPassword123` để tránh trường hợp Container DB lỗi).
2. Mở terminal tại mục gốc của dự án này và chạy lệnh:
   ```bash
   docker compose up --build
   ```
3. Sau khi quá trình build thành công, các dịch vụ sẽ hoạt động tại:
   - **Frontend (Next.js):** [http://localhost:3000](http://localhost:3000)
   - **Backend API:** [http://localhost:5000](http://localhost:5000)
   - **Database (PostgreSQL):** Cổng `5432`

> **Lưu ý:** DB Volume được cấu hình ánh xạ ra ngoài, vì thế dữ liệu của DB vẫn được giữ nguyên ngắt container. Dùng thêm cờ `-d` (`docker compose up -d`) nếu bạn muốn chạy ngầm Docker. Để dừng các dịch vụ, hãy chạy `docker compose down`.

### 3. Chạy từng dịch vụ riêng lẻ thủ công

#### Chạy Frontend độc lập (cần Node.js):
```bash
cd project/frontend
npm install
npm run dev
```

#### Chạy Backend độc lập (cần .NET 9 SDK):
```bash
cd project/backend/ProjectTemplate-WebApp
dotnet run
```
*(Lưu ý: Nếu chạy thủ công, bạn cần đảm bảo PostgreSQL đang chạy local hoặc thay đổi chuỗi kết nối Database nằm bên trong `appsettings.Development.json` khớp với thông tin kết nối DB của bạn).*

## Tùy biến dự án 
- **Tên dự án API:** Khi bạn thay đổi hoặc khởi tạo mới tên project bên trong thư mục `backend/` (VD thay vì `ProjectTemplate-WebApp`), hãy nhớ mở file `docker-compose.yml` và cập nhật lại đường dẫn cho trường `dockerfile` để trỏ vào đúng vị trí `Dockerfile` mà bạn sử dụng.
- **Biến môi trường Frontend:** Frontend kết nối với backend qua file biến môi trường `NEXT_PUBLIC_API_URL` được nạp sẵn qua tùy chỉnh trong `.env`/`docker-compose.yml`.

## Security / DevOps
Dự án được cấu hình sẵn Github Actions với các kiểm tra tự động và tích hợp sẵn công cụ **Snyk Security Scanning** để rà quét tự động các lỗ hổng bảo mật.

---
**Happy Coding!**
