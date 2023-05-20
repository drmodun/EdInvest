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
    if (token && (["post",'put', 'delete'].includes(config.method) || config.url.includes("me"))) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);


export async function getInvestment(investorId, itemId)
{
    try{
        const response = await api.get(`investments/${itemId}/${investorId}`);
        return response.data;
    }
    catch(error){
        throw new Error(error.message);
    }
}
export async function getInvestorsByItemId(itemId){
    try{
        const response = await api.get(`investments/${itemId}/investors`);
        return response.data;
    }
    catch(error){
        throw new Error(error.message);
    }
}
export async function getTopInvestors(){
    try{
        const response = await api.get(`investments/topinvestors`);
        return response.data;
    }
    catch(error){
        throw new Error(error.message);
    }
}
export async function getStats(){
    try{
        const response = await api.get(`investments/stats`);
        return response.data;
    }
    catch(error){
        throw new Error(error.message);
    }
}
export async function getMyInvestments(){
    try{
        const response = await api.get(`investments/me`);
        return response.data;
    }
    catch(error){
        throw new Error(error.message);
    }
}

export async function getItemsForInvestor(investorId){
    try{
        ;
        const response = await api.get(`investments/${investorId}/items`);
        ;
        return response.data;
    }
    catch(error){
        throw new Error(error.message);
    }
}


export async function getInvestments(params = {}){
    try{
        const response = await api.get(`investments`, { params });
        return response.data;
    }
    catch(error){
        ;
        throw new Error(error.message);
    }
}
export async function createInvestment(itemId, data){
    try{
        const response = await api.post(`investments/${itemId}`, Number(data));
        return response.data;
    }
    catch(error){
        throw new Error(error.data);
    }
}
export async function updateInvestment(itemId, data){
    try{
        const response = await api.put(`investments/${itemId}`, data);
        return response.data;
    }
    catch(error){
        throw new Error(error.message);
    }
}
export async function deleteInvestment(itemId){
    try{
        const response = await api.delete(`investments/${itemId}`);
        return response.data;
    }
    catch(error){
        throw new Error(error.message);
    }
}
export async function getInvestmentsForOrg(organisationId){
    try{
        const response = await api.get(`investments/${organisationId}`);
        return response.data;
    }
    catch(error){
        throw new Error(error.message);
    }
}