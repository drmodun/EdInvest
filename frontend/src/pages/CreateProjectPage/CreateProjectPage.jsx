import classes from "./index.module.css";

const CreateProjectPage = () => {
  return (
    <div className={"layoutSpacing " + classes.content}>
      <h1 className={classes.title}>Create a project</h1>
      <div className={classes.sectionNav}>
        <button className={classes.sectionNavButton}>
          General informations
        </button>
        <button className={classes.sectionNavButton}>Project picture</button>
        <button className={classes.sectionNavButton}>Receiving funds</button>
      </div>
    </div>
  );
};

export default CreateProjectPage;
