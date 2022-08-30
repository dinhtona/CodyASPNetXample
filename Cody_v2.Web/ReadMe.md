#Open the Developer PowerShell
Tool -> Command Line -> Developer PowerShell
#Run the code bellow
#Restore nuget
dotnet restore
#move to this folder
cd cody_v2.Repositories
#add migrations
dotnet ef --startup-project ../cody_v2.web/ migrations add New-migration-Name
#update db
dotnet ef --startup-project ../cody_v2.web/ database update

