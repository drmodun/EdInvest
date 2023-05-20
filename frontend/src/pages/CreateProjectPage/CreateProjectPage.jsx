import { useEffect, useState } from "react";
import clsx from "clsx";

import classes from "./index.module.css";

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
        organisationId: "36ad10aa-bf8d-472f-9ab6-609a492718da",
      };

      console.log(event);
      createEvent(event).catch((err) => console.error(err));
    }

    if (data._TYPE === "course") {
      const course = {
        name: data.name,
        description: data.description,
        images: data.images,
        categoryId: data.categoryId,
        subcategoryId: data.subcategoryId,
        countryId: "0038575a-03dc-48af-9311-6e3720ddf058",
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

      console.log(course);
      createCourse(course).catch((err) => console.error(err));
    }

    if (projectType === "application") {
      const application = {
        name: data.name,
        description: data.description,
        images: data.images,
        categoryId: data.categoryId,
        subcategoryId: data.subcategoryId,
        countryId: "0038575a-03dc-48af-9311-6e3720ddf058",
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

      console.log(application);
      createApplication(application).catch((err) => console.error(err));
    }

    if (projectType === "online-course") {
      const onlineCourse = {
        name: data.name,
        description: data.description,
        images: data.images,
        categoryId: data.categoryId,
        subcategoryId: data.subcategoryId,
        countryId: "0038575a-03dc-48af-9311-6e3720ddf058",
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
        lessonsDate: {
          name: new Date().toISOString(),
        },
        averageDuration: +data.averageDuration,
        expectedAudience: +data.expectedAudience,
      };

      console.log(onlineCourse);
      createOnlineCourse(onlineCourse).catch((err) => console.error(err));
    }
  };

  useEffect(() => {
    //console.log(agree);
  }, [agree]);

  useEffect(() => {
    console.log("Data: ", data);
  }, [data]);

  useEffect(() => {
    //console.log("Project type: ", projectType);
    const name = data.name || "";
    setData({ name, _TYPE: projectType });
  }, [projectType]);

  const insertData = (key, value) => {
    setData({ ...data, [key]: value });
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
            <button
              className={clsx({
                [classes.sectionNavButton]: true,
                [classes.active]: section === 1,
              })}
              onClick={() => handleSectionChange(1)}
            >
              General informations
            </button>
            <button
              className={clsx({
                [classes.sectionNavButton]: true,
                [classes.active]: section === 2,
              })}
              onClick={() => handleSectionChange(2)}
            >
              Project picture
            </button>
            <button
              className={clsx({
                [classes.sectionNavButton]: true,
                [classes.active]: section === 3,
              })}
              onClick={() => handleSectionChange(3)}
            >
              Receiving funds
            </button>
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
          disabled={buttonStatus /*section > 2 && !agree*/}
        >
          {section === 3 ? "Publish" : "Continue"}
        </button>
      )}
    </div>
  );
};

export default CreateProjectPage;
