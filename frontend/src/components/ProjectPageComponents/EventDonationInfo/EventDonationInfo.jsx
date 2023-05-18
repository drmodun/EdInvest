import { useEffect, useState } from "react";
import { getInvestorsByItemId } from "../../../axios/InvestmentsApiCalls";

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
      <div>
        {investments.map((investment, i) => (
          <div key={i}>{investment.name}</div>
        ))}
      </div>

      <div>
        {investments.map((investment, i) => (
          <div key={i}>{investment.amount}</div>
        ))}
      </div>
    </>
  );
};

export default EventDonationInfo;
