import classes from "./index.module.css";

const AboutPage = () => {
  return (
    <>
      <div className={`headerMargin ` + classes.HeaderWrapper}>
        <h2 className={classes.HeaderTitle}>EdInvest</h2>
      </div>

      <div className={classes.MoreInfoSection}>
        <div className={classes.MoreInfoSectionLeft}>
          <h3 className={classes.MoreInfoTitle}>What is EdInvest?</h3>
          <p className={classes.MoreInfoText}>
            EdInvest is an innovative platform that uses crypto funding to
            support education projects. Our platform allows individuals to
            contribute, invest, and donate to a wide range of education
            projects. By accepting cryptocurrencies, we make it easy for people
            around the world to get involved.
          </p>
        </div>
        <div className={classes.MoreInfoImg}></div>
      </div>

      <div className={classes.PerksSectionWrapper}>
        <div className={classes.PerksSection}>
          <div className={classes.PerkContainer}>
            <div className={classes.PerkImg}></div>
            <h4 className={classes.PerkTitle}>Zero fraud</h4>
            <p className={classes.PerkText}>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
              eiusmod.
            </p>
          </div>
          <div className={classes.PerkContainer}>
            <div className={classes.PerkImg}></div>
            <h4 className={classes.PerkTitle}>Transparent paying</h4>
            <p className={classes.PerkText}>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
              eiusmod.
            </p>
          </div>
          <div className={classes.PerkContainer}>
            <div className={classes.PerkImg}></div>
            <h4 className={classes.PerkTitle}>Philantropy</h4>
            <p className={classes.PerkText}>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
              eiusmod.
            </p>
          </div>
        </div>
      </div>
    </>
  );
};

export default AboutPage;
