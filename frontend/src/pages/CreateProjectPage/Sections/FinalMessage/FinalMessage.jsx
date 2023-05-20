import classes from "./index.module.css";

import SimpleCard from "../../../../components/SimpleCard";

import FacebookBlueIcon from "../../../../assets/icons/facebook-blue.svg";
import LinkedinBlueIcon from "../../../../assets/icons/linkedin-blue.svg";
import TwitterBlueIcon from "../../../../assets/icons/twitter-blue.svg";
import Confetti from "../../../../assets/images/confetti.png";

const FinalMessage = ({ data }) => {
  return (
    <section className={classes.section}>
      <SimpleCard
        name={data.name}
        type={data._TYPE}
        description={data.description}
      />
      <div className={classes.content}>
        <img src={Confetti} alt="" className={classes.confetti} />
        <h2 className={classes.contentTitle}>Wooohoo!</h2>
        <p className={classes.contentParagraph}>
          Your project is finished! Now only please take in consideration that
          after you publish your project our team will take some time to review
          your project and approve it. This might take a few days so don't worry
          if you don't find it on project list.
        </p>
        <p className={classes.contentParagraph}>
          But you can still access your project from your profile
        </p>
        <div className={classes.contentShare}>
          <p>Share this with your friends!</p>
          <div className={classes.contentShareButtons}>
            <button>
              <img src={TwitterBlueIcon} alt="" />
            </button>
            <button>
              <img src={LinkedinBlueIcon} alt="" />
            </button>
            <button>
              <img src={FacebookBlueIcon} alt="" />
            </button>
          </div>
        </div>
      </div>
    </section>
  );
};

export default FinalMessage;
