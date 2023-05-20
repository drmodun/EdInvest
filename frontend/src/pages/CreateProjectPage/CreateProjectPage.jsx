import { useEffect, useState } from "react";
import clsx from "clsx";

import classes from "./index.module.css";
//due to short deadline some inputs had to be simplified
import GeneralInformations from "./Sections/GeneralInformations";
import ProjectPicture from "./Sections/ProjectPicture";
import ReceivingFunds from "./Sections/ReceivingFunds";
import FinalMessage from "./Sections/FinalMessage";

import { createEvent } from "../../axios/ItemCalls/EventApiCalls";
import { createCourse } from "../../axios/ItemCalls/CourseApiCalls";
import { createApplication } from "../../axios/ItemCalls/ApplicationApiCalls";
import { createOnlineCourse } from "../../axios/ItemCalls/OnlineCourseApiCalls";

const CreateProjectPage = () => {
  const [data, setData] = useState({});
  const [projectType, setProjectType] = useState("");
  const [agree, setAgree] = useState(false);
  const [buttonStatus, setButtonStatus] = useState(true);
  const userInfo = JSON.parse(localStorage.getItem("userInfo"));
  const handleCreateProject = () => {
    if (section < 3) return;

    if (data._TYPE === "event") {
      const event = {
        name: data.name,
        description: data.description,
        images: data.images,
        categoryId: data.categoryId,
        subcategoryId: data.subcategoryId,
        countryId: "0038575a-03dc-48af-9311-6e3720ddf058", // Default: Azerbaijan
        goal: +data.goal,
        mainWebsite: data.mainWebsite,
        prices: data.prices,
        tiers: data.tiers,
        date: data.date.toISOString(),
        location: data.location,
        activities: {
          time: "activity",
        },
        ticketPrice: +data.ticketPrice,
        notableAttendees: ["Attendee"],
        notableSpeakers: ["Speaker"],
        capacity: +data.capacity,
        expectedAttendees: 0,
      };

      createEvent(event).catch((err) => console.error(err));
    }

    if (data._TYPE === "course") {
      const course = {
        name: data.name,
        description: data.description,
        images: data.images,
        categoryId: data.categoryId,
        subcategoryId: data.subcategoryId,
        goal: +data.goal,
        mainWebsite: data.mainWebsite,
        prices: data.prices,
        tiers: data.tiers,
        expectedApplicants: data.expectedApplicants,
        expectedGraduates: data.expectedGraduates,
        startDate: data.startDate.toISOString(),
        endDate: data.endDate.toISOString(),
        curriculum: {
          example: "name",
        },
        activeStudents: 1,
      };

      createCourse(course).catch((err) => console.error(err));
    }

    if (projectType === "application") {
      const application = {
        name: data.name,
        description: data.description,
        images: data.images,
        categoryId: data.categoryId,
        subcategoryId: data.subcategoryId,
        goal: +data.goal,
        mainWebsite: data.mainWebsite,
        prices: data.prices,
        tiers: data.tiers,
        estimatedRelease: data.estimatedRelease.toISOString(),
        appPurpose: data.appPurpose,
        markets: ["market"],
        features: data.features,
        estimatedNumberOfUsers: +data.estimatedNumberOfUsers,
      };

      createApplication(application).catch((err) => console.error(err));
    }

    if (projectType === "online-course") {
      const onlineCourse = {
        name: data.name,
        description: data.description,
        images: data.images,
        categoryId: data.categoryId,
        subcategoryId: data.subcategoryId,
        goal: +data.goal,
        mainWebsite: data.mainWebsite,
        prices: data.prices,
        tiers: data.tiers,
        linksToChannels: {
          name: "link",
        },
        lessons: {
          name: "lesson",
        },
        lessonsDate: [new Date().toISOString()],
        averageDuration: +data.averageDuration,
        expectedAudience: +data.expectedAudience,
      };

      createOnlineCourse(onlineCourse).catch((err) => console.error(err));
    }
  };

  useEffect(() => {
    const name = data.name || "";
    setData({
      name,
      _TYPE: projectType,
      categoryId: data.categoryId ? data.categoryId : "",
      subcategoryId: data.subcategoryId ? data.subcategoryId : "",
      description: data.description ? data.description : "",
      images: data.images ? data.images : [],
      goal: data.goal ? data.goal : "",
      mainWebsite: data.mainWebsite ? data.mainWebsite : "",
      prices: data.prices ? data.prices : [],
      tiers: data.tiers ? data.tiers : [],
    });
  }, [projectType]);

  const insertData = (key, value) => {
    setData((data) => ({ ...data, [key]: value }));
  };

  const [section, setSection] = useState(1);

  const handleSectionChange = (section) => {
    setSection(section);
  };

  const increaseSection = () => {
    handleCreateProject();
    const newSection = section + 1;
    setSection(newSection);
  };

  useEffect(() => {
    if (section === 4) {
      document
        .querySelector(":root")
        .style.setProperty("--create-content-right-margin", "63px");
    }
  }, [section]);

  return (
    <div className={"layoutSpacing " + classes.content}>
      {section < 4 ? (
        <>
          <h1 className={classes.title}>Create a project</h1>
          <div className={classes.sectionNav}>
            <div
              className={clsx({
                [classes.sectionNavButton]: true,
                [classes.active]: section === 1,
                [classes.disabled]: section > 1,
              })}
              disabled={section > 1}
            >
              General informations
            </div>
            <div
              className={clsx({
                [classes.sectionNavButton]: true,
                [classes.active]: section === 2,
                [classes.disabled]: section > 2,
              })}
              disabled={section > 2}
            >
              Project picture
            </div>
            <div
              className={clsx({
                [classes.sectionNavButton]: true,
                [classes.active]: section === 3,
                [classes.disabled]: section > 3,
              })}
              disabled={section > 3}
            >
              Receiving funds
            </div>
          </div>
        </>
      ) : null}
      {section === 1 ? (
        <GeneralInformations
          data={data}
          setData={setData}
          insertData={insertData}
          projectType={projectType}
          setProjectType={setProjectType}
          setButtonStatus={setButtonStatus}
        />
      ) : null}
      {section === 2 && <ProjectPicture insertData={insertData} />}
      {section === 3 && (
        <ReceivingFunds insertData={insertData} setAgree={setAgree} />
      )}
      {section === 4 && <FinalMessage data={data} />}

      {section < 4 && (
        <button
          className={classes.continueButton}
          onClick={increaseSection}
          disabled={buttonStatus || userInfo.type !== 2/*section > 2 && !agree*/}
        >
          {section === 3 ? "Publish" : "Continue"}
        </button>
      )}
      {(!userInfo || userInfo.type!==2) && <span className={classes.Warning}>You have to be logged in as an organisation to continue</span>} 
    </div>
  );
};

export default CreateProjectPage;
