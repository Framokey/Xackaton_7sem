import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import AuthLayout from '../layout/AuthLayout';
import TestPage from '../pages/testPage';
import ProfilePage from '../pages/ProfilePage';
import Layout from '../layout/layout';
import BookingBoard from "../pages/MainPage";

const AppRouter = () => (
  <Router>
    <Routes>
    <Route path='*' element={<Navigate to="/reg" replace />} />
      <Route path="/reg" element={<AuthLayout />} />
      <Route path="/test" element={<TestPage />} />
      <Route path="/" element={<Layout/>} >
        <Route path="main" element={<BookingBoard />} />
        <Route path='profile' element={<ProfilePage/>} />
      </Route>
    </Routes>
  </Router>
);

export default AppRouter;
