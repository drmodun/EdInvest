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

      <div className={classes.TaxesSection}>
        <div className={classes.MoreInfoImg}></div>
        <div className={classes.TaxesSectionRight}>
          <h3 className={classes.MoreInfoTitle}>
            Save on your taxes by investing with crypto
          </h3>
          <p className={classes.MoreInfoText}>
            There’s a reason high net worth individuals tend to donate property
            instead of cash. Want to maximize your tax savings via charitable
            giving? This is how. Lorem ipsum dolor sit amet, consectetur
            adipiscing elit, sed do eiusmod.
          </p>
        </div>
      </div>

      <div className={classes.NewsSection}>
        <h2 className={classes.NewsSectionTitle}>Our recent news & insights</h2>
        <div className={classes.NewsWrapper}>
          <div className={classes.NewsContainer}>
            <div className={classes.NewsImg}></div>
            <p className={classes.NewsText}>8 MIN TO READ</p>
            <h4 className={classes.NewsTitle}>
              Everything You Need To Know About Crypto
            </h4>
          </div>
          <div className={classes.NewsContainer}>
            <div className={classes.NewsImg}></div>
            <p className={classes.NewsText}>10 MIN TO READ</p>
            <h4 className={classes.NewsTitle}>
              Seven Signs You're In Love With EdInvest
            </h4>
          </div>
          <div className={classes.NewsContainer}>
            <div className={classes.NewsImg}></div>
            <p className={classes.NewsText}>12 MIN TO READ</p>
            <h4 className={classes.NewsTitle}>Learn more about philantropy</h4>
          </div>
        </div>
      </div>

      <div className={classes.MissionSection}>
        <h2 className={classes.MissionTitle}>Our mission</h2>
        <p className={classes.MissionText}>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
          eiusmod.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed
          do eiusmod.Lorem ipsum dolor sit amet, consectetur adipiscing elit,
          sed do eiusmod.Lorem ipsum dolor sit amet, consectetur adipiscing
          elit, sed do eiusmod.Lorem ipsum dolor sit amet, consectetur
          adipiscing elit, sed do eiusmod.Lorem ipsum dolor sit amet,
          consectetur adipiscing elit, sed do eiusmod.
        </p>
      </div>

      <div className={classes.TeamSection}>
        <h2 className={classes.TeamSectionTitle}>Meet our beloved team</h2>
        <div className={classes.TeamMembersWrapper}>
          <div className={classes.TeamMemberImg}></div>
          <div className={classes.TeamMemberImg}></div>
          <div className={classes.TeamMemberImg}></div>
          <div className={classes.TeamMemberImg}></div>
          <div className={classes.TeamMemberImg}></div>
        </div>
      </div>
    </>
  );
};

export default AboutPage;
