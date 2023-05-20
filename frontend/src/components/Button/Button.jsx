import classes from "./index.module.css";

const Button = ({ children }) => {
  return (
    <button className={classes.button}>
      {children}
    </button>
  );
};

export default Button;
