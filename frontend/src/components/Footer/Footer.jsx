import classes from "./index.module.css";

import FacebookIcon from "../../assets/icons/facebook.svg";
import InstagramIcon from "../../assets/icons/instagram.svg";
import LinkedInIcon from "../../assets/icons/linkedin.svg";
import TwitterIcon from "../../assets/icons/twitter.svg";

const Footer = () => {
  return (
    <footer className={classes.footer}>
      <div className="layoutSpacing">
        <div className={classes.footerLinks}>
          <nav className={classes.footerLinksNav}>
            <a href="/">Home</a>
            <a href="/about">About us</a>
            <a href="/projects">Projects</a>
          </nav>
          <div className={classes.footerLinksIcons}>
            <img src={FacebookIcon} alt="" />
            <img src={InstagramIcon} alt="" />
            <img src={LinkedInIcon} alt="" />
            <img src={TwitterIcon} alt="" />
          </div>
        </div>
        <p className={classes.footerCopy}>
          © 2023 EdInvest. Sva prava pridržana
        </p>
      </div>
    </footer>
  );
};

export default Footer;
