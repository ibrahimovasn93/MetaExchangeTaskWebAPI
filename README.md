---
Title: "MetaExchangeTaskWebAPI"
Authors: "Solmaz Ibrahimova"
Output: JSON data
---

### Setup Instructions

To set up and run the MetaExchangeTaskWebAPI project, please follow the below steps:

1. Clone the repository or download the project files to your computer.

2. Open the solution in your preferred code editor (e.g., Visual Studio, Visual Studio Code).

3. Ensure that you have the necessary dependencies installed, including .NET Core SDK.

4. Build the solution to restore dependencies and compile the project.

5. Update the file paths and configurations as per your environment and requirements:
   - Ensure that the file paths for JSON data and other resources are correctly configured.
   - Adjust any environment-specific configurations, such as HTTPS settings and Swagger endpoints.

6. Run the application:
   - Build and run the application from your IDE or terminal.
   - Verify that the application starts successfully and is ready to accept requests.

### Usage

Once the MetaExchangeTaskWebAPI project is running, you can interact with it using HTTP requests. Here's how you can execute orders:

1. **Send Order Execution Requests**:
   - Use HTTP POST requests to the `/api/Order/execute-order` endpoint.
   - Provide valid JSON data representing the order request, including order type and amount.

2. **Handle Responses**:
   - Upon successful execution, the API returns the execution plan in JSON format.
   - Handle response codes and messages to address any errors or exceptions during order execution.

### Questions?

Please let me know if you have any questions or encounter any issues. 
