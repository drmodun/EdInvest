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
export const InvestorView = ({investor, onEdit, onDelete, seeDonations}) => {
  console.log(investor);
  const userInfo = JSON.parse(localStorage.getItem("userInfo"))
  let base64regex =
    /^([0-9a-zA-Z+/]{4})*(([0-9a-zA-Z+/]{2}==)|([0-9a-zA-Z+/]{3}=))?$/;

  const [socials, setSocials] = useState([]);
  useEffect(() => {
    const tempSocials = [];
    for (let key in investor.socialLinks) {
      console.log(key);
      if (investor.socialLinks[key]) {
        tempSocials.push({ name: key, link: investor.socialLinks[key] });
      }
    }
    setSocials(tempSocials);
    console.log(tempSocials);
  }, [investor.socialLinks]);
  
  function tryDelete(){
    if (investor.id === userInfo.id) {
      onDelete();
    }
  }
  function tryEdit(){
    if (investor.id === userInfo.id) {
      onEdit();
    }
  }

  return (
    <div className={classes.View}>
      <div className={classes.ViewImage}>
        <img
          src={
            base64regex.test(investor.image)
              ? "data:image/png;base64," + investor.image
              : DefaultProfile
          }
          alt={investor.name}
        />
      </div>
        <div className={classes.Type}>Type: Investor</div>
      <div className={classes.ViewDetails}>
        <span className={classes.ViewName}>Name: {investor.name}</span>
        <span className={classes.ViewEmail}>Email: {investor.email}</span>
        <span className={classes.ViewLastUpdated}>
          Last updated: {new Date(investor.updatedAt).toDateString()}
        </span>
        {investor.id === userInfo.id ? (
          <div className={classes.ViewButtons}>
            <button onClick={tryEdit}>Edit</button>
            <button onClick={tryDelete}>Delete</button>
          </div>
        ) : null}
        <button className={classes.SeeDonations} onClick={seeDonations}>
          See donations given
        </button>
        <div className={classes.FinancialInfo}>
          <div className={classes.FinancialInfoDetails}>
            <span>Donations</span>
            <span>{investor.amountOfDonationsGiven}</span>
          </div>
          <div className={classes.FinancialInfoDonations}>
            <span>Total donated</span>
               <span>${investor.balance}</span>
          </div>
        </div>
        <div className={classes.ViewBio}>
          <span className={classes.ViewDescTitle}>Description </span>
          <span className={classes.ViewDesc}>{investor.description}</span>
        </div>
        <div className={classes.ViewBio}>
          <span className={classes.ViewDescTitle}>Number of Employees </span>
          <span className={classes.ViewDescTitle}>{investor.numberOfEmployees}</span>
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
          <span> {investor.walletAddress}</span>
        </div>
      </div>
    </div>
  );
};
