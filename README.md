# MyApplication - ระบบขออนุญาตเมีย 💕

ระบบจัดการคำขออนุญาตออกไปข้างนอกแบบมีระเบียบ สร้างด้วย ASP.NET Core Blazor Server และ MudBlazor

## ⚡ ความต้องการของระบบ

### Software Requirements
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 หรือ Visual Studio Code
- Web Browser ที่รองรับ JavaScript

### Operating System
- Windows 10/11
- macOS 10.15+
- Linux (Ubuntu 20.04+, CentOS 8+)

## 🚀 การติดตั้งโปรเจค

### 1. Clone Repository
```bash
git clone [repository-url]
cd please-let-me-go-my-wife
```

### 2. ตรวจสอบ .NET SDK
```bash
dotnet --version
```
ต้องเป็นเวอร์ชัน 8.0 หรือสูงกว่า

### 3. เข้าไปในโฟลเดอร์โปรเจค
```bash
cd MyApplication
```

### 4. Restore Dependencies
```bash
dotnet restore
```

### 5. Build โปรเจค
```bash
dotnet build
```

### 6. รันโปรเจค
```bash
dotnet run
```

หรือในโหมด Development:
```bash
dotnet watch run
```

### 7. เปิดเว็บไซต์
เปิด browser แล้วไปที่: `https://localhost:5001` หรือ `http://localhost:5000`

## 📦 Dependencies

โปรเจคนี้ใช้ NuGet packages ดังนี้:

- **MudBlazor 8.x** - Material Design UI Components สำหรับ Blazor
- **ASP.NET Core 8.0** - Web Framework
- **Blazor Server** - Server-side rendering

## 🏗️ โครงสร้างโปรเจค

```
please-let-me-go-my-wife/
└── MyApplication/
    ├── Components/
    │   ├── Layout/           # Layout components
    │   ├── Pages/           # Page components (.razor)
    │   ├── App.razor        # Root component
    │   └── _Imports.razor   # Global imports
    ├── Services/
    │   ├── AuthService.cs   # Authentication service
    │   └── RequestService.cs # Request management service
    ├── Models/
    │   ├── LoginModel.cs    # Login data model
    │   ├── RequestModel.cs  # Request data model
    │   └── UserModel.cs     # User data model
    ├── Data/
    │   └── requests.json    # Data storage
    ├── Attributes/          # Custom validation attributes
    ├── wwwroot/            # Static files
    └── Program.cs          # Application entry point
```

## 🎯 Features

- 🏠 **หน้าแรก**: ต้อนรับและนำทางหลัก
- 🔐 **ระบบ Login**: เข้าสู่ระบบด้วย Username/Password
- 📋 **Dashboard**: จัดการคำขออนุญาตสำหรับผู้ที่เข้าสู่ระบบ
- 📝 **Request Form**: ส่งคำขออนุญาตออกไป
- 👑 **Admin Panel**: จัดการคำขอทั้งหมด (สำหรับ admin)
- ⛅ **Weather**: ตรวจสอบสภาพอากาศ
- 📖 **Documentation**: คู่มือการใช้งาน

## ⚙️ การตั้งค่า

### Development Environment
แก้ไขไฟล์ `MyApplication/appsettings.Development.json` สำหรับการตั้งค่าในโหมด Development

### Production Environment  
แก้ไขไฟล์ `MyApplication/appsettings.json` สำหรับการตั้งค่าใน Production

## 🔧 คำสั่งที่เป็นประโยชน์

```bash
# เข้าไปในโฟลเดอร์โปรเจค
cd MyApplication

# รันในโหมด Development พร้อม hot reload
dotnet watch run

# Build สำหรับ Production
dotnet build --configuration Release

# Publish โปรเจค
dotnet publish --configuration Release

# Clean build artifacts
dotnet clean

# Update packages
dotnet list package --outdated
dotnet add package [PackageName]
```

## 🌐 การ Deploy

### Local Development
- Default URL: `https://localhost:5001`
- HTTP URL: `http://localhost:5000`

### Production Deployment
1. Build โปรเจคในโหมด Release
2. Deploy ไฟล์ใน `MyApplication/bin/Release/net8.0/publish/` ไปยัง server
3. ตั้งค่า Web Server (IIS, Nginx, Apache)
4. Configure SSL certificate

## 🔒 Security Notes

- ใช้ HTTPS ใน Production เสมอ
- อัพเดท dependencies เป็นประจำ
- ตรวจสอบ security headers
- Backup ข้อมูลเป็นประจำ

## 🤝 การพัฒนา

1. Fork repository
2. สร้าง feature branch
3. Commit changes
4. Push ไปยัง branch
5. สร้าง Pull Request

## 📞 การติดต่อ

หากมีปัญหาหรือข้อสงสัย กรุณาติดต่อผู้พัฒนาระบบ

---

**หมายเหตุ**: "ความสุขของสามีอยู่ที่การได้รับอนุญาต... ไม่ใช่การออกไปข้างนอก" 😅