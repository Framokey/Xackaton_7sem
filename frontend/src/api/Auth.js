import axios from 'axios';

const API_URL = 'https://localhost:80';

export const login = async (email, password) => {
  return axios.get(`${API_URL}/reg`, { email, password });
};
