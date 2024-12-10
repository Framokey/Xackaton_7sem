# Используем базовый образ Nginx
FROM nginx:alpine

# Копируем конфигурацию Nginx
COPY ./docker/nginx/conf/nginx.conf /etc/nginx/conf.d/default.conf

# Указываем порт, который будет использоваться Nginx
EXPOSE 80

# Запускаем Nginx
CMD ["nginx", "-g", "daemon off;"]