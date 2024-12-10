import React from 'react';
import { login } from '../api/Auth';
import RegisterForm from '../components/RegisterForm';

const LoginPage = () => {
  const handleLogin = async (data) => {
    try {
      const response = await login(data.email, data.password);
      console.log('Login successful', response.data);
    } catch (error) {
      console.error('Error logging in:', error);
    }
  };

  return <RegisterForm onSubmit={handleLogin} isRegister={false} />;
};

export default LoginPage;
