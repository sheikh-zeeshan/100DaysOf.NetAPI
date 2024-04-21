

dotnet new sln -n "BackendMegaApp"

mkdir src
mkdir test
mkdir requests

mkdir src\API
mkdir src\API\Gateway
mkdir src\API\Security
mkdir src\Core
mkdir src\Infrastructure


dotnet new "webapi" -lang "C#" -n "MegaApp.OcelotGateway" -o "src\API\Gateway\MegaApp.OcelotGateway" -controllers "true" -minimal "false"
 
dotnet add .\src\API\Gateway\MegaApp.OcelotGateway\MegaApp.OcelotGateway.csproj package "Ocelot"
@REM -v "13.0.3"

dotnet new "webapi" -lang "C#" -n "MegaApp.YarpGateway" -o "src\API\Gateway\MegaApp.YarpGateway" -controllers "true" -minimal "false"

dotnet new "webapi" -lang "C#" -n "MegaApp.VeritasGateway" -o "src\API\Gateway\MegaApp.VeritasGateway" -controllers "true" -minimal "false"

dotnet new "webapi" -lang "C#" -n "MegaApp.IdentitySecurity" -o "src\API\Security\MegaApp.IdentitySecurity" -controllers "true" -minimal "false"

dotnet new "webapi" -lang "C#" -n "MegaApp.KeycloakSecurity" -o "src\API\Security\MegaApp.KeycloakSecurity" -controllers "true" -minimal "false"

dotnet new "webapi" -lang "C#" -n "MegaApp.HostelManagementAPI" -o "src\API\MegaApp.HostelManagementAPI" -controllers "true" -minimal "false"


dotnet new "classlib" -lang "C#" -n "MegaApp.Application" -o "src\Core\MegaApp.Application"
mkdir src\Core\MegaApp.Application\Exceptions
mkdir src\Core\MegaApp.Application\Interfaces
mkdir src\Core\MegaApp.Application\Mappings
mkdir src\Core\MegaApp.Application\Models
mkdir src\Core\MegaApp.Application\Services
mkdir src\Core\MegaApp.Application\Validators


dotnet new "classlib" -lang "C#" -n "MegaApp.Domain" -o "src\Core\MegaApp.Domain"
mkdir src\Core\MegaApp.Domain\BaseEntity
mkdir src\Core\MegaApp.Domain\Entities
mkdir src\Core\MegaApp.Domain\Exceptions

dotnet new "classlib" -lang "C#" -n "MegaApp.Infrastructure" -o "src\Infrastructure\MegaApp.Infrastructure"
mkdir src\Infrastructure\MegaApp.Infrastructure\Notifications
mkdir src\Infrastructure\MegaApp.Infrastructure\Loggers
mkdir src\Infrastructure\MegaApp.Infrastructure\Authentication

dotnet new "classlib" -lang "C#" -n "MegaApp.Persistance" -o "src\Infrastructure\MegaApp.Persistance"
mkdir src\Infrastructure\MegaApp.Persistance\Context
mkdir src\Infrastructure\MegaApp.Persistance\Repositories
mkdir src\Infrastructure\MegaApp.Persistance\Specifications
mkdir src\Infrastructure\MegaApp.Persistance\Common

dotnet new "xunit" -lang "C#" -n "UnitTests" -o "test\UnitTests"
dotnet new "xunit" -lang "C#" -n "IntegrationTests" -o "test\IntegrationTests"
dotnet new "xunit" -lang "C#" -n "ArchitecturalTests" -o "test\ArchitecturalTests"
dotnet new "xunit" -lang "C#" -n "PerformanceTests" -o "test\PerformanceTests"

@REM dotnet new "apicontroller" -lang "C#" -n "APIGateway" -o "src\API\APIGateway"
@REM dotnet add "d:\Git Source\CleanArch2024\SampleCode\SampleAPI\SampleAPI.csproj" reference "d:\Git Source\CleanArch2024\SampleCode\DataAccess\DataAccess.csproj"
@REM dotnet add "d:\Git Source\CleanArch2024\SampleCode\SampleAPI\SampleAPI.csproj" package "Newtonsoft.Json" -v "13.0.3"


dotnet new editorconfig
dotnet new gitignore
dotnet new nuget.config
dotnet new global.json

