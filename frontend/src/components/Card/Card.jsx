import classes from "./index.module.css";

import PlaceholderImage from "../../assets/images/placeholder.jpg";
import BlueArrow from "../../assets/icons/blue-arrow.svg";
import WhiteArrow from "../../assets/icons/white-arrow.svg";
import VerifiedCheckmark from "../../assets/icons/verified-checkmark.svg";

import Heart from "../../assets/icons/heart.svg";
import Share from "../../assets/icons/share.svg";

const Card = ({ name, type, isVerified, description, raised, id }) => {
  return (
    <div className={classes.card}>
      <div className={classes.cardActions}>
        <button className={classes.cardActionsButton}>
          <img src={Heart} alt="" />
        </button>
        <button className={classes.cardActionsButton}>
          <img src={Share} alt="" />
        </button>
      </div>
      <img
        src={PlaceholderImage}
        alt="Placeholder"
        className={classes.cardImage}
      />
      <div className={classes.cardContent}>
        <h3 className={classes.companyTitle}>
          {name || "#NO_NAME"}
          {isVerified && <img src={VerifiedCheckmark} alt="" />}
        </h3>
        <p className={classes.companyType}>{type || "#NO_TYPE"}</p>
        <p className={classes.companyDescription}>
          {description || "#NO_DESCRIPTION"}
        </p>
        <a href="" className={classes.cardReadMore}>
          Read more
          <img src={BlueArrow} alt="" />
        </a>
        <div className={classes.companyRaised}>
          <p className={classes.companyRaisedValue}>
            ${raised || "#NO_VALUE"} <span>Raised</span>
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
