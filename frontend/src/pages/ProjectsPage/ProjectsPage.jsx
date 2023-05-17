import { useEffect, useState } from "react";
import classes from "./index.module.css";

import { getItems } from "../../axios/ItemCalls/ItemsApiCalls";

import SearchIcon from "../../assets/icons/search.svg";
import FilterIcon from "../../assets/icons/filter.svg";

import Card from "../../components/Card";
import Dropdown from "../../components/Dropdown";

const ProjectsPage = () => {
  const [inputIsFocused, setInputIsFocused] = useState(false);
  const [inputValue, setInputValue] = useState("");

  const handleInputFocus = () => {
    if (inputIsFocused) {
      setInputIsFocused(false);
    } else {
      setInputIsFocused(true);
    }
  };

  const sortItems = {
    "A - Z": () => {
      const copiedItems = [...items];
      copiedItems.sort((a, b) => a.name.localeCompare(b.name));
      setItems(copiedItems);
    },
    "Z - A": () => {
      const copiedItems = [...items];
      copiedItems.sort((a, b) => b.name.localeCompare(a.name));
      setItems(copiedItems);
    },
  };
  const sortingOptions = Object.keys(sortItems);

  const handleInputSelect = (e) => {
    const value = e.target.innerHTML;
    setInputValue(value);
    sortItems[value]();
  };

  const [items, setItems] = useState([]);
  const fetchItems = () => {
    getItems()
      .then((res) => res.items)
      .then((data) => setItems(data))
      .catch((err) => console.error(err));
  };

  useEffect(() => {
    fetchItems();
  }, []);

  return (
    <>
      {/* SEARCH SECTION */}
      <section className={classes.sectionSearch}>
        <h1 className={classes.sectionSearchTitle}>Find your project</h1>
        <div className={classes.sectionSearchQuery}>
          <img src={SearchIcon} />
          <input
            type="text"
            placeholder="Search for a project, organisation or something else"
          />
        </div>
      </section>

      {/* EXAMPLES SECTION */}
      <section className={classes.sectionExamples}>
        <div className="layoutSpacing">
          <h2 className={classes.sectionExamplesTitle}>Take a look</h2>
          <div className={classes.sectionExamplesCards}>
            {items.slice(0, 3).map((organisation, i) => {
              return (
                <Card
                  key={i}
                  name={organisation.name}
                  type={organisation.locationName}
                  isVerified={false}
                  description={organisation.description}
                  raised={organisation.balance}
                  id={organisation.id}
                />
              );
            })}
          </div>
        </div>
      </section>

      {/* EXPLORE ALL SECTION */}
      <section className={classes.sectionExplore}>
        <div className={classes.sectionExploreFilters}>
          <div className="layoutSpacing">
            <button className={classes.sectionExploreFiltersButton}>All</button>
            <button className={classes.sectionExploreFiltersButton}>
              Technology
            </button>
            <button className={classes.sectionExploreFiltersButton}>
              Languages
            </button>
            <button className={classes.sectionExploreFiltersButton}>
              Creative
            </button>
            <button className={classes.sectionExploreFiltersButton}>
              Science
            </button>
            <button className={classes.sectionExploreFiltersButton}>
              Filters
              <img src={FilterIcon} alt="" />
            </button>
          </div>
        </div>

        <div className={classes.sectionExploreSort}>
          <div className="layoutSpacing">
            <h3 className={classes.sectionExploreTitle}>
              Explore all<span>{items.length} projects</span>
            </h3>
            <Dropdown
              name="Sort by"
              value={inputValue}
              options={sortingOptions}
              isOpened={inputIsFocused}
              focusEffect={handleInputFocus}
              selectEffect={handleInputSelect}
            />
          </div>
        </div>

        <div className={classes.sectionExploreCards}>
          <div className="layoutSpacing">
            {items.map((organisation, i) => {
              return (
                <Card
                  key={i}
                  name={organisation.name}
                  type={organisation.locationName}
                  isVerified={false}
                  description={organisation.description}
                  raised={organisation.balance}
                  id={organisation.id}
                />
              );
            })}
          </div>
        </div>
      </section>
    </>
  );
};

export default ProjectsPage;
