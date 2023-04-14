FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

COPY ["Tools/PracticeFusion.MmeCalculator.Cli/PracticeFusion.MmeCalculator.Cli.csproj", "Tools/PracticeFusion.MmeCalculator.Cli/"]

RUN dotnet restore "Tools/PracticeFusion.MmeCalculator.Cli/PracticeFusion.MmeCalculator.Cli.csproj"

COPY . .

RUN dotnet pack "Tools/PracticeFusion.MmeCalculator.Cli/PracticeFusion.MmeCalculator.Cli.csproj" -c Release -o /cli/nuget

RUN dotnet tool install --global --version 1.0.0 --add-source /cli/nuget PracticeFusion.MmeCalculator.Cli

FROM mcr.microsoft.com/dotnet/runtime:7.0
COPY --from=build /root/.dotnet/tools /opt/bin
ENV PATH="${PATH}:/opt/bin"

ENTRYPOINT ["mmecalculator"]