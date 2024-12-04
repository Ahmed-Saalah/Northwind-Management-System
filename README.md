# Northwind Management System

## Description

The **Northwind Management System** is a desktop application built using **C#** and **Windows Forms**. It is designed to manage customer and order data in a business context, such as a retail or wholesaler scenario. This project uses **Entity Framework** for data access, and the application provides features such as customer management, and order processing. The application follows the **Data Access Layer (DAL)** design pattern to abstract and manage interactions with the database efficiently.

## Features

- **Customer Management**: Add, update, and delete customer records.
- **Order Management**: Create and manage orders for customers.
- **Order Status Management**: Track the status of orders (e.g., processing, shipped, delivered).
- **Data Persistence**: Data is stored in a **SQL Server** database, and changes are persisted using **Entity Framework**.

## Design Patterns

### Data Access Layer (DAL)

The application follows the **Data Access Layer (DAL)** design pattern to abstract the interaction between the business logic and the database. This pattern ensures that the database access code is encapsulated in a separate layer, making the application more modular, maintainable, and testable. The DAL is responsible for:

- **CRUD Operations**: Adding, updating, deleting, and retrieving data.
- **Database Abstraction**: Abstracting the complexities of database operations, such as connection management and query execution.
- **Business Logic Separation**: Isolating the data access logic from the rest of the application.

### Other Design Patterns Used:

- **Repository Pattern**: A repository is used to provide a collection-like interface to the DAL, making it easier to perform operations on data entities.
- **Unit of Work Pattern**: Used to coordinate changes to multiple repositories and ensure that all changes are committed or rolled back as a single transaction.

## Technologies Used

- **C#**: The primary programming language used to build the application.
- **Windows Forms**: User interface framework for building desktop applications.
- **Entity Framework Core**: ORM for interacting with the database and implementing the DAL.
- **SQL Server**: Database system used to store customer and order data.
- **GitHub**: Version control to manage project code.
