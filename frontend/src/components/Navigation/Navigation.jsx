import classes from "./index.module.css";

import Logo from "../../assets/logo.svg";
import Button from "../Button";

const Navigation = () => {
  return (
    <header className={classes.header}>
      <div className="layoutSpacing">
        <img src={Logo} alt="Logo" className={classes.headerLogo} />
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
