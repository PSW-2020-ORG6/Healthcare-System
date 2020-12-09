FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
RUN useradd -u 1234 nonrootuser
USER nonrootuser
LABEL maintainer="vladimir.budjen@uns.ac.rs"
COPY . .
EXPOSE 8080
ENV PORT 8080
CMD ASPNETCORE_URLS=http://*:$PORT dotnet IntegrationAdapters.dll
