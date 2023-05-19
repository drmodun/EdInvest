import { useState, useEffect } from "react";
import classes from "../../index.module.css";
import { getCategories } from "../../../../axios/CategoryCalls/CategoryApiCalls";

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

const GeneralInformations = ({ insertData, setProjectType }) => {
  const [keywords, setKeywords] = useState([]);

  const handleTextAreaResize = (e) => {
    const textarea = e.target;
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

  const moveToNextField = (input, next) => {
    console.log("NEXT");

    const value = input.value;
    const maxLength = parseInt(input.getAttribute("maxlength"));

    if (value.length === maxLength) {
      document.getElementById(next).focus();
    }
  };

  // CATEGORIES
  const [categories, setCategories] = useState([]);
  const [subcategories, setSubcategories] = useState([]);
  useEffect(() => {
    getCategories()
      .then((res) => res.categories)
      .then((data) => setCategories(data))
      .catch((err) => console.error(err));
  });

  const handleCategorySelect = (e) => {
    insertData("categoryId", e.target.value);
    const categoryName = e.target.options[e.target.selectedIndex].text;
    const category = categories.find(
      (category) => category.name === categoryName
    );
    setSubcategories(category.subcategories);
  };

  return (
    <>
      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Project Name</h3>
        <input
          type="text"
          placeholder="My First Project"
          className={classes.sectionInputText}
          onChange={(e) => insertData("name", e.target.value)}
        />
      </section>

      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Type of project</h3>
        <select
          className={classes.sectionInputSelect}
          onChange={(e) => setProjectType(e.target.value)}
        >
          <option value="event">Event</option>
          <option value="application">Application</option>
          <option value="course">Course</option>
          <option value="online-course">Online Course</option>
        </select>
      </section>

      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Project category</h3>
        <select
          className={classes.sectionInputSelect}
          onChange={(e) => handleCategorySelect(e)}
        >
          {categories.map((category) => (
            <option key={category.id} value={category.id}>
              {category.name}
            </option>
          ))}
        </select>
        <select
          className={classes.sectionInputSelect}
          onChange={(e) => insertData("subcategoryId", e.target.value)}
          disabled={subcategories.length === 0}
        >
          {subcategories.map((subcategory) => (
            <option key={subcategory.id} value={subcategory.id}>
              {subcategory.name}
            </option>
          ))}
        </select>
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
            onChange={(e) => insertData("description", e.target.value)}
          ></textarea>
        </div>
      </section>

      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Location</h3>
        <input
          type="text"
          placeholder="New York"
          className={classes.sectionInputText}
          onChange={(e) => insertData("location", e.target.value)}
        />
      </section>

      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Date of foundation</h3>
        <div className={classes.sectionDateContainer}>
          <input
            type="text"
            maxLength={2}
            placeholder="DD"
            className={classes.sectionDateInput}
            id="day"
            onChange={(e) => moveToNextField(e.target, "month")}
          />
          <input
            type="text"
            maxLength={2}
            placeholder="MM"
            id="month"
            className={classes.sectionDateInput}
            onChange={(e) => moveToNextField(e.target, "year")}
          />
          <input
            type="text"
            maxLength={4}
            min={1900}
            max={new Date().getFullYear()}
            placeholder="YYYY"
            id="year"
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
