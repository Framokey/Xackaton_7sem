import Cookies from 'js-cookie';

// Функция для проверки наличия токена в cookie
export const isAuthenticated = () => {
  const token = Cookies.get('Cookie'); // Получаем токен из cookie
  return !!token; // Возвращаем true, если токен существует
};