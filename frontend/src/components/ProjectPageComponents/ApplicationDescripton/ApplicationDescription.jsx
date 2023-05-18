const ApplicationDescription = ({ project }) => {
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
        <h4>Release date</h4>
        <p>{project.estimatedRelease}</p>
      </div>
      <div>
        <h4>Markets</h4>
        <ul>
          {project.markets.map((market) => (
            <li key={market}>{market}</li>
          ))}
        </ul>
      </div>
      <div>
        <h4>Features</h4>
        <ul>
          {project.features.map((feature) => (
            <li key={feature}>{feature}</li>
          ))}
        </ul>
      </div>
      <div>
        <h4>Website</h4>
        <p>{project.mainWebsite}</p>
      </div>
    </>
  );
};

export default ApplicationDescription;
