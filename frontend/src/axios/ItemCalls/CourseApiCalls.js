import axios from 'axios';
const api = axios.create({
  baseURL: "https://localhost:44336/",
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

export async function getCourses(params = {}) {
    try {
      const response = await api.get('courses', { params });
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }

export async function createCourse(data) {
    try {
      const response = await api.post('courses', data);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  
  export async function updateCourse(data) {
    try {
      const response = await api.put(`courses/${data.id}`, data);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  
  export async function deleteCourse(courseId) {
    try {
      const response = await api.delete(`courses/${courseId}`);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }
  export async function getCourseById(courseId) {
    try {
      const response = await api.get(`courses/${courseId}`);
      return response.data;
    } catch (error) {
      throw new Error(error.message);
    }
  }