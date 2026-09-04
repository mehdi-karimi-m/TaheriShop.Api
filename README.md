# TaheriShop.Api

Backend API for **TaheriShop**, a modern rewrite of the TaheriShop e-commerce and customer account management system.

The original TaheriShop application was built with ASP.NET Web Forms and Microsoft SQL Server. This project is a new implementation using modern technologies while preserving the core business requirements of the existing system.

## 🚧 Project Status

**Early Development**

The project is currently in the initial architecture and implementation phase.

The goal of the first phase is to rebuild the existing system with modern technologies and migrate the existing data into the new application.

---

## 🎯 Project Goals

The main goals of this project are:

- Replace the legacy ASP.NET Web Forms application with ASP.NET Core.
- Provide a clean and maintainable RESTful API.
- Preserve the existing core business logic and workflows.
- Support migration of existing SQL Server data.
- Provide a solid foundation for future development.
- Keep the architecture simple, understandable, and scalable.
- Make the codebase easy to maintain and work with using AI coding agents.

---

## 🛠️ Technology Stack

The planned technology stack includes:

- **ASP.NET Core Web API**
- **C#**
- **Entity Framework Core**
- **Microsoft SQL Server**
- **REST API**
- **JWT Authentication**
- **Swagger / OpenAPI**

Additional technologies and libraries may be introduced as the project evolves.

---

## 💼 Core Business Features

TaheriShop is primarily focused on managing customers, orders, payments, and customer account balances.

The system is expected to support:

### Customers

- Customer accounts
- Authentication and authorization
- Customer profile
- Customer order history
- Customer financial/account information

### Products

- Product management
- Product information
- Product availability
- Dynamic product management through the administration system

### Orders

- Creating and managing customer orders
- Order items
- Order status
- Order history
- Returned orders / returned items

### Payments

Customers may pay for their orders in installments.

The administration system should allow an operator to:

- Register customer payments
- Record payment amounts
- Record payment dates
- Associate payments with customers/orders
- Track outstanding balances

### Customer Account Balance

The system should provide a clear view of a customer's financial status, including:

- Total purchases
- Total payments
- Outstanding debt
- Customer credit / amount owed to the customer
- Transaction history

### Administration

Administrators/operators should be able to manage:

- Customers
- Products
- Orders
- Payments
- Returns
- Customer account transactions

---

## 🏗️ Architecture

The application will use a modern layered architecture.

The architecture will intentionally remain **simple and practical** rather than introducing unnecessary complexity.

The exact project structure will be defined during the initial development phase.

Possible areas include:

```text
TaheriShop.Api
├── Controllers
├── Services
├── Domain
├── Infrastructure
├── Data
├── DTOs
├── Middleware
└── ...