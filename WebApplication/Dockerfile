FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
RUN useradd -u 1234 nonrootuser
USER nonrootuser
WORKDIR /app
COPY . .
EXPOSE 49900
ENV ASPNETCORE_URLS="http://*:49900"
ENTRYPOINT ["dotnet", "WebApplication.dll"]