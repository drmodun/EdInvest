import { useState } from "react";

import classes from "./index.module.css";
import DefaultProfile from "../../assets/default-profile.png";
import Logo from "../../assets/logo.svg";
import Button from "../Button";
import { Link } from "react-router-dom";

const Navigation = () => {
  const handleLogoClick = () => {
    window.location.href = "/";
  };
  const base64regex =
    /^([0-9a-zA-Z+/]{4})*(([0-9a-zA-Z+/]{2}==)|([0-9a-zA-Z+/]{3}=))?$/;
  const userInfo = JSON.parse(localStorage.getItem("userInfo"));
  const [isHidden, setIsHidden] = useState(false);

  var prevScrollpos = window.pageYOffset;
  window.onscroll = function () {
    var currentScrollPos = window.pageYOffset;
    if (prevScrollpos > currentScrollPos) {
      setIsHidden(false);
    } else {
      if (currentScrollPos > 200) setIsHidden(true);
    }
    prevScrollpos = currentScrollPos;
  };

  const logOut = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("userInfo");
    window.location.href = "/";
  };

  return (
    <header className={`${classes.header} ${isHidden ? classes.hidden : ""}`}>
      <div className="layoutSpacing">
        <img
          src={Logo}
          alt="Logo"
          className={classes.headerLogo}
          onClick={handleLogoClick}
        />
        <nav className={classes.headerNav}>
          <a href="/" className={classes.headerNavItem}>
            Home
          </a>
          <a href="/about" className={classes.headerNavItem}>
            About us
          </a>
          <a href="/projects" className={classes.headerNavItem}>
            Projects
          </a>
        </nav>

        <div className={classes.headerButtons}>
          <Link to={"/projects/new"}><Button route={"projects/new"}>Create a project</Button></Link>
          {userInfo ? (
            <Link to={"/me"}><Button >
              <img
                src={
                  base64regex.test(userInfo.profilePicture) &&
                  userInfo.profilePicture
                    ? "data:image/png;base64," +
                      JSON.parse(localStorage.getItem("userInfo"))
                        .profilePicture
                    : DefaultProfile
                }
                alt="user"
              />

              <span>{userInfo.name}</span>
            </Button></Link>
          ) : (
            <Link to={"/login"}><Button >Sign In</Button></Link>
          )}
        </div>
        {userInfo && (
          <div className={classes.LogOut}>
            <button onClick={logOut}>Log Out</button>
          </div>
        )}
      </div>
    </header>
  );
};

export default Navigation;
