import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { isAuthenticated } from '../utils/authUtils'; // Импортируем функцию проверки токена

const PublicRoute = ({ redirectPath = '/main' }) => {
  // Проверяем, авторизован ли пользователь
  if (isAuthenticated()) {
    return <Navigate to={redirectPath} replace />;
  }

  // Если авторизован, показываем дочерние маршруты
  return <Outlet />;
};

export default PublicRoute;