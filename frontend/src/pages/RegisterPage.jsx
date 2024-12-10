import React from 'react';
import { register } from '../api/Auth';
import RegisterForm from '../components/RegisterForm';

const RegisterPage = () => {
  const handleRegister = async (data) => {
    try {
      const response = await register(data.email, data.password);
      console.log('Registration successful', response.data);
    } catch (error) {
      console.error('Error registering:', error);
    }
  };

  return <RegisterForm onSubmit={handleRegister} isRegister={true} />;
};

export default RegisterPage;
