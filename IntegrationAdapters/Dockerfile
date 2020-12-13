FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
RUN useradd -u 1234 nonrootuser
USER nonrootuser
LABEL maintainer="vladimir.budjen@uns.ac.rs"
COPY . .
EXPOSE 60998
ENV ASPNETCORE_URLS="http://*:60998"
ENTRYPOINT ["dotnet", "IntegrationAdapters.dll"]
