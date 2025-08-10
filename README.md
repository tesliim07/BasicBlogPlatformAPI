# BasicBlog.Platform

A simple ASP.NET Core Web API for a blogging platform. This project demonstrates a clean architecture using repositories, services, and Entity Framework Core for data access.

## Features

- Author and BlogPost management via RESTful endpoints
- SQL Server database integration
- Dependency Injection for repositories and services
- Swagger UI for API documentation and testing

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Setup

1. **Clone the repository**
   ```sh
   git clone https://github.com/yourusername/BasicBlog.Platform.git
   cd BasicBlog.Platform
   ```

2. **Configure the database**
   - Update the `BasicBlogPlatformConnection` string in `appsettings.json` with your SQL Server details.

3. **Apply migrations**
   ```sh
   dotnet ef database update
   ```

4. **Run the application**
   ```sh
   dotnet run --project BasicBlog.Platform
   ```

5. **Access Swagger UI**
   - Navigate to `https://localhost:5001/swagger` in your browser to explore and test the API.

## Project Structure

- `context/` - Entity Framework Core DbContext
- `Repository/` - Data access layer
- `Services/` - Business logic layer
- `Controllers/` - API endpoints

## Usage

- Use Swagger UI or tools like Postman to interact with the API or click the website link available in the About section.
- Endpoints are available for managing authors and blog posts.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to do

## Notes
This project is for educational/demo purposes only. Some security measures are intentionally not implemented and it should **not** be used as-is in production.  
If you plan to deploy publicly, add at minimum: authentication/authorization, input validation, rate limiting, and proper secret management.
