import { useState } from "react";

import classes from "./index.module.css";

import Logo from "../../assets/logo.svg";
import Button from "../Button";

const Navigation = () => {
  const handleLogoClick = () => {
    window.location.href = "/";
  };

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
          <a href="" className={classes.headerNavItem}>
            About us
          </a>
          <a href="/projects" className={classes.headerNavItem}>
            Projects
          </a>
        </nav>
        <div className={classes.headerButtons}>
          <Button>Create a project</Button>
          <Button route={"/login"}>Sign In</Button>
        </div>
      </div>
    </header>
  );
};

export default Navigation;
