import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import AppRouter from './router';
import 'primereact/resources/themes/saga-green/theme.css'; // Зеленый стиль
import 'primereact/resources/primereact.min.css'; // Основные стили PrimeReact
import 'primeicons/primeicons.css'; // Иконки
import 'primeflex/primeflex.css'; // PrimeFlex для утилит CSS


import { PrimeReactProvider } from 'primereact/api';


createRoot(document.getElementById('root')).render(
  <PrimeReactProvider>
    <StrictMode>
      <AppRouter />
    </StrictMode>
  </PrimeReactProvider>
)
