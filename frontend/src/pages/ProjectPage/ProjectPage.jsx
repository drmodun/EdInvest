import classes from "./index.module.css";
import PlaceholderImg from "../../assets/images/placeholder.jpg";
import { useState } from "react";

const ProjectPage = () => {
  const [informationsChosen, setInformationsChosen] = useState(true);
  const handleClickInformations = () => {
    setInformationsChosen(true);
  };
  const handleClickDonations = () => {
    setInformationsChosen(false);
  };

  return (
    <>
      <div className={classes.ImageWrapper}>
        <img className={classes.ProjectImage} src={PlaceholderImg} alt="" />
      </div>
      <div className={classes.InfoSection}>
        <div className={classes.InfoWrapper}>
          <div className={classes.CenterWrapper}>
            <div className={classes.BasicInfoContainer}>
              <div className={classes.BasicInfoBox}>
                <h4 className={classes.BasicInfoTitle}>Name</h4>
                <h4 className={classes.BasicInfoText}>DUMP</h4>
              </div>
              <div className={classes.BasicInfoBox}>
                <h4 className={classes.BasicInfoTitle}>Type</h4>
                <h4 className={classes.BasicInfoText}>Association</h4>
              </div>
              <div className={classes.BasicInfoBox}>
                <h4 className={classes.BasicInfoTitle}>Location</h4>
                <h4 className={classes.BasicInfoText}>Croatia</h4>
              </div>
              <div className={classes.BasicInfoBox}>
                <h4 className={classes.BasicInfoTitle}>Founded</h4>
                <h4 className={classes.BasicInfoText}>2010</h4>
              </div>
            </div>

            <div>
              {informationsChosen ? (
                <div>
                  Lorem ipsum dolor sit amet consectetur, adipisicing elit.
                  Doloribus, mollitia. Facilis, odit. Mollitia magnam itaque
                  libero aut expedita natus, perspiciatis molestias, beatae iure
                  quam modi reiciendis at cumque velit nulla. Lorem ipsum, dolor
                </div>
              ) : (
                <div>
                  Lorem ipsum, dolor sit amet consectetur adipisicing elit.
                  Praesentium dolor sed maiores tempore eligendi architecto
                  debitis, quaerat corporis ipsam. Dolorem ea delectus assumenda
                  repellat, in eligendi temporibus asperiores! At, fugiat? Lorem
                  ipsum, dolor sit amet consectetur adipisicing elit.
                  Praesentium dolor sed maiores tempore eligendi architecto
                  debitis, quaerat corporis ipsam. Dolorem ea delectus assumenda
                  repellat, in eligendi temporibus asperiores! At, fugiat? Lorem
                </div>
              )}
            </div>
          </div>
          <div className={classes.InfoChoiceWrapper}>
            <button
              onClick={() => handleClickInformations()}
              className={
                informationsChosen
                  ? classes.InfoChoiceChosen
                  : classes.InfoChoiceNotChosen
              }
            >
              Informations
            </button>
            <button
              onClick={() => handleClickDonations()}
              className={
                !informationsChosen
                  ? classes.InfoChoiceChosen
                  : classes.InfoChoiceNotChosen
              }
            >
              Donations
            </button>
          </div>
        </div>
      </div>
    </>
  );
};

export default ProjectPage;
