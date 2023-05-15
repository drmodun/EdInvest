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
    </>
  );
};

export default ProjectsPage;
