import classes from "./index.module.css";

import SearchIcon from "../../assets/icons/search.svg";

const ProjectsPage = () => {
  return (
    <>
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
    </>
  );
};

export default ProjectsPage;
