# Trading App
This is a simple trading application done during the Capgemini .NET Bootcamp. The project consists in a trading app, so a user can add Stocks to his wallet. The stocks were given by an external api, Alphavantage, and then introduced in my database every time the app starts, to ensure new stocks introduced in their api are introduced in my database too. Even though the application does almost nothing, I have been trying to implement most of the things we have been learning in this app, like Design Patterns, SOLID Principles, etc, so this is the important part of this project.

## ASP.Net Core Web Api
This is the Api (backend). It is done with DDD Architecture. <br>
![DDD Architecture](http://1.bp.blogspot.com/-f9QYYWLc1Uk/UoKzpDHYkkI/AAAAAAAACA4/OD1bq9MLYFY/s1600/DDD_png_pure.png)

### Specifications:
- IIS
- Visual Studio 2022
- .NET 5

#### Another important specifications
- Jwt
- Api versioning
- Logger
- DbContext
- Fluent validations
- Swagger documentation
- Dependency injection
- Configuration variables
- HttpClient
- Mapping: **Dto** <-> **Entity** <-> **Data Model**

<hr>

## ASP.NET Core Web App (MVC)
This is de MVC Client (frontend). The user will navigate this app, that will request all the information to our Api.

### Specifications:
- IIS
- Visual Studio 2022
- .NET 5

#### Another important specifications
- Dependency injection
- Configuration variables
- HttpClient
- Mapping: **ViewModel <-> Dto**
- Session variables
- Razor
- 
## MySQL Database
The Api is using MySql database. When the app starts, it receives the stocks from Alphavantage and insert them into MySql database.
In my case, I am using a MySql located in my heroku.

<hr>

### To download and run this app follow the next steps:
> Development
1. Download the repository in your local computer.
2. In the API (Trading repository), go to appsettings.Development.json, and add the following configuration with your own information:
````
{
  "ConnectionStrings": {
    "LocalWebApiDatabase": "Your database configuration"
  },
  "JsonWebTokenKeys": {
    "ValidateIssuerSigningKey": true,
    "IssuerSigningKey": "64A63153-11C1-4919-9133-EFAF99A9B456",
    "ValidateIssuer": true,
    "ValidIssuer": "Your Issuer URL",
    "ValidateAudience": true,
    "ValidAudience": "Your Audience URL",
    "RequireExpirationTime": true,
    "ValidateLifetime": true
  },
  "ApiStocksUrl": "https://www.alphavantage.co/",
  "StockAPIKey": "Your Alphavantage API key"
}
````
3. In the MVC (TradingClient repository), go to appsettings.Development.json, and add the following configuration with your own information:
````
{
  "ConnectionStrings": {
    "TradingApiURL": "https://localhost:44364/api/v1.0/"
  }
}
````
4. Run the API from Visual Studio, choosing Trading.Web.Api as the Startup Project.
5. Run the MVC from Visual Studio, choosing TradingClient.Presentation.Website as the Startup Project.
