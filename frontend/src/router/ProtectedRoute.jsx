import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { isAuthenticated } from '../utils/authUtils'; // Импортируем функцию проверки токена

const ProtectedRoute = ({ redirectPath = '/reg' }) => {
  // Проверяем, авторизован ли пользователь
  if (!isAuthenticated()) {
    return <Navigate to={redirectPath} replace />;
  }

  // Если авторизован, показываем дочерние маршруты
  return <Outlet />;
};

export default ProtectedRoute;