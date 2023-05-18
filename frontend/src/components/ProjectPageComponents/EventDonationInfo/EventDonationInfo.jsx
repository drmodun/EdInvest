import { useEffect } from "react";
import { getInvestorsByItemId } from "../../../axios/InvestmentsApiCalls";

const EventDonationInfo = ({ project }) => {
  const [investors, setInvestors] = useState([]);
  const [totalContributions, setTotalContributions] = useState(0);
  useEffect(() => {
    (async () => {
      try {
        const data = await getInvestorsByItemId(project.id);
        setInvestors(data);
      } catch (err) {
        console.log(err.data);
      }
    })();
  }, []);

  return <>{JSON.stringify(investors)}</>;
};

export default EventDonationInfo;
