import axios from 'axios';

export const register = async (email, password) => {
  console.log("OK")
  const data = {
    "email": email,
    "password": password
  }
  return axios.get(`https://localhost:80/api/Auth/register`, data);
};
