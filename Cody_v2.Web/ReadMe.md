
#add migrations
 dotnet ef --startup-project ../cody_v2.web/ migrations add new-migration-Name

#update db
dotnet ef --startup-project ../cody_v2.web/ database update