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
export async function getSubcategories(params = {}) {
    try {
      const response = await api.get('subcategories', { params });
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  
  export async function createSubcategory(subcategory) {
    try {
      const response = await api.post('subcategories', subcategory);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  
  export async function updateSubcategory(id, updates) {
    try {
      const response = await api.patch(`subcategories/${id}`, updates);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  
  export async function deleteSubcategory(id) {
    try {
      const response = await api.delete(`subcategories/${id}`);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }