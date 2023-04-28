# Берёт базовый образ
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /src
# Копирует файл в директорию контейнера src
COPY ["src/OcsTestWork.OrderApi/OcsTestWork.OrderApi.csproj","src/OcsTestWork.OrderApi/"]
# Восстанавливает зависимости
RUN dotnet restore "src/OcsTestWork.OrderApi/OcsTestWork.OrderApi.csproj"

# Копирует из первого контекста в текущий workdir /src
COPY . .

WORKDIR "/src/src/OcsTestWork.OrderApi"

RUN dotnet build "OcsTestWork.OrderApi.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "OcsTestWork.OrderApi.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

WORKDIR /app

# EXPOSE 80
# EXPOSE 443

FROM runtime as final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT [ "dotnet","OcsTestWork.OrderApi.dll" ]