import React, { useState } from 'react';
import { InputText } from 'primereact/inputtext';
import { Password } from 'primereact/password';
import { Button } from 'primereact/button';
import { Card } from 'primereact/card';
import { Divider } from 'primereact/divider';
import { classNames } from 'primereact/utils';

const LoginRegisterPage = () => {
    const [isLogin, setIsLogin] = useState(true);
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [error, setError] = useState('');

    const handleLogin = () => {
        if (!email || !password) {
            setError('Пожалуйста, заполните все поля');
            return;
        }
        setError('');
        console.log('Вход выполнен:', { email, password });
    };

    const handleRegister = () => {
        if (!email || !password || !confirmPassword) {
            setError('Пожалуйста, заполните все поля');
            return;
        }
        if (password !== confirmPassword) {
            setError('Пароли не совпадают');
            return;
        }
        setError('');
        console.log('Регистрация выполнена:', { email, password });
    };

    return (
        <div className="flex align-items-center justify-content-center bg-green-100 w-4 border-round-2xl">
            <Card className="w-full md:w-40rem border-round-2xl">
                <h2 className="text-center text-3xl font-bold mb-4">
                    {isLogin ? 'Вход' : 'Регистрация'}
                </h2>
                <div className="p-fluid">
                    <div className="field">
                        <label htmlFor="email">Email</label>
                        <InputText
                            id="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            className={classNames({ 'p-invalid': error })}
                        />
                    </div>
                    <div className="field">
                        <label htmlFor="password">Пароль</label>
                        <Password
                            id="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            feedback={false}
                            className={classNames({ 'p-invalid': error })}
                        />
                    </div>
                    {!isLogin && (
                        <div className="field">
                            <label htmlFor="confirmPassword">Подтвердите пароль</label>
                            <Password
                                id="confirmPassword"
                                value={confirmPassword}
                                onChange={(e) => setConfirmPassword(e.target.value)}
                                feedback={false}
                                className={classNames({ 'p-invalid': error })}
                            />
                        </div>
                    )}
                    {error && <small className="p-error">{error}</small>}
                    <Button
                        label={isLogin ? 'Войти' : 'Зарегистрироваться'}
                        className="w-full mt-3 p-button-success"
                        onClick={isLogin ? handleLogin : handleRegister}
                    />
                </div>
                <Divider />
                <div className="text-center">
                    <Button
                        label={isLogin ? 'Создать аккаунт' : 'Уже есть аккаунт?'}
                        className="p-button-text p-button-success"
                        onClick={() => setIsLogin(!isLogin)}
                    />
                </div>
            </Card>
        </div>
    );
};

export default LoginRegisterPage;