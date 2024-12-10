# Используем базовый образ Node.js
FROM node:18 AS build

# Устанавливаем рабочую директорию внутри контейнера
WORKDIR /app

# Копируем package.json и package-lock.json
COPY ../../frontend/package*.json ./

# Устанавливаем зависимости
RUN npm install

# Копируем все файлы проекта
COPY ../../frontend/ ./

# Собираем React-приложение
RUN npm run build

# Используем базовый образ Nginx для раздачи статики
FROM nginx:alpine

# Копируем собранное React-приложение в директорию Nginx
COPY --from=build /app/build /usr/share/nginx/html

# Копируем конфигурацию Nginx
COPY ./docker/nginx/conf/nginx.conf /etc/nginx/conf.d/default.conf

# Указываем порт, который будет использоваться Nginx
EXPOSE 80

# Запускаем Nginx
CMD ["nginx", "-g", "daemon off;"]