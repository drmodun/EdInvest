import HeaderBackground from "../../assets/header-background.png";
import classes from "./index.module.css";

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
        <h1 className={classes.HeaderHeroTitle}>
          Invest in minds, supports with crypto
        </h1>
      </div>
    </div>
  );
};

export default HomePage;
