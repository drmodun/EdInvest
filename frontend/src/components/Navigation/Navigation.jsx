import classes from "./index.module.css";

import Logo from "../../assets/logo.svg";
import Button from "../Button"

const Navigation = () => {
  return <header className={classes.header}>
    <img src={Logo} alt="Logo" className={classes.headerLogo} />
    <nav className={classes.headerNav}>
      <a href="" className={classes.headerNavItem}>Home</a>
      <a href="" className={classes.headerNavItem}>About us</a>
      <a href="" className={classes.headerNavItem}>Projects</a>
    </nav>
    <Button className={classes.headerButton}>Sign in</Button>
  </header>;
};

export default Navigation;
