FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
RUN useradd -u 1234 nonrootuser
USER nonrootuser
WORKDIR /app
COPY . .
EXPOSE 8080
ENV PORT 8080
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApplication.dll