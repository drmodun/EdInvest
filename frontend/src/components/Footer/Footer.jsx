import classes from "./index.module.css";

const Footer = () => {
  return (
    <footer className={classes.footer}>
      <div className="layoutSpacing">
        <div className={classes.footerLinks}>
          <nav className={classes.footerLinksNav}>
            <a href="/">Home</a>
            <a href="">About us</a>
            <a href="/projects">Projects</a>
          </nav>
          <div className={classes.footerLinksIcons}>
            <div></div>
            <div></div>
            <div></div>
            <div></div>
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
