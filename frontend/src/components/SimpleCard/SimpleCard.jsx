import classes from "./index.module.css";

import PlaceholderImage from "../../assets/images/placeholder.jpg";

const Card = ({ name, type, description, image }) => {
  return (
    <div className={classes.card}>
      <img
        src={image || PlaceholderImage}
        alt="Placeholder"
        className={classes.cardImage}
      />
      <div className={classes.cardContent}>
        <h3 className={classes.companyTitle}>{name || "#NO_NAME"}</h3>
        <p className={classes.companyType}>{type || "#NO_TYPE"}</p>
        <p className={classes.companyDescription}>
          {description || "#NO_DESCRIPTION"}
        </p>
      </div>
    </div>
  );
};

export default Card;
