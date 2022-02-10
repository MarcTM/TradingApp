To download and run this app follow the next steps:
> Development
1. Download the repository in your local computer.
2. In the api (Trading repository), go to appsettings.Development.json, and add the following configuration and fill it with your own information:
**{
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
}**
3. Run the program from Visual Studio aapplication, choosing Trading.Web.Api as the Startup Project.
