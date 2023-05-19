import { useParams } from "react-router-dom";
import useUserInfo from "../../Providers/UserInfoProvider";
import { InvestorView } from "../../components/GeneralUser";
import { getInvestorById } from "../../axios/UserCalls/InvestorApiCalls";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { deleteUser } from "../../axios/UserCalls/UserApiCalls";
import { getInvestments, getItemsForInvestor } from "../../axios/InvestmentsApiCalls";
import classes from "./InvestorPage.module.css";
export const InvestorPage = () => {
  const { investorId } = useParams();
  const [investor, setInvestor] = useState({});
  const navigation = useNavigate();
  const [items, setItems] = useState([]);
  const [donations, setDonations] = useState([]);
  const userInfo = JSON.parse(localStorage.getItem("userInfo"));
  useEffect(() => {
    async function fetchInvestor() {
      try {
        const response = await getInvestorById(
          investorId ? investorId : userInfo.id
        );

        if (response) {
          setInvestor(response);
        }
      } catch (error) {
        console.log(error);
        navigation("/404", { replace: true });
      }
    }
    fetchInvestor();
  }, [investorId, userInfo.id, navigation]);

  useEffect(() => {
    async function fetch() {
      try{
        console.log(investor.id);
      const response = await getItemsForInvestor(investor.id);
      const params = {
        InvestorId : investor.id,
        ItemId : null,
        Tier : null,
        UpdatedAt : null,
      }
      const donations = await getInvestments(params);
        setItems(response.items);
      setDonations(donations.investments);
      console.log(donations.investments, response.items);
    }
      catch(err){
        console.log(err);
      }
    }
    fetch();
  }, [investor.id]);
  function onEdit() {
    navigation("/edit");
    //connect to edit page later
  }
  async function onDelete() {
    const check = prompt(
      "Are you sure you want to delete your account, type your account name to confirm"
    );
    if (check === userInfo.name) {
      try {
        const response = await deleteUser(investorId);
        if (response) {
          userInfo.logOut();
          navigation("/login");
        }
      } catch (error) {
        console.log(error);
      }
    }
  }

  function seeDonations() {
    navigation("/donations");
  }

  return (
    <div>
      <div className={classes.Background}></div>
      { investor && <InvestorView
        investor={investor}
        items={items}
        donations={donations}
        onDelete={onDelete}
        onEdit={onEdit}
        seeDonations={seeDonations}
      />}
    </div>
  );
};
export default InvestorPage;
