import { useEffect, useState } from "react";
import classes from "./index.module.css";

import SearchIcon from "../../assets/icons/search.svg";

import Card from "../../components/Card";
import Dropdown from "../../components/Dropdown";

const ProjectsPage = () => {
  const sortingOptions = ["Most popular", "A - Z", "Z - A", "Most relevant"];

  const [inputIsFocused, setInputIsFocused] = useState(false);
  const handleInputFocus = () => {
    if (inputIsFocused) {
      setInputIsFocused(false);
    } else {
      setInputIsFocused(true);
    }
  };

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
            <Card></Card>
            <Card></Card>
            <Card></Card>
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
            </button>
          </div>
        </div>

        <div className={classes.sectionExploreSort}>
          <div className="layoutSpacing">
            <h3 className={classes.sectionExploreTitle}>
              Explore all<span>117 projects</span>
            </h3>
            <Dropdown
              name="Sort by"
              options={sortingOptions}
              isOpened={inputIsFocused}
              focusEffect={handleInputFocus}
            />
          </div>
        </div>
      </section>
    </>
  );
};

export default ProjectsPage;
