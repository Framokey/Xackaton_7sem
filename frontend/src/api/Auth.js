import axios from 'axios';

export const register = async (email, password) => {
  const data = {
    "email": email,
    "password": password
  }
  return axios.post(`http://localhost:80/api/Auth/register`, data);
};

export const login = async (email, password) => {
  const data = {
    "email": email,
    "password": password
  }
  return axios.post(`http://localhost:80/api/Auth/login`, data);
}
