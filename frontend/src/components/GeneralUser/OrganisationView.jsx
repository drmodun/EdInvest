import classes from "./View.module.css";
import Facebook from "../../assets/facebook.svg";
import Google from "../../assets/google.svg";
import Twitter from "../../assets/twitter.svg";
import AppStore from "../../assets/IOS.svg";
import { Link } from "react-router-dom";
import useUserInfo from "../../Providers/UserInfoProvider";
import DefaultProfile from "../../assets/default-profile.png";
import { useEffect, useState } from "react";
import {
  getInvestments,
  getItemsFororganisation,
} from "../../axios/InvestmentsApiCalls";
import ItemCard from "../ItemCard";
//even though
const dict = {
  facebook: Facebook,
  google: Google,
  twitter: Twitter,
  appstore: AppStore,
};
export const OrganisationView = ({
  organisation,
  onEdit,
  onDelete,
  seeDonations,
  items,
  donations,
}) => {
  console.log(organisation);
  const userInfo = JSON.parse(localStorage.getItem("userInfo"));
  let base64regex =
    /^([0-9a-zA-Z+/]{4})*(([0-9a-zA-Z+/]{2}==)|([0-9a-zA-Z+/]{3}=))?$/;

  const [socials, setSocials] = useState([]);
  const [selected, setSelected] = useState("projects");
  useEffect(() => {
    const tempSocials = [];
    for (let key in organisation.socialLinks) {
      console.log(key);
      if (organisation.socialLinks[key]) {
        tempSocials.push({ name: key, link: organisation.socialLinks[key] });
      }
    }
    setSocials(tempSocials);
    console.log(tempSocials);
  }, [organisation.socialLinks]);

  function tryDelete() {
    if (organisation.id === userInfo.id) {
      onDelete();
    }
  }
  function tryEdit() {
    if (organisation.id === userInfo.id) {
      onEdit();
    }
  }

  return (
    <div className={classes.View}>
      <div className={classes.BasicInfo}>
        <div className={classes.ViewImage}>
          <img
            src={
              base64regex.test(organisation.profilePicture) &&
              organisation.profilePicture
                ? "data:image/png;base64," + organisation.profilePicture
                : DefaultProfile
            }
            alt={organisation.name}
          />
        </div>
        <div className={classes.Type}>Type: Organisation</div>
        <div className={classes.ViewDetails}>
          <span className={classes.ViewName}>{organisation.name}</span>
          <span className={classes.ViewEmail}>{organisation.email}</span>
          <span className={classes.ViewLastUpdated}>
            Last updated: {new Date(organisation.updatedAt).toDateString()}
          </span>
          <div className={classes.Socials}>
            {socials.map((social) => {
              const key = social.name;
              return (
                <a href={social.link}>
                  <img src={dict[key]} alt={key} />
                </a>
              );
            })}
          </div>
          <div style={{minHeight: "96px"}}>
          {organisation.id === userInfo.id ? (
            <div className={classes.ViewButtons}>
              <button onClick={tryEdit}>Edit</button>
              <button onClick={tryDelete}>Delete</button>
            </div>
          ) : null}
          </div>
        </div>
        <div className={classes.FinancialInfo}>
          <div className={classes.FinancialInfoDetails}>
            <span>Donations</span>
            <span>{organisation.amountOfDonationsReceived}</span>
          </div>
          <div className={classes.FinancialInfoDonations}>
            <span>Total received</span>
            <span>${organisation.balance}</span>
          </div>
        </div>
      </div>
      <div className={classes.Info}>
        <div className={classes.Selection}>
          <button
            className={
              selected === "projects"
                ? classes.Selected
                : classes.SelectionButton
            }
            onClick={() => setSelected("projects")}
          >
           Projects
          </button>
          <button
            className={
              selected === "details"
                ? classes.Selected
                : classes.SelectionButton
            }
            onClick={() => setSelected("details")}
          >
            View Details
          </button>
          <button
            className={
              selected === "investments"
                ? classes.Selected
                : classes.SelectionButton
            }
            onClick={() => setSelected("investments")}
          >
            All investments
          </button>
        </div>
        {selected === "projects" ? (
          <div className={classes.Projects}>
            {items &&
              items.map((item) => {
                return (
                  <ItemCard
                    title={item.name}
                    description={item.itemDescription}
                    author={item.organisationName}
                    type={item.type}
                    currentAmount={item.currentAmount}
                    goal={item.goal}
                    picture={item.image}
                    itemId={item.id}
                    key={item.id}
                    organisationId={item.organisationId}
                  />
                );
              })}
          </div>
        ) : selected === "details" ? (
          <div className={classes.Details}>
            <div className={classes.ViewBio}>
              <span className={classes.ViewDescTitle}>Description </span>
              <span className={classes.ViewDesc}>{organisation.description}</span>
            </div>
            <div className={classes.ViewBio}>
              <span className={classes.ViewDescTitle}>
                Number of members{" "}
              </span>
              <span className={classes.ViewNumber}>
                {organisation.numberOfMembers}
              </span>
            </div>
            <div className={classes.WalletAddress}>
              Wallet Address
              <span> {organisation.walletAddress}</span>
            </div>
          </div>
        ) : (
          <div className={classes.Investments}>
            {donations &&
              donations.map((donation) => {
                return (
                  <div className={classes.Investment}>
                    <Link to={"/investors/" + donation.investorId}>
                      <div className={classes.investorPic}>
                        <img
                          src={
                            base64regex.test(donation.investorImage) &&
                            donation.investorImage
                              ? "data:image/png;base64," +
                                donation.organisationImage
                              : DefaultProfile
                          }
                          alt="investor"
                        />
                      </div>
                    </Link>
                    <Link to={"/investors/" + donation.investorId}>
                      <div className={classes.InvestorName}>
                        {donation.investorName}
                      </div>{" "}
                    </Link>
                    <div className={classes.DonationUpdatedAt}>
                      {new Date(donation.updatedAt).toDateString()}
                    </div>
                    <div className={classes.Amount}>${donation.amount}</div>
                    <div className={classes.Arrow}>
                      <span>{"=>"}</span>
                    </div>
                    <Link to={"/projects/" + donation.itemId}>
                      {" "}
                      <div className={classes.ItemName}>
                        {donation.itemName}
                      </div>{" "}
                    </Link>

                    <Link to={"/projects/" + donation.itemId}>
                      <div className={classes.ItemPic}>
                        <img
                          src={
                            donation.itemImage && base64regex.test(donation.itemImage)
                              ? "data:image/png;base64," + donation.itemImage
                              : DefaultProfile
                          }
                          alt="Item"
                        />
                      </div>
                    </Link>
                    <div className={classes.ItemAuthor}>
                      {donation.itemAuthor}
                    </div>
                  </div>
                );
              })}
          </div>
        )}
      </div>
    </div>
  );
};
