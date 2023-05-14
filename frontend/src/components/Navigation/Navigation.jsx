import classes from "./index.module.css";

import Logo from "../../assets/logo.svg";

const Navigation = () => {
  return <header className={classes.header}>
    <img src={Logo} alt="Logo" className={classes.headerLogo} />
  </header>;
};

export default Navigation;
