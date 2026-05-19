# TechStockManager

This project was developed as a 3nd-year university assignment.

Desktop application for managing a computer store — orders, products, customers, payments and more.

## Overview

This project is an automated warehouse management system for an electronics store.  
The system is designed to manage inventory, orders, payments, and department operations within a centralized warehouse structure.

The application helps optimize warehouse processes, improve inventory tracking, and simplify order management for stores that sell consumer electronics such as TVs, laptops, and computer peripherals.

---

## Features

The application allows users to:

- Manage warehouse inventory and product categories
- Store detailed product information:
  - manufacturer
  - model
  - technical specifications
  - price
  - stock quantity
- Create and process customer orders
- Track order status and payment information
- Manage multiple warehouse departments
- Control user access with role-based authorization
- Monitor stock movement and product availability
- Generate reports and analytics for warehouse operations
- Access the system through cloud-based infrastructure

---

## System Roles

### Department Employee
- Manage products within their department
- Process and update orders
- View inventory information

---

### Administrator
- Manage the entire warehouse system
- Control payments and orders
- Monitor department activity
- Access analytics and reports

---

## Technologies
- C# Windows Forms (.NET)
- MySQL
- iTextSharp (PDF export)
- ClosedXML (Excel export)
- BCrypt (password hashing)

---

## Requirements
- Visual Studio 2022
- MAMP / XAMPP (MySQL server)
- .NET 6+

---

## Features
- Product management (add, edit, delete, stock)
- Order and order details management
- Customer and manufacturer management
- Payment tracking
- PDF and Excel export
- Dark/Light theme
- Role-based access (admin, computer, mobile, audio, peripheral, television)

---

## Screenshots

## Authentication
<img width="407" height="345" alt="image" src="https://github.com/user-attachments/assets/b12942bc-d73d-46e6-b0df-e4fe40d52453" />

## Main menu
<img width="820" height="390" alt="image" src="https://github.com/user-attachments/assets/998c7fe3-467f-4220-8a72-6e2b60b3e424" />

## Order Management
<img width="1024" height="471" alt="image" src="https://github.com/user-attachments/assets/ae0b5c3d-bde1-4baa-b4f8-2a52954e196f" />

## Product Management
<img width="1050" height="474" alt="image" src="https://github.com/user-attachments/assets/ff7f3e57-2ac8-4d68-92d1-f10b67dbe95c" />


---

## Setup
1. Start MAMP and make sure MySQL is running
2. Open phpMyAdmin: http://localhost:8888/phpMyAdmin
3. Create database `computeruniverse`
4. Import `database/computeruniverse_en.sql`
5. Copy `DB_example.cs` → `DB.cs` and fill in your credentials
6. Open `TechStockManager.sln` in Visual Studio
7. Restore NuGet packages (Build → Restore NuGet Packages)
8. Run the project

---


