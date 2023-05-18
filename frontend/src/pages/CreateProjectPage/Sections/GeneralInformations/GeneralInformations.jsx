import { useState } from "react";
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
  const [keywords, setKeywords] = useState([]);

  const handleTextAreaResize = (e) => {
    const textarea = e.target;
    console.log(textarea.scrollHeight);
    textarea.style.height = textarea.scrollHeight + "px";
  };

  const addKeywordInput = () => {
    setKeywords((keywords) => [...keywords, "New keyword"]);
  };

  const removeEmptyKeywords = () => {
    const newKeywords = keywords.filter((keyword) => keyword !== "");
    setKeywords(newKeywords);
  };

  const handleChangeKeyword = (e, index) => {
    const newKeywords = [...keywords];
    newKeywords[index] = e.target.value;
    setKeywords(newKeywords);
  };

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
          <textarea
            placeholder="We are..."
            className={classes.sectionLargeInputArea}
            onInput={handleTextAreaResize}
          ></textarea>
        </div>
      </section>

      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Location</h3>
        <input
          type="text"
          placeholder="New York"
          className={classes.sectionInputText}
        />
      </section>

      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Date of foundation</h3>
        <div className={classes.sectionDateContainer}>
          <input
            type="number"
            min={1}
            max={31}
            placeholder="DD"
            className={classes.sectionDateInput}
          />
          <input
            type="number"
            min={1}
            max={29}
            placeholder="MM"
            className={classes.sectionDateInput}
          />
          <input
            type="number"
            min={1900}
            max={new Date().getFullYear()}
            placeholder="YYYY"
            className={classes.sectionDateInput}
          />
        </div>
      </section>

      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>
          Add up to 5 key words that describes your project
        </h3>
        <div className={classes.sectionKeywordsContainer}>
          {keywords.map((keyword, i) => {
            return (
              <input
                key={i}
                type="text"
                defaultValue={keyword}
                className={classes.sectionKeywordsItem}
                onBlur={removeEmptyKeywords}
                onChange={(e) => handleChangeKeyword(e, i)}
                contentEditable
              />
            );
          })}

          <button
            className={classes.sectionKeywordsButton}
            onClick={addKeywordInput}
          >
            +
          </button>
        </div>
      </section>

      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Website link of your project</h3>
        <input
          type="text"
          placeholder="www.edinvest.com"
          className={classes.sectionInputText}
        />
      </section>
    </>
  );
};

export default GeneralInformations;
