# Rent A Car

A three-layer web application for managing car rentals, built with ASP.NET Core MVC and Entity Framework.

## Table of Contents

- [Overview](#overview)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Features](#features)
- [Getting Started](#getting-started)
- [Default Accounts](#default-accounts)
- [Documentation](#documentation)

---

## Overview

Rent A Car is a system that serves as a connection between users and a car rental company. Users can browse available cars and make reservation requests, while administrators can manage the entire system.

---

## Technologies

- **ASP.NET Core 9.0 MVC**
- **Entity Framework Core 9.0**
- **ASP.NET Core Identity**
- **SQL Server (LocalDB)**
- **Bootstrap 5**
- **DocFX** (for API documentation)

---

## Project Structure

```
RentACar/
├── RentACar.Data/          # Data layer - models, DbContext, migrations
│   ├── Models/
│   │   ├── ApplicationUser.cs
│   │   ├── Car.cs
│   │   └── Reservation.cs
│   ├── Seeding/
│   │   └── DbSeeder.cs
│   └── AppDbContext.cs
│
├── RentACar.Services/      # Service layer - business logic
│   ├── Interfaces/
│   │   ├── ICarService.cs
│   │   ├── IReservationService.cs
│   │   └── IUserService.cs
│   └── Implementations/
│       ├── CarService.cs
│       ├── ReservationService.cs
│       └── UserService.cs
│
└── RentACar.Web/           # Presentation layer - controllers, views
    ├── Controllers/
    │   ├── AccountController.cs
    │   ├── CarsController.cs
    │   ├── ReservationsController.cs
    │   └── UsersController.cs
    └── Views/
        ├── Account/
        ├── Cars/
        ├── Reservations/
        └── Users/
```

---

## Features

### User Management
- User registration and login with authentication
- Two roles: **Admin** and **User**
- Unique validation for EGN, username and email
- Admin can create, view, edit and delete users

### Car Management (Admin only)
- Full CRUD operations for cars
- Car details: brand, model, year, seats, description, price per day
- Schedule view showing when a car is booked

### Reservations
- Users select dates and see available cars for those dates
- Users can make reservation requests
- Admins can view all reservations and approve them
- A car cannot be reserved if it is already booked for the selected period
- Reservations with past dates are not allowed

### Access Control
- Unauthenticated users are redirected to the login page
- Admin-only pages are protected with role-based authorization

---

## Getting Started

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- SQL Server LocalDB (included with Visual Studio)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/Nik0la074/RentACar.git
cd RentACar
```

2. Install the correct EF Core tools version:
```bash
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --version 9.0.3
```

3. Restore packages:
```bash
dotnet restore
```

4. Apply database migrations:
```bash
dotnet ef database update --project RentACar.Data --startup-project RentACar.Web
```

5. Run the application:
```bash
dotnet run --project RentACar.Web
```

6. Open your browser at `https://localhost:5001`
---

## Default Accounts

| Role | Username | Password |
|------|----------|----------|
| Admin | admin | Admin@123 |

---

## Documentation

API documentation is generated using DocFX from the XML summary comments in the code.

### View Documentation

Start the documentation server:
```bash
docfx C:\path\to\RentACar\docfx.json --serve
```

Then open `http://localhost:8080` in your browser.

---

## Validation Rules

- EGN must be exactly 10 digits
- Email must be in valid format
- Phone number must be in valid format
- Passwords must be at least 6 characters
- EGN, username and email must be unique across all users
- Reservation start date cannot be in the past
- Reservation end date must be after start date
