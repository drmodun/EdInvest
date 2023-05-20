import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import Heart from "../../assets/icons/heart.svg";
import Share from "../../assets/icons/share.svg";
import PlaceholderImg from "../../assets/images/placeholder.jpg";
import {
  getSubcategory
} from "../../axios/CategoryCalls/SubcategoryApiCalls";
import { getApplication } from "../../axios/ItemCalls/ApplicationApiCalls.js";
import { getCourseById as getCourse } from "../../axios/ItemCalls/CourseApiCalls.js";
import { getEvent } from "../../axios/ItemCalls/EventApiCalls.js";
import { getItem, getItems } from "../../axios/ItemCalls/ItemsApiCalls.js";
import { getOnlineCourse } from "../../axios/ItemCalls/OnlineCourseApiCalls.js";
import Card from "../../components/Card";
import { MakeDonation } from "../../components/MakeDonation/MakeDonation";
import ApplicationDescription from "../../components/ProjectPageComponents/ApplicationDescripton";
import CourseDescription from "../../components/ProjectPageComponents/CourseDescription";
import DonationInfo from "../../components/ProjectPageComponents/DonationInfo";
import EventDescription from "../../components/ProjectPageComponents/EventDescription";
import OnlineCourseDescription from "../../components/ProjectPageComponents/OnlineCourseDescription";
import classes from "./index.module.css";

const ProjectPage = () => {
  const [informationsChosen, setInformationsChosen] = useState("Info");
  const [project, setProject] = useState({});
  const [subcategory, setSubcategory] = useState({});
  const [similarProjects, setSimilarProjects] = useState([]);
  const handleClickInformations = () => {
    setInformationsChosen("Info");
  };
  const handleClickDonations = () => {
    setInformationsChosen("Donations");
  };

  const dict = {
    0: "Course",
    1: "Application",
    3: "Online Course",
    4: "Event",
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
          default:
            break;
        }
        const subcategoryCall = await getSubcategory(data.subcategoryId);
        setSubcategory(subcategoryCall);
        const getSimilarProjects = await getItems({
          categoryId: data.categoryId,
        });
        setSimilarProjects(getSimilarProjects.items);
        console.log(project);
        console.log(subcategory);
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
                <Link to={"/organisations/" + project.organisationId}>
                  <h4 className={classes.LinkedInfoText}>
                    {project.organisationName}
                  </h4>
                </Link>
              </div>
              <div className={classes.BasicInfoBox}>
                <h4 className={classes.BasicInfoTitle}>Type</h4>
                <h4 className={classes.BasicInfoText}>{dict[project.type]}</h4>
              </div>
              <div className={classes.BasicInfoBox}>
                <h4 className={classes.BasicInfoTitle}>Subcategory</h4>
                <h4 className={classes.BasicInfoText}>{subcategory.name}</h4>
              </div>
              <div className={classes.BasicInfoBox}>
                <h4 className={classes.BasicInfoTitle}>Progress</h4>
                <h4 className={classes.BasicInfoText}>
                  {Math.round((project.currentAmount / project.goal) * 100) +
                    "%"}
                </h4>
              </div>
            </div>

            <div>
              {informationsChosen === "Info" ? (
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
              ) : informationsChosen === "Donations" ? (
                <div className={classes.DescriptionText}>
                  <DonationInfo project={project} />
                </div>
              ) : (
                project.images && (
                  <MakeDonation
                    id={project.id}
                    name={project.name}
                    pic={project.images[0]}
                    tierAmount={Object.keys(project.tiers).length}
                    prices={project.prices}
                  ></MakeDonation>
                )
              )}
            </div>
          </div>
          <div className={classes.InfoChoiceWrapper}>
            <button
              onClick={() => handleClickInformations()}
              className={
                informationsChosen === "Info"
                  ? classes.InfoChoiceChosen
                  : classes.InfoChoiceNotChosen
              }
            >
              <span className={classes.InfoChoiceText}>Informations</span>
            </button>
            <button
              onClick={() => handleClickDonations()}
              className={
                informationsChosen === "Donations"
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
              {similarProjects.length > 1
                ? similarProjects.map(
                    (projectToMap) =>
                      projectToMap.id !== project.id && (
                        <Card
                          description={projectToMap.description}
                          id={projectToMap.id}
                          isVerified={projectToMap}
                          type={projectToMap.type}
                          key={projectToMap.id}
                          image={projectToMap.images[0]}
                          name={projectToMap.name}
                          raised={
                            projectToMap.currentAmount
                              ? projectToMap.currentAmount
                              : "0"
                          }
                        />
                      )
                  )
                : "No similar projects found"}
            </div>
          </div>

          <div className={classes.MoreActionsContainer}>
            <button
              className={classes.MoreActionsButtonBlue}
              onClick={() => setInformationsChosen("Donate")}
            >
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
