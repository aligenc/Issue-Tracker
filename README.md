# Issue Tracker Web API with React.js Frontend

## Project Overview
This project is an issue tracker web application built with ASP.NET Core Web API for the backend and React.js with Bootstrap for the frontend. It provides a platform for managing and tracking tasks or issues within an organization.

## Tech Stack
- Backend: ASP.NET Core 8 Web API
- Frontend: React.js, Bootstrap
- Database: MongoDB

## Installation
1. Clone the repository.
2. Install the necessary dependencies for the backend and frontend.
3. Configure the MongoDB connection string in the `appsettings.json` file.
4. Run the backend API and the frontend application. (I will share the frontend app soon)

## Usage
- The backend API provides the following endpoints for managing issues:
  - GET `/api/issues` - Retrieve all issues.
  - GET `/api/issues/{id}` - Retrieve a specific issue by ID.
  - POST `/api/issues` - Create a new issue.
  - PUT `/api/issues/{id}` - Update an existing issue.
  - DELETE `/api/issues/{id}` - Delete an issue.
  - Refer to the API documentation for detailed usage instructions.

- The frontend application provides a user interface for interacting with the issue tracker system.
  - Users can view, create, update, and delete issues using the intuitive UI.
  - Screenshots or a live demo can be added here.

## Authentication

The Issue Tracker API uses token-based authentication with JWT (JSON Web Tokens) to secure API endpoints. To access protected endpoints, users need to obtain a token by providing their username and API key.

To obtain a token, send a POST request to the `/api/account/login` endpoint with the following JSON payload:

`{  
  "username": "your-username", 
  "apiKey": "your-api-key"
}`

The API will respond with a token that should be included in the Authorization header of subsequent API requests. Set the header as follows: `Authorization: Bearer <token>`

## Folder Structure
- `Models/` - Contains the models or entities used in the application.
- `Controllers/` - Contains the backend API controllers that handle incoming requests and produce responses.
- `Repositories/` - Contains the repositories that interact with the database and perform CRUD operations.
- `Enums/` - Contains the enums used in the application.

## Development Environment and Tools
- IDE: Visual Studio
- MongoDB management tool: MongoDB Compass

## Testing
- The backend API includes unit tests using xUnit and Moq.
- The tests cover various scenarios to ensure the functionality of the API endpoints.
- To run the tests, navigate to the test project directory and execute the following command: `dotnet test`.

## Contribution
- Contributions are welcome! If you would like to contribute to the project, follow these steps:
  1. Fork the repository.
  2. Create a new branch for your feature or bug fix.
  3. Make the necessary changes and commit them.
  4. Open a pull request with a detailed description of your changes.

## License
Giving a star required! :D After that, you can use all code without any restrictions ;) 

