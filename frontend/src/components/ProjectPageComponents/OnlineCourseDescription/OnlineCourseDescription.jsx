const OnlineCourseDescription = ({ project }) => {
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
        <p>{project.expectedAudience}</p>
      </div>
      <div>
        <h4>Lesson dates</h4>
        <ol>
          {project.lessonsDate.map((date) => (
            <li key={date}>{date}</li>
          ))}
        </ol>
      </div>
      <div>
        <h4>Website</h4>
        <p>{project.mainWebsite}</p>
      </div>
    </>
  );
};
export default OnlineCourseDescription;
