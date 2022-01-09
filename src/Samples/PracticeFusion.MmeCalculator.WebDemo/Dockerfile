FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Samples/PracticeFusion.MmeCalculator.WebDemo/PracticeFusion.MmeCalculator.WebDemo.csproj", "Samples/PracticeFusion.MmeCalculator.WebDemo/"]
RUN dotnet restore "Samples/PracticeFusion.MmeCalculator.WebDemo/PracticeFusion.MmeCalculator.WebDemo.csproj"
COPY . .
WORKDIR "/src/Samples/PracticeFusion.MmeCalculator.WebDemo"
RUN dotnet build "PracticeFusion.MmeCalculator.WebDemo.csproj" -c Release -o /server/build

FROM build AS publish
WORKDIR "/src/Samples/PracticeFusion.MmeCalculator.WebDemo"
RUN dotnet publish "PracticeFusion.MmeCalculator.WebDemo.csproj" -c Release -o /server/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /server/publish .
ENTRYPOINT ["dotnet", "PracticeFusion.MmeCalculator.WebDemo.dll"]