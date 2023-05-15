import classes from "./index.module.css";

import PlaceholderImage from "../../assets/images/placeholder.jpg";
import BlueArrow from "../../assets/icons/blue-arrow.svg";
import WhiteArrow from "../../assets/icons/white-arrow.svg";

const Card = () => {
  return (
    <div className={classes.card}>
      <img
        src={PlaceholderImage}
        alt="Placeholder"
        className={classes.cardImage}
      />
      <div className={classes.cardContent}>
        <h3 className={classes.companyTitle}>Company Title</h3>
        <p className={classes.companyType}>Company Type</p>
        <p className={classes.companyDescription}>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Suscipit
          repudiandae quos unde delectus repellendus nam alias in cupiditate
          dolor, fugit voluptatibus possimus ut explicabo!
        </p>
        <a href="" className={classes.cardReadMore}>
          Read more
          <img src={BlueArrow} alt="" />
        </a>
        <div className={classes.companyRaised}>
          <p className={classes.companyRaisedValue}>
            $479 <span>Raised</span>
          </p>
          <button className={classes.companyInvest}>
            Invest
            <img src={WhiteArrow} alt="" />
          </button>
        </div>
      </div>
    </div>
  );
};

export default Card;