@REM dotnet sln BackendMegaApp.sln add (ls -r **/*.csproj)

dotnet sln .\BackendMegaApp.sln add .\src\API\Gateway\MegaApp.OcelotGateway\MegaApp.OcelotGateway.csproj
dotnet sln .\BackendMegaApp.sln add .\src\API\Gateway\MegaApp.YarpGateway\MegaApp.YarpGateway.csproj
dotnet sln .\BackendMegaApp.sln add .\src\API\Gateway\MegaApp.VeritasGateway\MegaApp.VeritasGateway.csproj

dotnet sln .\BackendMegaApp.sln add .\src\API\Security\MegaApp.IdentitySecurity\MegaApp.IdentitySecurity.csproj
dotnet sln .\BackendMegaApp.sln add .\src\API\Security\MegaApp.KeycloakSecurity\MegaApp.KeycloakSecurity.csproj

dotnet sln .\BackendMegaApp.sln add .\src\API\MegaApp.HostelManagementAPI\MegaApp.HostelManagementAPI.csproj

dotnet sln .\BackendMegaApp.sln add .\src\Core\MegaApp.Application\MegaApp.Application.csproj
dotnet sln .\BackendMegaApp.sln add .\src\Core\MegaApp.Domain\MegaApp.Domain.csproj
dotnet sln .\BackendMegaApp.sln add .\src\Infrastructure\MegaApp.Infrastructure\MegaApp.Infrastructure.csproj
dotnet sln .\BackendMegaApp.sln add .\src\Infrastructure\MegaApp.Persistance\MegaApp.Persistance.csproj

dotnet sln .\BackendMegaApp.sln add .\test\UnitTests\UnitTests.csproj
dotnet sln .\BackendMegaApp.sln add .\test\IntegrationTests\IntegrationTests.csproj
dotnet sln .\BackendMegaApp.sln add .\test\ArchitecturalTests\ArchitecturalTests.csproj
dotnet sln .\BackendMegaApp.sln add .\test\PerformanceTests\PerformanceTests.csproj


@REM dotnet add .\src\API\Security\MegaApp.IdentitySecurity\MegaApp.IdentitySecurity.csproj reference .\src\Core\MegaApp.Application\MegaApp.Application.csproj
@REM dotnet add .\src\API\Security\MegaApp.KeycloakSecurity\MegaApp.KeycloakSecurity.csproj reference .\src\Core\MegaApp.Application\MegaApp.Application.csproj
@REM dotnet add .\src\API\Security\MegaApp.KeycloakSecurity\MegaApp.KeycloakSecurity.csproj reference .\src\Core\MegaApp.Application\MegaApp.Application.csproj



echo "### http request" > .\requests\APIrequest.http

echo "ReadMe" > \APIrequest.http
dotnet build .\BackendMegaApp.sln



@rem -------------------------------references
@rem dotnet add "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Core\MegaApp.Application\MegaApp.Application.csproj" reference "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Core\MegaApp.Domain\MegaApp.Domain.csproj"
@rem dotnet add "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Infrastructure\MegaApp.Persistance\MegaApp.Persistance.csproj" reference "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Core\MegaApp.Domain\MegaApp.Domain.csproj"
@rem dotnet add "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Infrastructure\MegaApp.Persistance\MegaApp.Persistance.csproj" reference "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Core\MegaApp.Application\MegaApp.Application.csproj"
@rem dotnet add "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Infrastructure\MegaApp.Infrastructure\MegaApp.Infrastructure.csproj" reference "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Infrastructure\MegaApp.Persistance\MegaApp.Persistance.csproj"
@rem dotnet add "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Infrastructure\MegaApp.Infrastructure\MegaApp.Infrastructure.csproj" reference "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Core\MegaApp.Application\MegaApp.Application.csproj"
@rem dotnet add "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\API\MegaApp.HostelManagementAPI\MegaApp.HostelManagementAPI.csproj" reference "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Core\MegaApp.Application\MegaApp.Application.csproj"
@rem dotnet add "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\API\MegaApp.HostelManagementAPI\MegaApp.HostelManagementAPI.csproj" reference "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Infrastructure\MegaApp.Infrastructure\MegaApp.Infrastructure.csproj"
@rem -------------------------------references



@REM fluentassertions , 
@REM moq
@REM packages for each project
@REM  dotnet add "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Infrastructure\MegaApp.Persistance\MegaApp.Persistance.csproj" reference "d:\Git Source\CleanArch2024\100DaysOfCleanArch\src\Core\MegaApp.Domain\MegaApp.Domain.csproj"
@REM dotnet ef dbcontext scaffold -c MyContext -o Model "Data Source=127.0.0.1;Initial Catalog=MyDb;persist security info=True;User id=sa; Password=*****" Microsoft.EntityFrameworkCore.SqlServer —-force


@REM dotnet new "classlib" -lang "C#" -n "MegaApp.BogusData" -o "src\Infrastructure\MegaApp.BogusData"       
@REM dotnet sln .\BackendMegaApp.sln add .\src\Infrastructure\MegaApp.BogusData\MegaApp.BogusData.csproj
@REM dotnet add "d:\Git Source\CleanArch2024\100DaysOf.NetAPI\src\Infrastructure\MegaApp.BogusData\MegaApp.BogusData.csproj" reference "d:\Git Source\CleanArch2024\100DaysOf.NetAPI\src\Core\MegaApp.Domain\MegaApp.Domain.csproj"