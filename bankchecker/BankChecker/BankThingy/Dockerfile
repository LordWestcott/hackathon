FROM --platform=linux/amd64 public.ecr.aws/lambda/dotnet:6 as base
WORKDIR /var/task
EXPOSE 8080
EXPOSE 4431
ENV ASPNETCORE_URLS=http://*:8080


FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BankThingy/BankThingy.csproj", "BankThingy/"]
COPY ["Services/Services.csproj", "Services/"]
RUN dotnet restore "BankThingy/BankThingy.csproj"
COPY . .
WORKDIR "/src/BankThingy"
RUN dotnet build "BankThingy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankThingy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /var/task
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankThingy.dll"]
