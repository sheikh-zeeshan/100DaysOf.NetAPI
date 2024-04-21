
set /P migrationName=Migration Name: 

dotnet build ./BackendMegaApp.sln
 
dotnet ef migrations add %migrationName%  -p .\src\Infrastructure\MegaApp.Persistance\MegaApp.Persistance.csproj
dotnet ef database update -p .\src\Infrastructure\MegaApp.Persistance\MegaApp.Persistance.csproj -v


@REM   dotnet ef migrations script -o sqlscript.sql -p .\src\Infrastructure\MegaApp.Persistance\MegaApp.Persistance.csproj
