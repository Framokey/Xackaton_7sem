# Используем базовый образ .NET SDK 8.0 для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Устанавливаем рабочую директорию внутри контейнера
WORKDIR /src

COPY ../../BLL/ ./BLL/
COPY ../../DAL/ ./DAL/
COPY ../../Domains/ ./Domains/
COPY ../../Utils/ ./Utils/

# Копируем файл проекта (backend.csproj) и восстанавливаем зависимости
COPY ../../backend/backend.csproj ./backend/
RUN dotnet restore ./backend/backend.csproj

# Копируем все файлы проекта
COPY ../../backend/ ./backend/

# Публикуем приложение в папку /app/publish
RUN dotnet publish ./backend/ -c Release -o /app/publish

# Используем базовый образ .NET Runtime 8.0 для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем опубликованные файлы из стадии сборки
COPY --from=build /app/publish ./

# Указываем порт, который будет использоваться приложением
EXPOSE 8080

# Указываем команду для запуска приложения
ENTRYPOINT ["dotnet", "backend.dll"]