# Online Store

An **ASP.NET Core 6** web application demonstrating an N-Layer (Clean) Architecture, featuring an e-commerce workflow: product browsing, shopping cart, and checkout.

## Table of Contents

- [Architecture](#architecture)  
- [Features](#features)  

---

## Architecture

This solution follows an N-Layer pattern to separate concerns:

1. **Store.DAL**  
   - Entity Framework Core, data models & migrations  
   - Repository implementations  

2. **Store.BLL**  
   - Business services and DTOs  
   - Validation and domain logic  

3. **Store.WEB**  
   - ASP.NET Core MVC project  
   - Controllers, Views (Razor), ViewModels  
   - Dependency injection and middleware configuration  

---

## Features

- **Product Catalog**: List, search, and filter products  
- **Shopping Cart**: Add, remove, update item quantities  
- **Checkout Workflow**: Enter shipping/billing info, place orders  
- **User Accounts** (optional): Registration, login, profile  
- **Admin Panel** (optional): CRUD for products & categories  
- **Responsive UI** with Bootstrap (or your chosen CSS framework)  
