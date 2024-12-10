import React, { useState } from 'react';
import { InputText } from 'primereact/inputtext';
import { Password } from 'primereact/password';
import { Button } from 'primereact/button';
import { Divider } from 'primereact/divider';
import { login } from '../api/Auth';

const RegisterForm = ({ onSubmit, isRegister }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = (data) => {
    data.preventDefault();
    login(data.email, data.password);
  };

  return (
    <div className="p-d-flex p-jc-center p-ai-center" style={{ height: '100vh' }}>
      <div className="p-card p-p-4" style={{ maxWidth: '400px', width: '100%' }}>
        <h2 className="p-text-center">{isRegister ? 'Регистрация' : 'Вход'}</h2>
        <form onSubmit={handleSubmit}>
          <div className="p-field">
            <label htmlFor="email">Email</label>
            <InputText
              id="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              placeholder="Введите email"
              className="p-inputtext-lg"
              required
            />
          </div>

          <div className="p-field">
            <label htmlFor="password">Пароль</label>
            <Password
              id="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              placeholder="Введите пароль"
              toggleMask
              feedback={false}
              required
            />
          </div>

          <Button label={isRegister ? 'Зарегистрироваться' : 'Войти'} className="p-button-lg p-mt-3" type="submit"/>

          {!isRegister && (
            <>
              <Divider />
              <p className="p-text-center">
                Нет аккаунта? <a href="/register">Регистрация</a>
              </p>
            </>
          )}
        </form>
      </div>
    </div>
  );
};

export default RegisterForm;
