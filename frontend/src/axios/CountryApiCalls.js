import axios from "axios";
const api = axios.create({
    baseURL: "https://localhost:44336/api/",
    headers: {
      'Content-Type': 'application/json',
    },
  });
export async function getCountryById(countryId) {
  try {
    const response = await api.get(`countries/${countryId}`);
    return response.data;
  } catch (error) {
    throw new Error(error.message);
  }
}
export async function GetCountries(){
    try{
    const response = await api.get("countries");
    return response.data;
    }
    catch(error){
        throw new Error(error.message);
    }

}