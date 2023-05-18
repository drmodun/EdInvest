import { useEffect, useState } from "react";
import { getInvestorsByItemId } from "../../../axios/InvestmentsApiCalls";
import classes from "../index.module.css";

const EventDonationInfo = ({ project }) => {
  const [investments, setInvestments] = useState([]);
  const [totalContributions, setTotalContributions] = useState(0);
  useEffect(() => {
    (async () => {
      try {
        const data = await getInvestorsByItemId(project.id);
        setInvestments(data.investments);
      } catch (err) {
        console.log(err.data);
      }
    })();
  }, []);

  return (
    <>
      <div className={classes.TotalDonationsWrapper}>
        <h2>
          {investments.reduce((sum, project) => sum + project.amount, 0)}€
        </h2>
        <p>
          {project.name} has raised this amount so far. Check down below to see
          all donations
        </p>
      </div>

      <div className={classes.DonationInfoWrapper}>
        <div>
          <h4>Contributor</h4>
          {investments.map((investment, i) => (
            <div key={i}>{investment.name}</div>
          ))}
        </div>

        <div>
          <h4>Value in euors</h4>
          {investments.map((investment, i) => (
            <div key={i}>€{investment.amount}</div>
          ))}
        </div>
      </div>
    </>
  );
};

export default EventDonationInfo;
