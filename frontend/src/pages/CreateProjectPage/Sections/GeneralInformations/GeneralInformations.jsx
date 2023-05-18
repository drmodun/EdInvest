import classes from "../../index.module.css";

import H1Icon from "../../../../assets/icons/h1.svg";
import H2Icon from "../../../../assets/icons/h2.svg";
import BoldIcon from "../../../../assets/icons/bold.svg";
import ItalicIcon from "../../../../assets/icons/italic.svg";
import UnderlineIcon from "../../../../assets/icons/underline.svg";
import StriketroughIcon from "../../../../assets/icons/striketrough.svg";
import QuoteIcon from "../../../../assets/icons/quote.svg";
import OrderedListIcon from "../../../../assets/icons/ordered-list.svg";
import UnorderedListIcon from "../../../../assets/icons/unordered-list.svg";
import IncreaseTabIcon from "../../../../assets/icons/increase-tab.svg";
import DecreaseTabIcon from "../../../../assets/icons/decrease-tab.svg";
import HyperlinkIcon from "../../../../assets/icons/hyperlink.svg";
import PictureIcon from "../../../../assets/icons/picture.svg";
import FilmIcon from "../../../../assets/icons/film.svg";

const GeneralInformations = () => {
  return (
    <>
      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Project Name</h3>
        <input
          type="text"
          placeholder="My First Project"
          className={classes.sectionInputText}
        />
      </section>

      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Type of project</h3>
        <input
          type="text"
          placeholder="Event"
          className={classes.sectionInputText}
        />
      </section>

      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Project description</h3>
        <p className={classes.sectionDescription}>
          Take in consideration that a good project description is essential for
          securing investment and ensuring the success of the project.
        </p>
        <div className={classes.sectionInputLarge}>
          <div className={classes.sectionLargeInputHeader}>
            <img src={H1Icon} alt="" />
            <img src={H2Icon} alt="" />
            <img src={BoldIcon} alt="" />
            <img src={ItalicIcon} alt="" />
            <img src={UnderlineIcon} alt="" />
            <img src={StriketroughIcon} alt="" />
            <img src={QuoteIcon} alt="" />
            <img src={OrderedListIcon} alt="" />
            <img src={UnorderedListIcon} alt="" />
            <img src={IncreaseTabIcon} alt="" />
            <img src={DecreaseTabIcon} alt="" />
            <img src={HyperlinkIcon} alt="" />
            <img src={PictureIcon} alt="" />
            <img src={FilmIcon} alt="" />
          </div>
          <textarea className={classes.sectionLargeInputArea}></textarea>
        </div>
      </section>
    </>
  );
};

export default GeneralInformations;
