import React, { useState } from 'react';
import InputField from './InputField';

const RegisterForm = ({ onSubmit, isRegister }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit({ email, password });
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>{isRegister ? 'Регистрация' : 'Вход'}</h2>
      <InputField label="Email" type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
      <InputField label="Пароль" type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
      <button type="submit">{isRegister ? 'Зарегистрироваться' : 'Войти'}</button>
    </form>
  );
};

export default RegisterForm;
