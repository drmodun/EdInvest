import { useParams } from "react-router-dom";
import useUserInfo from "../../Providers/UserInfoProvider";
import { OrganisationView } from "../../components/GeneralUser";
import { getOrganisationById } from "../../axios/UserCalls/OrganisationApiCalls";
import classes from "./OrganisationPage.module.css";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { deleteUser } from "../../axios/UserCalls/UserApiCalls";
import { getItems } from "../../axios/ItemCalls/ItemsApiCalls";
import { getInvestmentsForOrg } from "../../axios/InvestmentsApiCalls";
export const OrganisationPage = () => {
  const { organisationId } = useParams();
  const [organisation, setOrganisation] = useState({});
  const [items, setItems] = useState([]);
  const [donations, setDonations] = useState([]);
  const navigation = useNavigate();
  const userInfo = JSON.parse(localStorage.getItem("userInfo"));
  useEffect(() => {
    async function fetchOrganisation() {
      try {
        const response = await getOrganisationById(
          organisationId ? organisationId : userInfo.id
        );

        if (response) {
          setOrganisation(response);
        }
      } catch (error) {
        console.log(error);
        navigation("/404", { replace: true });
      }
    }
    fetchOrganisation();
  }, [organisationId, userInfo.id, navigation]);

  useEffect(() => {
    async function fetch() {
      try {
        console.log(organisation.id);
        const params = {
          OrganisationId: organisation.id,
        };
        const response = await getItems(params);
        const donations = await getInvestmentsForOrg(organisation.id);
        setItems(response.items);
        setDonations(donations.investments);
        console.log(donations.investments, response.items);
      } catch (err) {
        console.log(err);
      }
    }
    fetch();
  }, [organisation.id]);

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
        const response = await deleteUser(organisationId);
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
      <OrganisationView
        organisation={organisation}
        onDelete={onDelete}
        onEdit={onEdit}
        seeDonations={seeDonations}
        donations={donations}
        items={items}
        key={organisation.id}
      />
    </div>
  );
};
export default OrganisationPage;
