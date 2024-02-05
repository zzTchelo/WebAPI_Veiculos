# Vehicle Management API (C# and SQL Server)

##Atention!!!
You must need to change the string connection in Web.config file

## Overview
This is a simple CRUD (Create, Read, Update, Delete) API for managing vehicle information, implemented in C# using ASP.NET Core and connected to a SQL Server database. The API allows users to perform operations such as adding new vehicles, retrieving vehicle details, updating existing records, and deleting vehicles from the system.

## Technologies Used
- C#
- ASP.NET Core
- SQL Server
- RESTful API principles

## API Endpoints

### 1. Get All Vehicles
- **Endpoint:** `GET /api/veiculos`
- **Description:** Retrieve a list of all vehicles in the system.

### 2. Get Vehicle by ID
- **Endpoint:** `GET /api/veiculos/{id}`
- **Description:** Retrieve detailed information about a specific vehicle using its unique identifier.

### 3. Add New Vehicle
- **Endpoint:** `POST /api/veiculos`
- **Description:** Add a new vehicle to the system.
- **Request Body:**
  ```json
  {
    "marca": "Toyota",
    "nome": "Camry",
    "anoModelo": 2022,
    "dataFabricacao": "2022-02-05T12:00:00", // Use the appropriate date format
    "valor": 25000.50,
    "opcionais": "Leather Seats, Sunroof"
  }


### 4. Update Vehicle
- **Endpoint:** `PUT /api/vehicles/{id}`
- **Description:** Update information for a specific vehicle.
- **Request Body:**
  ```json
  {
    "marca": "Chevrolet",
    "nome": "Astra",
    "anoModelo": 2010,
    "dataFabricacao": "2010-04-01T12:00:00", // Use the appropriate date format
    "valor": 30000.00,
    "opcionais": "Leather Seats, Sunroof"
  }


### 5. Delete Vehicle
- **Endpoint:** `DELETE /api/vehicles/{id}`
- **Description:** Delete a specific vehicle from the system.

## Getting Started
1. Clone the repository to your local machine:
	```bash
	git clone https://github.com/your-username/vehicle-management-api-csharp.git

2. Open the solution in Visual Studio or your preferred C# IDE.

3. Configure the database connection in the `Web.config` file.

4. Build and run the application.

## Database Setup
Make sure to set up a SQL Server database and update the connection string in the `Web.config` file.

## Contributing
Contributions are welcome! If you'd like to improve the API, add new features, or fix any issues, feel free to submit a pull request.

1. Fork the repository.
2. Create a new branch: `git checkout -b feature/new-feature`.
3. Make your changes and commit them: `git commit -m 'Add new feature'`.
4. Push to the branch: `git push origin feature/new-feature`.
5. Submit a pull request.

## License
This project is licensed under the MIT License

## Contact
If you have any questions or suggestions, feel free to contact me by LinkedIn
