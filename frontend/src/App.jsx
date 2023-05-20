import "./App.css";
import "./fonts.css";
import Router from "./components/Router";
import { UserInfoProvider } from "./Providers/UserInfoProvider";
import { GetMe } from "./axios/UserCalls/UserApiCalls";
import { useEffect, useState } from "react";

async function getUserInfo() {
  try {
    const response = await GetMe();
    if (response) {
      localStorage.setItem("userInfo", JSON.stringify(response));
    }
  } catch (error) {
    console.log(error);
  }
}
  
const tokenCheck = () => {
  const token = localStorage.getItem("token");
  if (!token) 
    return;
  const time = JSON.parse(localStorage.getItem("LoginDate"));
  if (Date.now() - time > 8*3600000) {
    console.log("token expired", time);
    localStorage.removeItem("token");
    localStorage.removeItem("userInfo");
    localStorage.removeItem("LoginDate");
  }
};

function App() {

  useEffect(() => {
    tokenCheck();
  }, []);
  return (
    <UserInfoProvider>
      <Router />
    </UserInfoProvider>
  );
}

export default App;
