# 100DaysOf.NetAPI
100 days of code.

#### Day 1 - initial project strcture using clean architecture is created

#### Day 2 - read me file is stream lined
    Repository classes are updated
    
#### Day 3 - Work on Persistance layer
1. Adding warning level in projects of Core and Infra layer

#### Day 4 - Bogus data generation
1. bogus api is used
2. relationship updated where required
3. missing parts are there (createdby, updatedby)
4. data generated with random no of records
5. few fields are reman empty

#### Day 5 - Application layer - CQRS-Mapster - Validations
implementing CQRS and mapster for object mapping
fluent validations is added, some validations and business checks are added
feature folder under application project have command and query classes

#### Day 6 - Infrastrcture layer - thrid party services
third party services
Email service
logger service
    -> correlation id - pending
    -> serilog + enhancers + sinks - pending
    -> seq - pending
    -> 
Information Logs => standard log level used wjen something has happened as exepcted
Debug Logs => a very imformational log level that is more than we might need for every day use
Warning Logs => some thing which is not error but is not normal has happened
Error => error or exception or shome thing unexpected happened

#####Characteristics of split queries
While split query avoids the performance issues associated with JOINs and cartesian explosion, it also has some drawbacks:

a. While most databases guarantee data consistency for single queries, no such guarantees exist for multiple queries. If the database is updated concurrently when executing your queries, resulting data may not be consistent. You can mitigate it by wrapping the queries in a serializable or snapshot transaction, although doing so may create performance issues of its own. For more information, see your database's documentation.
b. Each query currently implies an additional network roundtrip to your database. Multiple network roundtrips can degrade performance, especially where latency to the database is high (for example, cloud services).
c. While some databases allow consuming the results of multiple queries at the same time (SQL Server with MARS, Sqlite), most allow only a single query to be active at any given point. So all results from earlier queries must be buffered in your application's memory before executing later queries, which leads to increased memory requirements.
d. When including reference navigations as well as collection navigations, each one of the split queries will include joins to the reference navigations. This can degrade performance, particularly if there are many reference navigations. Please upvote #29182 if this is something you'd like to see fixed

Define entities
define relation ships
create context class
create migration
implement generic repository pattern
TODO: implement UOW and specification pattern
default query behaviour in context class
extension method for NOTRacking
use split query instead of Include
 


##### Links used in this training

1. https://www.youtube.com/@MohamadLawand/playlists
2.https://www.youtube.com/@learnnnjoy...
3.https://github.com/VeritasSoftware/AspNetCore.ApiGateway
4.https://github.com/trevoirwilliams/HR.LeaveManagement.Clean
5.https://marketplace.visualstudio.com/items?itemName=codechecker.vscode-codechecker
6.https://marketplace.visualstudio.com/items?itemName=code-inspector.code-inspector-vscode-plugin
7.https://www.learnentityframeworkcore.com/configuration/fluent-api/isrowversion-method
8.https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=fluent-api
9.https://learn.microsoft.com/en-us/ef/core/saving/concurrency?tabs=fluent-api
10.https://learn.microsoft.com/en-us/ef/core/cli/dotnet
11.https://www.learnentityframeworkcore5.com/
12.https://www.learnentityframeworkcore.com/model
13.https://www.entityframeworktutorial.net/efcore/raw-sql-queries-in-ef-core.aspx
14.https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli
15.https://dev.to/ssukhpinder/20-essential-entity-framework-core-tips-optimize-performance-streamline-queries-and-enhance-data-handling-1jmb?fbclid=IwAR0rwEhfzZPOGJjx4PWqUKVMO_bM3yq5WhICvmz6X0wQ5ZbBd6JY7tq2KNs
21.https://www.tutorialsteacher.com/core
22.https://devblogs.microsoft.com/dotnet/resilience-and-chaos-engineering/
23. https://devblogs.microsoft.com/dotnet/azure-migrate-app-and-code-assessment-tool-release/
24. https://c4model.com/#Tooling
25. https://structurizr.com/

//editor.defaultFormatter
//dotnet tool install --global dotnet-ef
//dotnet tool update --global dotnet-ef

 
//  dotnet ef migrations add finalDAL  -p .\src\Infrastructure\MegaApp.Persistance\MegaApp.Persistance.csproj
//  dotnet ef database update -p .\src\Infrastructure\MegaApp.Persistance\MegaApp.Persistance.csproj -v
//  dotnet ef migrations script -o sqlscript.sql -p .\src\Infrastructure\MegaApp.Persistance\MegaApp.Persistance.csproj
// dotnet build d:\Git Source\CleanArch2024\100DaysOf.NetAPI\test\MegaApp.DataGenerator\MegaApp.DataGenerator.csproj ////property:GenerateFullPaths=true /consoleloggerparameters:NoSummary 

