# .NET CORE 8 MVC APPLICATION (ABC MONEY TRANSFER)

### Overview
The project is designed to stimulate a money transfer application. The main features include:
- NRB API Integration for exchange rates
- Money transfer functionality from MYR to NPR.
- Login and registration
- Tranfer details report

### Tech stack
- .NET Core 8 MVC
- MS-SQL


## Setup Instructions

### Prerequisites
Before you begin, ensure you have met the following requirements:
- The system must have dotnet environment installed.

### Installation steps

1. **Clone the repository**
   ```bash
     git clone https://github.com/rrieshavv/TaskApp.git
     cd TaskApp/
   ```

2. **Restore the database (inficaretask.bak) using the SQL Server Management Studio.**
3. **Update the connection string in appsettings.json.**
    ```json
    "ConnectionStrings": {
        "Default": "Data Source=.;Initial Catalog=inficaretask;Persist Security Info=True;User ID=sa;Password=***;Encrypt=False;Trust Server Certificate=True"
    }
    ```
4. **Run the application with the following command.**
    ```bash
        cd Application/
        dotnet build
        dotnet run
    ```
      **The application will start at http://localhost:5138** 
### Highlights

- Login Page
  
  ![image](https://github.com/user-attachments/assets/a0516ed7-101a-4f37-b4ad-568933a88657)

- Register Page

  ![image](https://github.com/user-attachments/assets/80ceeda2-b8e2-40fa-b044-062505d9c53b)

- Home Page

  ![image](https://github.com/user-attachments/assets/c27cdf4a-6e58-4e16-a32e-1f315f86f924)

- Transfer Page

  ![image](https://github.com/user-attachments/assets/6f09d968-1bfc-4450-958f-88736ee820a4)

- Transfer Report Page

  ![image](https://github.com/user-attachments/assets/86b7fc97-2fbb-4604-93ba-04147398288a)




