import { useEffect, useState } from "react";
import clsx from "clsx";

import classes from "./index.module.css";

import GeneralInformations from "./Sections/GeneralInformations";
import ProjectPicture from "./Sections/ProjectPicture";
import ReceivingFunds from "./Sections/ReceivingFunds";
import FinalMessage from "./Sections/FinalMessage";

const CreateProjectPage = () => {
  const [section, setSection] = useState(1);

  const handleSectionChange = (section) => {
    setSection(section);
  };

  const increaseSection = () => {
    const newSection = section + 1;
    setSection(newSection);
  };

  const handleRightMargin = useEffect(() => {
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
      {section === 1 ? <GeneralInformations /> : null}
      {section === 2 ? <ProjectPicture /> : null}
      {section === 3 ? <ReceivingFunds /> : null}
      {section === 4 ? <FinalMessage /> : null}

      {section < 4 ? (
        <button className={classes.continueButton} onClick={increaseSection}>
          {section === 3 ? "Publish" : "Continue"}
        </button>
      ) : null}
    </div>
  );
};

export default CreateProjectPage;
