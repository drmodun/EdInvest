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
export async function getOnlineCourses(params = {}) {
    try {
      const response = await api.get('online-courses', { params });
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  
  export async function createOnlineCourse(course) {
    try {
      const response = await api.post('online-courses', course);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  
  export async function updateOnlineCourse(id, updates) {
    try {
      const response = await api.patch(`online-courses/${id}`, updates);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  
  export async function deleteOnlineCourse(id) {
    try {
      const response = await api.delete(`online-courses/${id}`);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  