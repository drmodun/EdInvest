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
  

function App() {

  return <UserInfoProvider> 
  <Router />
  </UserInfoProvider>
}

export default App;
