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
      console.log("Unauthorized")
    } else {
      console.log(error)
    }
    return Promise.reject(error);
  }
);
export async function getApplications(params = {}) {
  try {
    const response = await api.get("applications", { params });
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function createApplication(application) {
  try {
    const response = await api.post("applications", application);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function updateApplication(id, updates) {
  try {
    const response = await api.patch(`applications/${id}`, updates);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function deleteApplication(id) {
  try {
    const response = await api.delete(`applications/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function getApplication(id) {
  try {
    const response = await api.get(`applications/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}
