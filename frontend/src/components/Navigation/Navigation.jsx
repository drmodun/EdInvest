import classes from "./index.module.css";

import Logo from "../../assets/logo.svg";
import Button from "../Button";
import { Link } from "react-router-dom";

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
          <Button>
          <Link to={"/login"}>
            Sign In 
            </Link>
            </Button>
        </div>
      </div>
    </header>
  );
};

export default Navigation;
