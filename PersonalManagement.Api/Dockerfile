
FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 80 
EXPOSE 443
COPY bin/release/net5.0/publish app/
ENTRYPOINT ["dotnet","app/PersonalManagement.Api.dll"]