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
- Windows OS
- The system must have dotnet environment installed.
- [Dependencies] (e.g., node package manager (npm))

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
    },
    ```
4.
