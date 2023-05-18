import classes from "./index.module.css";
import PlaceholderImg from "../../assets/images/placeholder.jpg";
import Card from "../../components/Card";
import Share from "../../assets/icons/share.svg";
import Heart from "../../assets/icons/heart.svg";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getItem } from "../../axios/ItemCalls/ItemsApiCalls.js";
import { getApplication } from "../../axios/ItemCalls/ApplicationApiCalls.js";
import { getOnlineCourse } from "../../axios/ItemCalls/OnlineCourseApiCalls.js";
import { getEvent } from "../../axios/ItemCalls/EventApiCalls.js";
import { getCourseById as getCourse } from "../../axios/ItemCalls/CourseApiCalls.js";
import { getOrganisationById } from "../../axios/UserCalls/OrganisationApiCalls.js";
import EventDescription from "../../components/ProjectPageComponents/EventDescription";
import DonationInfo from "../../components/ProjectPageComponents/DonationInfo";
import ApplicationDescription from "../../components/ProjectPageComponents/ApplicationDescripton";
import OnlineCourseDescription from "../../components/ProjectPageComponents/OnlineCourseDescription";
import CourseDescription from "../../components/ProjectPageComponents/CourseDescription/CourseDescription";

const ProjectPage = () => {
  const [informationsChosen, setInformationsChosen] = useState(true);
  const [project, setProject] = useState({});
  const [organisation, setOrganisation] = useState({});
  const handleClickInformations = () => {
    setInformationsChosen(true);
  };
  const handleClickDonations = () => {
    setInformationsChosen(false);
  };

  const { projectId } = useParams();

  useEffect(() => {
    (async () => {
      try {
        const data = await getItem(projectId);

        const id = data.id;
        const type = data.type;

        switch (type) {
          case 0:
            (async (id) => {
              try {
                const data = await getCourse(id);
                setProject(data);
              } catch (err) {
                console.log(err);
              }
            })(id);
            break;
          case 1:
            (async (id) => {
              try {
                const data = await getApplication(id);
                setProject(data);
              } catch (err) {
                console.log(err);
              }
            })(id);
            break;
          case 3:
            (async (id) => {
              try {
                const data = await getOnlineCourse(id);
                setProject(data);
              } catch (err) {
                console.log(err);
              }
            })(id);
            break;
          case 4:
            (async (id) => {
              try {
                const data = await getEvent(id);
                setProject(data);
              } catch (err) {
                console.log(err);
              }
            })(id);
            break;
        }

        const organisationData = await getOrganisationById(data.organisationId);
        console.log(organisationData);
        setOrganisation(organisationData);
      } catch (err) {
        console.log(err);
      }
    })();
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
                <h4 className={classes.BasicInfoTitle}>Host</h4>
                <h4 className={classes.BasicInfoText}>{organisation.name}</h4>
              </div>
              <div className={classes.BasicInfoBox}>
                <h4 className={classes.BasicInfoTitle}>Type</h4>
                <h4 className={classes.BasicInfoText}>Association</h4>
              </div>
              <div className={classes.BasicInfoBox}>
                <h4 className={classes.BasicInfoTitle}>Location</h4>
                <h4 className={classes.BasicInfoText}>
                  {organisation.locationName}
                </h4>
              </div>
              <div className={classes.BasicInfoBox}>
                <h4 className={classes.BasicInfoTitle}>Founded</h4>
                <h4 className={classes.BasicInfoText}>2010</h4>
              </div>
            </div>

            <div>
              {informationsChosen ? (
                <div className={classes.DescriptionText}>
                  {project.type === 0 && (
                    <CourseDescription project={project} />
                  )}
                  {project.type === 1 && (
                    <ApplicationDescription project={project} />
                  )}
                  {project.type === 3 && (
                    <OnlineCourseDescription project={project} />
                  )}
                  {project.type === 4 && <EventDescription project={project} />}
                </div>
              ) : (
                <div className={classes.DescriptionText}>
                  <DonationInfo project={project} />
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
