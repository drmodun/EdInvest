import classes from "./index.module.css";

import SearchIcon from "../../assets/icons/search.svg";

import Card from "../../components/Card";

const ProjectsPage = () => {
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
      </section>
    </>
  );
};

export default ProjectsPage;
