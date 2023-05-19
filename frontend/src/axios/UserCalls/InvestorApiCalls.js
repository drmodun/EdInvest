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
export async function getInvestors(params = {}) {
  try {
    const response = await api.get("investors", { params });
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function createInvestor(investor) {
  try {
    const response = await api.post("investors", investor);
    return response.data;
  } catch (error) {
    console.log(error);
    console.log(error.response);
    console.log(investor)
    console.log(error.message);
    throw new Error(error.message);
  }
}

export async function updateInvestor(id, updates) {
  try {
    const response = await api.patch(`investors/${id}`, updates);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function deleteApplication(id) {
  try {
    const response = await api.delete(`investors/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}
export async function getInvestorById(investorId) {
  try {
    const response = await api.get(`investors/${investorId}`);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}
