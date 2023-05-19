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

const GeneralInformations = ({ insertData, projectType, setProjectType }) => {
  const [features, setFeatures] = useState([]);
  const [date, setDate] = useState({
    day: "",
    month: "",
    year: "",
  });
  useEffect(() => {
    if (!date.day || !date.month || !date.year) return;
    const newDate = new Date(date.year, date.month - 1, date.day);
    insertData("date", newDate);
  }, [date]);

  const [startDate, setStartDate] = useState({
    day: "",
    month: "",
    year: "",
  });
  useEffect(() => {
    if (!startDate.day || !startDate.month || !startDate.year) return;
    const newDate = new Date(
      startDate.year,
      startDate.month - 1,
      startDate.day
    );
    insertData("startDate", newDate);
  }, [startDate]);

  const [endDate, setEndDate] = useState({
    day: "",
    month: "",
    year: "",
  });
  useEffect(() => {
    if (!endDate.day || !endDate.month || !endDate.year) return;
    const newDate = new Date(endDate.year, endDate.month - 1, endDate.day);
    insertData("endDate", newDate);
  }, [endDate]);

  const handleTextAreaResize = (e) => {
    const textarea = e.target;
    textarea.style.height = textarea.scrollHeight + "px";
  };

  const addFeaturesInput = () => {
    setFeatures((features) => [...features, "New feature"]);
  };

  const removeEmptyFeatures = () => {
    const newFeatures = features.filter((feature) => feature !== "");
    setFeatures(newFeatures);
  };

  const handleChangeFeature = (e, index) => {
    const newFeatures = [...features];
    newFeatures[index] = e.target.value;
    setFeatures(newFeatures);
    insertData("features", newFeatures);
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
          <option value="none">
            -- Please select the type of your project --
          </option>
          <option value="event">Event</option>
          <option value="course">Course</option>
        </select>
      </section>

      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Project category</h3>
        <select
          className={classes.sectionInputSelect}
          onChange={(e) => handleCategorySelect(e)}
        >
          <option value="none">-- Please select the category --</option>
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
          <option value="none">-- Please select the subcategory --</option>
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

      {/* LOCATION */}
      {projectType === "event" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>Location</h3>
          <input
            type="text"
            placeholder="New York"
            className={classes.sectionInputText}
            onChange={(e) => insertData("location", e.target.value)}
          />
        </section>
      )}

      {/* DATE */}
      {projectType === "event" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>Date of your event</h3>
          <div className={classes.sectionDateContainer}>
            <input
              type="text"
              maxLength={2}
              placeholder="DD"
              className={classes.sectionDateInput}
              id="day"
              onChange={(e) => setDate({ ...date, day: e.target.value })}
            />
            <input
              type="text"
              maxLength={2}
              placeholder="MM"
              id="month"
              className={classes.sectionDateInput}
              onChange={(e) => setDate({ ...date, month: e.target.value })}
            />
            <input
              type="text"
              maxLength={4}
              placeholder="YYYY"
              id="year"
              className={classes.sectionDateInput}
              onChange={(e) => setDate({ ...date, year: e.target.value })}
            />
          </div>
        </section>
      )}

      {/* TICKET PRICE */}
      {projectType === "event" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>
            Ticket price of your event (€)
          </h3>
          <input
            type="text"
            placeholder="Ticket price"
            className={classes.sectionInputText}
            onChange={(e) => insertData("ticketPrice", e.target.value)}
          />
        </section>
      )}

      {/* CAPACITY */}
      {projectType === "event" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>Capacity of your event</h3>
          <input
            type="text"
            placeholder="Capacity"
            className={classes.sectionInputText}
            onChange={(e) => insertData("capacity", e.target.value)}
          />
        </section>
      )}

      {/* FEATURES */}
      {projectType === "application" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>
            Add up to 5 features that your project is related to
          </h3>
          <div className={classes.sectionKeywordsContainer}>
            {features.map((feature, i) => {
              return (
                <input
                  key={i}
                  type="text"
                  defaultValue={feature}
                  className={classes.sectionKeywordsItem}
                  onBlur={removeEmptyFeatures}
                  onChange={(e) => handleChangeFeature(e, i)}
                  contentEditable
                />
              );
            })}
            <button
              className={classes.sectionKeywordsButton}
              onClick={addFeaturesInput}
            >
              +
            </button>
          </div>
        </section>
      )}

      {/* EXPECTED APPLICANTS */}
      {projectType === "course" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>
            Expected applicants for your course
          </h3>
          <input
            type="text"
            placeholder="Expected applicants"
            className={classes.sectionInputText}
            onChange={(e) => insertData("expectedApplicants", e.target.value)}
          />
        </section>
      )}

      {/* EXPECTED GRADUATES */}
      {projectType === "course" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>
            Expected graduates for your course
          </h3>
          <input
            type="text"
            placeholder="Expected graduates"
            className={classes.sectionInputText}
            onChange={(e) => insertData("expectedGraduates", e.target.value)}
          />
        </section>
      )}

      {/* START DATE */}
      {projectType === "course" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>Start date of your event</h3>
          <div className={classes.sectionDateContainer}>
            <input
              type="text"
              maxLength={2}
              placeholder="DD"
              className={classes.sectionDateInput}
              id="day"
              onChange={(e) =>
                setStartDate({ ...startDate, day: e.target.value })
              }
            />
            <input
              type="text"
              maxLength={2}
              placeholder="MM"
              id="month"
              className={classes.sectionDateInput}
              onChange={(e) =>
                setStartDate({ ...startDate, month: e.target.value })
              }
            />
            <input
              type="text"
              maxLength={4}
              placeholder="YYYY"
              id="year"
              className={classes.sectionDateInput}
              onChange={(e) =>
                setStartDate({ ...startDate, year: e.target.value })
              }
            />
          </div>
        </section>
      )}

      {/* END DATE */}
      {projectType === "course" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>End date of your event</h3>
          <div className={classes.sectionDateContainer}>
            <input
              type="text"
              maxLength={2}
              placeholder="DD"
              className={classes.sectionDateInput}
              id="day"
              onChange={(e) => setEndDate({ ...endDate, day: e.target.value })}
            />
            <input
              type="text"
              maxLength={2}
              placeholder="MM"
              id="month"
              className={classes.sectionDateInput}
              onChange={(e) =>
                setEndDate({ ...endDate, month: e.target.value })
              }
            />
            <input
              type="text"
              maxLength={4}
              placeholder="YYYY"
              id="year"
              className={classes.sectionDateInput}
              onChange={(e) => setEndDate({ ...endDate, year: e.target.value })}
            />
          </div>
        </section>
      )}

      {/* WEBSITE LINK */}
      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Website link of your project</h3>
        <input
          type="text"
          placeholder="www.edinvest.com"
          className={classes.sectionInputText}
          onChange={(e) => insertData("mainWebsite", e.target.value)}
        />
      </section>
    </>
  );
};

export default GeneralInformations;
