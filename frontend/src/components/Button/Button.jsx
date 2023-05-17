import classes from "./index.module.css";

const Button = ({ children, route }) => {
  const handleButtonClick = () => {
    window.location.replace(route || "/");
  };
  return (
    <button className={classes.button} onClick={handleButtonClick}>
      {children}
    </button>
  );
};

export default Button;
