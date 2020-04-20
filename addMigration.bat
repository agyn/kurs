set Configuration=%2
if "%Configuration"=="" set Configuration="Development"
dotnet ef migrations add %1 --project Kurs.Shared.Data --startup-project Kurs.Identity.Api --configuration %Configuration
