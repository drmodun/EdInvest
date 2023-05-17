import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import classes from "./LoginPage.module.css";
import { login } from "../../axios/UserCalls/UserApiCalls";
import Facebook from "../../assets/facebook.png";
import Google from "../../assets/google.png";
import Twitter from "../../assets/twitter.png";
import AppStore from "../../assets/IOS.png";
import Torus from "../../assets/torus.png";
import Metamask from "../../assets/metamask.png";
import BackgroundImage from "../../assets/login-background.png";
import MobileBackgroundImage from "../../assets/header-background.png";
export const LoginPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const [windowSize, setWindowSize] = useState(getWindowSize());

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
      if (response) {
        alert("Logged in successfully");
        window.location.replace("/");
      } else {
        setError("Invalid credentials");
      }
    } catch (error) {
      setError("Invalid credentials");
    }
  };
  console.log(windowSize);
  return (
    <div className={classes.LoginPage}>
      <img
        className={classes.MainImage}
        src={
          windowSize.innerWidth > 900 ? BackgroundImage : MobileBackgroundImage
        }
        alt="logo"
      />
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
    </div>
  );
};
