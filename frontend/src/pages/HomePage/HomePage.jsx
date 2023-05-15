import HeaderBackground from "../../assets/header-background.png";
import ChevronRightBlack from "../../assets/chevron-right-black.svg";
import ChevronRightWhite from "../../assets/chevron-right-white.svg";
import ChevronRightBlue from "../../assets/chevron-right-blue.svg";
import ArrowLeft from "../../assets/arrow-left.svg";
import classes from "./index.module.css";
import Button from "../../components/Button";

const HomePage = () => {
  document
    .querySelector(":root")
    .style.setProperty("--header-background", "var(--color-blue)");
  document
    .querySelector(":root")
    .style.setProperty("--header-nav-color", "white");
  return (
    <div className="headerMargin">
      <div className={classes.HeaderHeroWrapper}>
        <img
          className={classes.HeaderHeroBackgroundImg}
          src={HeaderBackground}
          alt=""
        />
        <div className={classes.HeaderHeroTextWrapper}>
          <h1 className={classes.HeaderHeroTitle}>
            Invest in minds, supports with crypto
          </h1>
          <h3 className={classes.HeaderHeroSubtitle}>
            With blockchain technology, we transform project funding, esuring
            efficiency, trust, and accountability. Join us in reshaping
            education for a brighter future. Together, let’s unlock the
            potential of education and make a lasting impact on learners
            worlwide.
          </h3>

          <div className={classes.HeaderHeroButtonsWrapper}>
            <button className={classes.HeaderHeroWhiteButton}>
              <span className={classes.WhiteButtonText}>Explore projects</span>
              <img src={ChevronRightBlack} />
            </button>
            <button className={classes.TransparentButton}>
              <span className={classes.TransparentButtonText}>Our mission</span>
              <img src={ChevronRightWhite} />
            </button>
          </div>
        </div>
      </div>

      <div className={classes.TrustSection}>
        <h2 className={classes.TrustSectionTitle}>We have your back.</h2>
        <h4 className={classes.TrustSectionDescription}>
          Cryptocurrencies are built on blockchain technology, which provides a
          high level of security and transparency. Each transaction is securely
          recorded and verified on the blockchain, ensuring the integrity of the
          funding process.
        </h4>
        <button className={classes.TrustSectionButton}>
          <span>Trust & Safety</span>
          <img src={ChevronRightBlue} alt="" />
        </button>
      </div>

      <div className={classes.PromoSectionWrapper}>
        <div className={classes.PromoSectionBackground}></div>
        <div className={classes.PromoSectionContent}>
          <div className={classes.PromoSectionLeft}>
            <h2 className={classes.PromoSectionLeftTitle}>Worth investing</h2>
            <h4 className={classes.PromoSectionLeftDescription}>
              There’s a reason high net worth individuals tend to donate
              property instead of cash.
            </h4>
          </div>
          <div className={classes.PromoSectionRight}>
            <div className={classes.PromoSectionRightButtonsContainer}>
              <button className={classes.PromoSectionLeftButton}>
                <img src={ArrowLeft} alt="" />
              </button>
              <button className={classes.PromoSectionRightButton}>
                <img src={ArrowLeft} alt="" />
              </button>
            </div>
            <div className={classes.PromoSectionRightCardsContainer}>
              <div className={classes.Card}></div>
              <div className={classes.Card}></div>
              <div className={classes.Card}></div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default HomePage;
