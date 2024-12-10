import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import AppRouter from './router';

import { PrimeReactProvider } from 'primereact/api';


createRoot(document.getElementById('root')).render(
  <PrimeReactProvider>
    <StrictMode>
      <AppRouter />
    </StrictMode>
  </PrimeReactProvider>
)
