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
export async function getEvents(params = {}) {
  try {
    const response = await api.get("events", { params });
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function createEvent(event) {
  try {
    const response = await api.post("events", event);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function updateEvent(id, updates) {
  try {
    const response = await api.patch(`events/${id}`, updates);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function deleteEvent(id) {
  try {
    const response = await api.delete(`events/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function getEvent(id) {
  try {
    const response = await api.get(`events/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}
