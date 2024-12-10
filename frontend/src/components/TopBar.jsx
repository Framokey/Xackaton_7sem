import { Button } from 'primereact/button';
import React from 'react';

const TopBar = () => {
    return (
        <div className='w-full h-4rem '>
            <div><a href="">Профиль</a></div>
            <div><a href="">Бронирование</a></div>
        </div>
    );
};

export default TopBar;