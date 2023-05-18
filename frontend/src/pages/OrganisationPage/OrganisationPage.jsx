import { useParams } from "react-router-dom";
import useUserInfo from "../../Providers/UserInfoProvider";
import { OrganisationView } from "../../components/GeneralUser";
import { getOrganisationById } from "../../axios/UserCalls/OrganisationApiCalls";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { deleteUser } from "../../axios/UserCalls/UserApiCalls";
export const OrganisationPage = () => {
  const { organisationId } = useParams();
  const [organisation, setOrganisation] = useState({});
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
    <div style={{ position: "relative", top: "500px", marginBottom: "500px" }}>
      <OrganisationView
        organisation={organisation}
        onDelete={onDelete}
        onEdit={onEdit}
        seeDonations={seeDonations}
      />
    </div>
  );
};
export default OrganisationPage;
