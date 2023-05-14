import classes from "./index.module.css";

import PlaceholderImage from "../../assets/images/placeholder.jpg";

const Card = () => {
  return (
    <div className={classes.card}>
      <img src={PlaceholderImage} alt="Placeholder" />
    </div>
  );
};

export default Card;
