import axios from "axios";
const api = axios.create({
  baseURL: "https://localhost:44336/api/",
  headers: {
    "Content-Type": "application/json",
  },
});

// Add a request interceptor
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem("token");
    if (token && ["post", "put", "delete"].includes(config.method)) {
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

export async function getItems(params = {}) {
  try {
    const response = await api.get("items", { params });
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function deleteItem(id) {
  try {
    const response = await api.delete(`items/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function getItem(id) {
  try {
    const response = await api.get(`items/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}
