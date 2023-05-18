import classes from "./View.module.css";
import Facebook from "../../assets/facebook.svg";
import Google from "../../assets/google.svg";
import Twitter from "../../assets/twitter.svg";
import AppStore from "../../assets/IOS.svg";
import { Link } from "react-router-dom";
import useUserInfo from "../../Providers/UserInfoProvider";
import DefaultProfile from "../../assets/default-profile.png";
import { useEffect, useState } from "react";
//even though 
const dict = {
  facebook: Facebook,
  google: Google,
  twitter: Twitter,
  appstore: AppStore,
};
export const OrganisationView = ({organisation, onEdit, onDelete, seeDonations}) => {
  console.log(organisation);
  const userInfo = JSON.parse(localStorage.getItem("userInfo"))
  let base64regex =
    /^([0-9a-zA-Z+/]{4})*(([0-9a-zA-Z+/]{2}==)|([0-9a-zA-Z+/]{3}=))?$/;

  const [socials, setSocials] = useState([]);
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

  function tryDelete(){
    if (organisation.id === userInfo.id) {
      onDelete();
    }
  }
  function tryEdit(){
    if (organisation.id === userInfo.id) {
      onEdit();
    }
  }
  

  return (
    <div className={classes.View}>
      <div className={classes.ViewImage}>
        <img
          src={
            base64regex.test(organisation.image)
              ? "data:image/png;base64," + organisation.image
              : DefaultProfile
          }
          alt={organisation.name}
        />
      </div>
        <div className={classes.Type}>Type: Organisation</div>
      <div className={classes.ViewDetails}>
        <span className={classes.ViewName}>Name: {organisation.name}</span>
        <span className={classes.ViewEmail}>Email: {organisation.email}</span>
        <span className={classes.ViewLastUpdated}>
          Last updated: {new Date(organisation.updatedAt).toDateString()}
        </span>
        {organisation.id === userInfo.id ? (
          <div className={classes.ViewButtons}>
            <button onClick={tryEdit}>Edit</button>
            <button onClick={tryDelete}>Delete</button>
          </div>
        ) : null}
        <button className={classes.SeeDonations} onClick={seeDonations}>
          See donations received
        </button>
        <div className={classes.FinancialInfo}>
          <div className={classes.FinancialInfoDetails}>
            <span>Donations received</span>
            <span>{organisation.amountOfDonationsReceived}</span>
          </div>
          <div className={classes.FinancialInfoDonations}>
            <span>Total received</span>
               <span>${organisation.balance}</span>
          </div>
        </div>
        <div className={classes.ViewBio}>
          <span className={classes.ViewDescTitle}>Description </span>
          <span className={classes.ViewDesc}>{organisation.description}</span>
        </div>
        <div className={classes.ViewBio}>
          <span className={classes.ViewDescTitle}>Number of Members </span>
          <span className={classes.ViewDescTitle}>{organisation.numberOfMembers}</span>
        </div>
        <div className={classes.Socials}>
          <span>Social Links</span>
          {socials.map((social)=>{
              const key = social.name;
              return (<a href={social.link}><img src={dict[key]} alt={key} /></a>)
          })}
        </div>
        <div className={classes.WalletAddress}>
          <span>Wallet Address</span>
          <span> {organisation.walletAddress}</span>
        </div>
      </div>
    </div>
  );
};
