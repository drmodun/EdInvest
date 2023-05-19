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

const GeneralInformations = ({
  data,
  setData,
  insertData,
  projectType,
  setProjectType,
  setButtonStatus,
}) => {
  const [status, setStatus] = useState({
    name: false,
    type: false,
    category: false,
    subcategory: false,
    description: false,
    tiers: false,
    location: false,
    date: false,
    ticketPrice: false,
    capacity: false,
    expectedApplicants: false,
    expectedGraduates: false,
    startDate: false,
    endDate: false,
    estimatedRelease: false,
    appPurpose: false,
    features: false,
    estimatedNumberOfUsers: false,
    averageDuration: false,
    expectedAudience: false,
    link: false,
  });

  const updateStatus = () => {
    console.log("updated");
    setStatus({
      name: data.name !== "" && data.name !== undefined,
      type: data._TYPE !== "" && data._TYPE !== undefined,
      category: data.categoryId !== "" && data.categoryId !== undefined,
      subcategory:
        data.subcategoryId !== "" && data.subcategoryId !== undefined,
      description: data.description !== "" && data.description !== undefined,
      tiers: data.tiers && data.tiers.length !== 0 && data.tiers[0] !== "",
      location: data.location !== "" && data.location !== undefined,
      date: data.date !== "" && data.date !== undefined,
      ticketPrice: data.ticketPrice !== "" && data.ticketPrice !== undefined,
      capacity: data.capacity !== "" && data.capacity !== undefined,
      expectedApplicants:
        data.expectedApplicants !== "" && data.expectedApplicants !== undefined,
      expectedGraduates:
        data.expectedGraduates !== "" && data.expectedGraduates !== undefined,
      startDate: data.startDate !== "" && data.startDate !== undefined,
      endDate: data.endDate !== "" && data.endDate !== undefined,
      estimatedRelease:
        data.estimatedRelease !== "" && data.estimatedRelease !== undefined,
      appPurpose: data.appPurpose !== "" && data.appPurpose !== undefined,
      features:
        data.features && data.features.length !== 0 && data.features[0] !== "",
      estimatedNumberOfUsers:
        data.estimatedNumberOfUsers !== "" &&
        data.estimatedNumberOfUsers !== undefined,
      averageDuration:
        data.averageDuration !== "" && data.averageDuration !== undefined,
      expectedAudience:
        data.expectedAudience !== "" && data.expectedAudience !== undefined,
      link: data.mainWebsite !== "" && data.mainWebsite !== undefined,
    });
  };

  useEffect(() => {
    updateStatus();
    let newButtonStatus =
      status.name &&
      status.type &&
      status.category &&
      status.subcategory &&
      status.description &&
      status.tiers &&
      status.link;

    if (data._TYPE == "event")
      newButtonStatus =
        newButtonStatus &&
        status.date &&
        status.location &&
        status.ticketPrice &&
        status.capacity;

    if (data._TYPE == "course")
      newButtonStatus =
        newButtonStatus &&
        status.expectedApplicants &&
        status.expectedGraduates &&
        status.startDate &&
        status.endDate;

    if (data._TYPE == "application")
      newButtonStatus =
        newButtonStatus &&
        status.estimatedRelease &&
        status.appPurpose &&
        status.features &&
        status.estimatedNumberOfUsers;

    if (data._TYPE == "online-course")
      newButtonStatus =
        newButtonStatus && status.averageDuration && status.expectedAudience;

    setButtonStatus(!newButtonStatus);
  }, [data]);

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

  const [estimatedRelease, setEstimatedRelease] = useState({
    day: "",
    month: "",
    year: "",
  });
  useEffect(() => {
    if (
      !estimatedRelease.day ||
      !estimatedRelease.month ||
      !estimatedRelease.year
    )
      return;
    const newDate = new Date(
      estimatedRelease.year,
      estimatedRelease.month - 1,
      estimatedRelease.day
    );
    insertData("estimatedRelease", newDate);
  }, [estimatedRelease]);

  // TIERS
  const [tiers, setTiers] = useState({});
  const [tierPrices, setTierPrices] = useState([]);

  const [currentTiers, setCurrentTiers] = useState([]);
  const emptyTier = {
    name: "",
    description: "",
    price: "",
  };

  useEffect(() => {
    let newTiers = {};
    let newTierPrices = [];
    currentTiers.forEach((tier) => {
      if (tier.name !== "") {
        newTiers[tier.name] = tier.description;
        newTierPrices.push(+tier.price);
      }
    });
    setTiers(newTiers);
    setTierPrices(newTierPrices);

    setData({ ...data, tiers: newTiers, prices: newTierPrices });
  }, [currentTiers]);

  const removeCurrentTier = (index) => {
    const newTiers = [...currentTiers];
    newTiers.splice(index, 1);
    setCurrentTiers(newTiers);
  };

  const addCurrentTier = () => {
    const newTiers = [...currentTiers];
    newTiers.push(emptyTier);
    setCurrentTiers(newTiers);
  };

  const handleChangeTier = (e, index, key) => {
    const newTiers = [...currentTiers];
    newTiers[index][key] = e.target.value;
    setCurrentTiers(newTiers);
  };

  // TEXT AREA

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
    if (categoryName === "-- Please select the category --") return;
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

      {/* PROJECT TYPE */}
      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Type of project</h3>
        <select
          className={classes.sectionInputSelect}
          onChange={(e) => setProjectType(e.target.value)}
        >
          <option value="">-- Please select the type of your project --</option>
          <option value="event">Event</option>
          <option value="course">Course</option>
          <option value="application">Application</option>
          <option value="online-course">Online course</option>
        </select>
      </section>

      {/* CATEGORY */}
      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Project category</h3>
        <select
          className={classes.sectionInputSelect}
          onChange={(e) => handleCategorySelect(e)}
        >
          <option value="">-- Please select the category --</option>
          {categories.map((category) => (
            <option key={category.id} value={category.id}>
              {category.name}
            </option>
          ))}
        </select>

        {/* SUBCATEGORY */}
        <select
          className={classes.sectionInputSelect}
          onChange={(e) => insertData("subcategoryId", e.target.value)}
          disabled={subcategories.length === 0}
        >
          <option value="">-- Please select the subcategory --</option>
          {subcategories.map((subcategory) => (
            <option key={subcategory.id} value={subcategory.id}>
              {subcategory.name}
            </option>
          ))}
        </select>
      </section>

      {/* DESCRIPTION */}
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

      {/* TIERS */}
      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Tiers</h3>
        <p className={classes.sectionDescription}>
          Create your own tier list for this project. You must have at least one
          and at most three available tiers.
        </p>
        <div className={classes.sectionTiers}>
          <p className={classes.sectionDescription}>Name</p>
          <p className={classes.sectionDescription}>Description</p>
          <p className={classes.sectionDescription}>Price (€)</p>
          <p></p>
          {currentTiers.map((tier, index) => {
            return (
              <>
                <input
                  type="text"
                  placeholder="Gold"
                  className={classes.sectionInputText}
                  onChange={(e) => handleChangeTier(e, index, "name")}
                  value={tier.name}
                />
                <input
                  type="text"
                  placeholder="The best tier ever!"
                  className={classes.sectionInputText}
                  onChange={(e) => handleChangeTier(e, index, "description")}
                  value={tier.description}
                />
                <input
                  type="text"
                  placeholder="1000"
                  className={classes.sectionInputText}
                  onChange={(e) => handleChangeTier(e, index, "price")}
                  value={tier.price}
                />
                <button
                  className={classes.removeTierButton}
                  onClick={() => removeCurrentTier(index)}
                >
                  x
                </button>
              </>
            );
          })}
          <button
            className={classes.addTierButton}
            onClick={addCurrentTier}
            disabled={currentTiers.length >= 3}
          >
            New tier
          </button>
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

      {/* ESTIMATED RELEASE */}
      {projectType === "application" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>
            Estimated release date of your app
          </h3>
          <div className={classes.sectionDateContainer}>
            <input
              type="text"
              maxLength={2}
              placeholder="DD"
              className={classes.sectionDateInput}
              id="day"
              onChange={(e) =>
                setEstimatedRelease({
                  ...estimatedRelease,
                  day: e.target.value,
                })
              }
            />
            <input
              type="text"
              maxLength={2}
              placeholder="MM"
              id="month"
              className={classes.sectionDateInput}
              onChange={(e) =>
                setEstimatedRelease({
                  ...estimatedRelease,
                  month: e.target.value,
                })
              }
            />
            <input
              type="text"
              maxLength={4}
              placeholder="YYYY"
              id="year"
              className={classes.sectionDateInput}
              onChange={(e) =>
                setEstimatedRelease({
                  ...estimatedRelease,
                  year: e.target.value,
                })
              }
            />
          </div>
        </section>
      )}

      {/* APP PURPOSE */}
      {projectType === "application" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>
            Shortly describe your app's purpose
          </h3>
          <input
            type="text"
            placeholder="Purpose"
            className={classes.sectionInputText}
            onChange={(e) => insertData("appPurpose", e.target.value)}
          />
        </section>
      )}

      {/* FEATURES */}
      {projectType === "application" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>
            Add up to 5 features that your app will have
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

      {/* ESTIMATED NUMBER OF USERS */}
      {projectType === "application" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>
            What is the estimated number of users your app could have?
          </h3>
          <input
            type="text"
            placeholder="Estimated number of users"
            className={classes.sectionInputText}
            onChange={(e) =>
              insertData("estimatedNumberOfUsers", e.target.value)
            }
          />
        </section>
      )}

      {/* AVERAGE DURATION */}
      {projectType === "online-course" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>
            How long will your course be on average?
          </h3>
          <input
            type="text"
            placeholder="Estimated duration"
            className={classes.sectionInputText}
            onChange={(e) => insertData("averageDuration", e.target.value)}
          />
        </section>
      )}

      {/* EXPECTED AUDIENCE */}
      {projectType === "online-course" && (
        <section className={classes.section}>
          <h3 className={classes.sectionTitle}>
            How long will your audience be?
          </h3>
          <input
            type="text"
            placeholder="Audience size"
            className={classes.sectionInputText}
            onChange={(e) => insertData("expectedAudience", e.target.value)}
          />
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
      <button onClick={() => console.log(status)}>Print status</button>
    </>
  );
};

export default GeneralInformations;
