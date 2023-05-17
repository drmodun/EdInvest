import axios from 'axios';

const api = axios.create({
  baseURL: "https://localhost:44336/api/",
  headers: {
    'Content-Type': 'application/json',
  },
});

// Add a request interceptor
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token');
    if (token && ['post', 'put', 'delete'].includes(config.method)) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

// Add a response interceptor
api.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (error.response.status === 401) {
      // Handle unauthorized error
    } else {
      // Handle other errors
    }
    return Promise.reject(error);
  }
);
export async function getCategories(params = {}) {
    try {
      const response = await api.get('categories', { params });
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  
  export async function createCategory(category) {
    try {
      const response = await api.post('categories', category);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  
  export async function updateCategory(id, updates) {
    try {
      const response = await api.patch(`categories/${id}`, updates);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  
  export async function deleteCategory(id) {
    try {
      const response = await api.delete(`categories/${id}`);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }