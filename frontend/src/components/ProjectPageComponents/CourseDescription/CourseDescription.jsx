const CourseDescription = ({ project }) => {
  return (
    <>
      <div>
        <h4>Name</h4>
        <p>{project.name}</p>
      </div>
      <div>
        <h4>Description</h4>
        <p>{project.description}</p>
      </div>
      <div>
        <h4>Average duration</h4>
        <p>{project.averageDuration}</p>
      </div>
      <div>
        <h4>Expected applicants</h4>
        <p>{project.expectedApplicants}</p>
      </div>
      <div>
        <h4>Expected graduates</h4>
        <p>{project.expectedGraduates}</p>
      </div>
      <div>
        <h4>Start</h4>
        <p>{new Date(project.startDate).toDateString()}</p>
      </div>
      <div>
        <h4>End</h4>
        <p>{new Date(project.endDate).toDateString()}</p>
      </div>
      <div>
        <h4>Website</h4>
        <p>{project.mainWebsite}</p>
      </div>
    </>
  );
};

export default CourseDescription;
