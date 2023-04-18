dotnet --version
dotnet tool install --global dotnet-ef --version 5.0.0
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run