import React from 'react';
import { Outlet } from "react-router-dom";
import TopBar from "../components/TopBar";


const Layout = () => {
    return(
        <div className="w-full h-full">
            <div>
                <TopBar/>
            </div>
            <Outlet/>
        </div>
    )
};

export default Layout;