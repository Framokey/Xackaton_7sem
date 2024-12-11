import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import AuthLayout from '../layout/AuthLayout';
import TestPage from '../pages/testPage';
import ProfilePage from '../pages/ProfilePage';
import Layout from '../layout/layout';
import BookingBoard from "../pages/MainPage";
import AdminPage from '../pages/AdminPage';
import ProtectedRoute from './ProtectedRoute';
import PublicRoute from './PublicRoute';

const AppRouter = () => {
  
  return (
    <Router>
      <Routes>
      <Route path='*' element={<Navigate to="/main" replace />} />
      <Route element={<PublicRoute />}>
        <Route path="/reg" element={<AuthLayout />} />
        <Route path="/test" element={<TestPage />} />
      </Route>

        <Route element={<ProtectedRoute/>}>
          <Route path="/" element={<Layout/>} >
            <Route path="main" element={<BookingBoard />} />
            <Route path='profile' element={<ProfilePage/>} />
            <Route path='admin' element={<AdminPage />}/>
          </Route>
        </Route>
      </Routes>
    </Router>
  )
};

export default AppRouter;
