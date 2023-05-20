const EventDescription = ({ project }) => {
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
        <h4>Date</h4>
        <p>{new Date(project.date).toDateString()}</p>
      </div>
      <div>
        <h4>Location</h4>
        <p>{project.location}</p>
      </div>
      <div>
        <h4>Activities</h4>
        <p></p>
      </div>
      <div>
        <h4>Notable Attendees</h4>
        <ul>
          {project.notableAttendees.map((attendee, i) => (
            <li key={i}>{attendee}</li>
          ))}
        </ul>
      </div>
      <div>
        <h4>Notable Speakers</h4>
        <ul>
          {project.notableSpeakers.map((speaker, i) => (
            <li key={i}>{speaker}</li>
          ))}
        </ul>
      </div>
      <div>
        <h4>Capacity</h4>
        <p>{project.capacity}</p>
      </div>
      <div>
        <h4>Ticket price</h4>
        <p>{project.ticketPrice}</p>
      </div>
      <div>
        <h4>Expected attendance</h4>
        <p>{project.expectedAttendance}</p>
      </div>
      <div>
        <h4>Website</h4>
        <p>{project.mainWebsite}</p>
      </div>
    </>
  );
};

export default EventDescription;
