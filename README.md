# TechStockManager

Desktop application for managing a computer store — orders, products, customers, payments and more.

## Technologies
- C# Windows Forms (.NET)
- MySQL
- iTextSharp (PDF export)
- ClosedXML (Excel export)
- BCrypt (password hashing)

## Requirements
- Visual Studio 2022
- MAMP / XAMPP (MySQL server)
- .NET 6+

## Setup
1. Start MAMP and make sure MySQL is running
2. Open phpMyAdmin: http://localhost:8888/phpMyAdmin
3. Create database `computeruniverse`
4. Import `database/computeruniverse_en.sql`
5. Copy `DB_example.cs` → `DB.cs` and fill in your credentials
6. Open `TechStockManager.sln` in Visual Studio
7. Restore NuGet packages (Build → Restore NuGet Packages)
8. Run the project

## Features
- Product management (add, edit, delete, stock)
- Order and order details management
- Customer and manufacturer management
- Payment tracking
- PDF and Excel export
- Dark/Light theme
- Role-based access (admin, computer, mobile, audio, peripheral, television)
