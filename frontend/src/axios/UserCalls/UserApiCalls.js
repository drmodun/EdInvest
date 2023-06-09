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
    if (token && (["put", "delete"].includes(config.method) || config.url.includes("me"))) {
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
export async function getUsers(params = {}) {
  try {
    const response = await api.get("users", { params });
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}

export async function deleteUser(id) {
  try {
    const response = await api.delete(`users/${id}`);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}
export async function login(email, password) {
  try {
    const response = await api.post("users/login", { email, password });
    if (response.status === 200) {
      localStorage.setItem("token", response.data);    
      return true;
      }
    return false;
  } catch (error) {
    ;
    ;
    throw new Error(error.message);
  }
}
export async function GetMe(){
    try{
        const response = await api.get("users/me");
        return response.data;
    }
    catch(error){
        throw new Error(error.message);
    }
}