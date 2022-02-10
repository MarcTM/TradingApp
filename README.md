My specifications:
> ASP.Net Core Web Api
- IIS
- Visual Studio 2022
- .NET 5

> ASP.NET Core Web App (MVC)
- IIS
- Visual Studio 2022
- -NET 5

To download and run this app follow the next steps:
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
