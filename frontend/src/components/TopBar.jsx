import { Button } from 'primereact/button';
import React from 'react';
import { Link } from 'react-router-dom';

const TopBar = () => {
    return (
        <div className='w-full h-4rem justify-content-around flex surface-800'>
            <div className='flex align-items-center'>
                <Link to={{pathname: '/profile'}} style={{ textDecoration: 'none', color: 'white' }} href="">Профиль</Link>
            </div>
            <div className='flex align-items-center'>
                <Link to={{pathname:'/main'}} style={{ textDecoration: 'none', color: 'white' }} href=''>Бронирование</Link>
            </div>
        </div>
    );
};

export default TopBar;