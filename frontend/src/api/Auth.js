import axios from 'axios';

const API_URL = 'https://example.com/api/auth';

export const login = async (email, password) => {
  return axios.get(`${API_URL}/login`, { email, password });
};

export const register = async (email, password) => {
  return axios.post(`${API_URL}/register`, { email, password });
};
