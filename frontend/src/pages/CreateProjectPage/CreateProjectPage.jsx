import { useEffect, useState } from "react";
import clsx from "clsx";
import { getCategories } from "../../axios/CategoryCalls/CategoryApiCalls";

import classes from "./index.module.css";

import GeneralInformations from "./Sections/GeneralInformations";
import ProjectPicture from "./Sections/ProjectPicture";
import ReceivingFunds from "./Sections/ReceivingFunds";
import FinalMessage from "./Sections/FinalMessage";

const CreateProjectPage = () => {
  const [data, setData] = useState({});
  const [projectType, setProjectType] = useState("");

  useEffect(() => {
    console.log("Data: ", data);
  }, [data]);

  useEffect(() => {
    console.log("Project type: ", projectType);
  }, [projectType]);

  const insertData = (key, value) => {
    setData({ ...data, [key]: value });
  };

  const [section, setSection] = useState(1);

  const handleSectionChange = (section) => {
    setSection(section);
  };

  const increaseSection = () => {
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
          insertData={insertData}
          projectType={projectType}
          setProjectType={setProjectType}
        />
      ) : null}
      {section === 2 && <ProjectPicture insertData={insertData} />}
      {section === 3 && <ReceivingFunds insertData={insertData} />}
      {section === 4 && <FinalMessage insertData={insertData} />}

      {section < 4 && (
        <button className={classes.continueButton} onClick={increaseSection}>
          {section === 3 ? "Publish" : "Continue"}
        </button>
      )}
    </div>
  );
};

export default CreateProjectPage;
