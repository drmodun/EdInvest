import classes from "./index.module.css";
import PlaceholderImg from "../../assets/images/placeholder.jpg";
import Card from "../../components/Card";
import Share from "../../assets/icons/share.svg";
import Heart from "../../assets/icons/heart.svg";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { GetItem } from "../../ItemCalls/ItemsApiCalls.js";

const ProjectPage = () => {
  const [informationsChosen, setInformationsChosen] = useState(true);
  const handleClickInformations = () => {
    setInformationsChosen(true);
  };
  const handleClickDonations = () => {
    setInformationsChosen(false);
  };

  const { projectId } = useParams();

  useEffect(() => {
    const generalProjectObject = getItem(projectId);
    console.log(generalProjectObject);
  }, []);

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
                <div className={classes.DescriptionText}>
                  Lorem ipsum dolor sit amet consectetur, adipisicing elit.
                  Doloribus, mollitia. Facilis, odit. Mollitia magnam itaque
                  libero aut expedita natus, perspiciatis molestias, beatae iure
                  quam modi reiciendis at cumque velit nulla. Lorem ipsum, dolor
                </div>
              ) : (
                <div className={classes.DescriptionText}>
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
              <span className={classes.InfoChoiceText}>Informations</span>
            </button>
            <button
              onClick={() => handleClickDonations()}
              className={
                !informationsChosen
                  ? classes.InfoChoiceChosen
                  : classes.InfoChoiceNotChosen
              }
            >
              <span className={classes.InfoChoiceText}>Donations</span>
            </button>
          </div>

          <div className={classes.SimilarSection}>
            <h3 className={classes.SimilarSectionTitle}>View similar</h3>
            <div className={classes.CardsContainer}>
              <Card />
              <Card />
              <Card />
            </div>
          </div>

          <div className={classes.MoreActionsContainer}>
            <button className={classes.MoreActionsButtonBlue}>
              <p className={classes.MoreActionsText}>DONATE</p>
            </button>
            <button className={classes.MoreActionsButton}>
              <img className={classes.SmallIcon} src={Share} alt="" />
              <p className={classes.MoreActionsText}>SHARE</p>
            </button>
            <button className={classes.MoreActionsButton}>
              <img className={classes.SmallIcon} src={Heart} alt="" />
              <p className={classes.MoreActionsText}>LIKE</p>
            </button>
          </div>
        </div>
      </div>
    </>
  );
};

export default ProjectPage;
