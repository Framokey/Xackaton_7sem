import React from 'react';
import LoginRegisterPage from '../pages/AuthPage'; // Предыдущий компонент

const AuthLayout = () => {
    return (
        <div
            className="min-h-screen flex align-items-center justify-content-center"
            style={{
                background: 'linear-gradient(135deg, #1abc9c, #2ecc71)', // Градиент
                backgroundSize: 'cover',
                color: '#fff',
            }}
        >
            <LoginRegisterPage />
        </div>
    );
};

export default AuthLayout;