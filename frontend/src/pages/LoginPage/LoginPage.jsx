import React, { useContext, useEffect, useState } from "react";
import { Link } from "react-router-dom";
import classes from "./LoginPage.module.css";
import { GetMe, login } from "../../axios/UserCalls/UserApiCalls";
import Facebook from "../../assets/facebook.svg";
import Google from "../../assets/google.svg";
import Twitter from "../../assets/twitter.svg";
import AppStore from "../../assets/IOS.svg";
import Torus from "../../assets/torus.png";
import Metamask from "../../assets/metamask.png";
import BackgroundImage from "../../assets/login-background.png";
import MobileBackgroundImage from "../../assets/header-background.png";
import CloseIcon from "../../assets/icons/close.svg";

import useUserInfo from "../../Providers/UserInfoProvider";

export const LoginPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const [windowSize, setWindowSize] = useState(getWindowSize());
  const userInfo = JSON.parse(localStorage.getItem("userInfo"));

  function getWindowSize() {
    const { innerWidth, innerHeight } = window;
    return { innerWidth, innerHeight };
  }
  //weird way to get window size but will have to use it to change the background image
  useEffect(() => {
    function handleWindowResize() {
      setWindowSize(getWindowSize());
    }
    window.addEventListener("resize", handleWindowResize);
    return () => window.removeEventListener("resize", handleWindowResize);
  }, []);
  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      if (!email || !password) {
        setError("Please fill all the fields");
        return;
      }
      const response = await login(email, password);
      if (!response) throw new Error("Invalid credentials");
      const userInfo = await GetMe();
      if (userInfo) {
        localStorage.setItem("userInfo", JSON.stringify(userInfo));
        alert("Logged in successfully");
        window.location.replace("/");
      } else {
        setError("Invalid credentials");
      }
    } catch (error) {
      setError("Invalid credentials");
    }
  };
  function logOutAndRefresh() {
    localStorage.removeItem("userInfo");
    localStorage.removeItem("token");
    window.location.replace("/login");
  }
  return (
    <div className={classes.LoginPage}>
      <button
        className={classes.CloseButton}
        onClick={() => (window.location.href = "/")}
      >
        <img src={CloseIcon} alt="" />
      </button>
      <img
        className={classes.MainImage}
        src={
          windowSize.innerWidth > 900 ? BackgroundImage : MobileBackgroundImage
        }
        alt="logo"
      />
      {!userInfo ? (
        <div className={classes.Logins}>
          <span className={classes.Title}>Sign in</span>
          <span className={classes.SubTitle}>
            Please Sign into your account to start using EdInvest
          </span>
          <form className={classes.LoginForm} onSubmit={handleSubmit}>
            <input
              type="email"
              placeholder="Email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
            <input
              type="password"
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
            <button type="submit">Login</button>
            <p className={classes.Error}>{error ? error : ""}</p>
          </form>
          <div className={classes.Border}> or </div>
          <div className={classes.AlternateLogins}>
            <button className={classes.CryptoLogin}>
              <img src={Torus} alt="Torus" />
              <span> Sign in with Torus</span>
            </button>
            <button className={classes.CryptoLogin}>
              <img src={Metamask} alt="Metamask" />
              <span> Sign in with Metamask</span>
            </button>
            <div className={classes.Border}> or </div>
            <div className={classes.SocialLogins}>
              <img src={Facebook} alt="FaceBook" />
              <img src={Google} alt="Google" />
              <img src={Twitter} alt="Twitter" />
              <img src={AppStore} alt="AppStore" />
            </div>
            <div className={classes.SignUp}>
              <span>Don't have an account? </span>
              <Link to={"/register"}>
                <span>Sign Up</span>
              </Link>
            </div>
          </div>
        </div>
      ) : (
        <div className={classes.AlreadyLogged}>
          <span>You are already logged in</span>
          <Link to={"/"}> Go to Home Page</Link>
          <button className={classes.LogOut} onClick={logOutAndRefresh}>
            Log out
          </button>
        </div>
      )}
    </div>
  );
};
