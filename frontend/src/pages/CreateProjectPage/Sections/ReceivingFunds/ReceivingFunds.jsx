import classes from "../../index.module.css";

import AttentionIcon from "../../../../assets/icons/attention.svg";

const ReceivingFunds = ({ insertData, setAgree }) => {
  return (
    <>
      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Add your project goal</h3>
        <input
          type="text"
          placeholder="Enter goal amount (€)"
          className={classes.sectionInputText}
          onChange={(e) => insertData("goal", e.target.value)}
        />
      </section>

      <section className={classes.sectionPublish}>
        <h3 className={classes.sectionPublishTitle}>Let's publish!</h3>
        <p className={classes.sectionDescription}>
          Please take in consideration that after you publish your project our
          team will take some time to review your project and approve it. This
          might take a few days so don't worry if you don't find it on project
          list. You'll receive an email from us once your project is listed.
        </p>
        <div className={classes.sectionCheckboxWrapper}>
          <input
            className={classes.sectionCheckbox}
            type="checkbox"
            id="submissionGuidlines"
            onClick={(e) => setAgree(e.target.checked)}
          />
          <label
            className={classes.sectionCheckboxLabel}
            htmlFor="submissionGuidlines"
          >
            I agree with submission guidlines
          </label>
        </div>
        <div className={classes.sectionAttention}>
          <img src={AttentionIcon} alt="" />
          <p>Preview your project information before you publish it.</p>
        </div>
      </section>
    </>
  );
};

export default ReceivingFunds;
