import { useEffect } from "react";
import "./App.css";
import Router from "./components/Router";
import "./fonts.css";

const tokenCheck = () => {
  const token = localStorage.getItem("token");
  if (!token) return;
  const time = JSON.parse(localStorage.getItem("LoginDate"));
  if (Date.now() - time > 8 * 3600000) {
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
  return <Router />;
}

export default App;
