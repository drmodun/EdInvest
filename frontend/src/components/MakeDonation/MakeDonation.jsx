import { useEffect, useState } from "react";

import USDT from "../../assets/USDT.svg";
import classes from "./MakeDonation.module.css";
import USDC from "../../assets/USDC.svg";
import BUSD from "../../assets/BUSD.svg";
import DefaultProfile from "../../assets/default-profile.png";
import {
  createInvestment,
  getInvestment,
  updateInvestment,
} from "../../axios/InvestmentsApiCalls";
import Dropdown from "../Dropdown";

export const MakeDonation = ({ tiersDict, pic, name, id, prices }) => {
  const base64regex =
    /^([0-9a-zA-Z+/]{4})*(([0-9a-zA-Z+/]{2}==)|([0-9a-zA-Z+/]{3}=))?$/;
  const userInfo = JSON.parse(localStorage.getItem("userInfo"));
  const [selectTier, setTier] = useState(null);
  const [amount, setAmount] = useState(0);
  const [payment, setPayment] = useState("USDT");
  const [tiers, setTiers] = useState([]);
  const [donationExists, setDonationExists] = useState(false);
  const [previousAmount, setPreviousAmount] = useState(0);
  const [error, setError] = useState("");
  useState(() => {
    let tierIndex = 0;
    const tempTiers = [];
    for (let tier in tiersDict) {
      tempTiers.push({
        name: tier,
        description: tiersDict[tier],
        amount: prices[tierIndex],
      });
      tierIndex++;
    }
    setTiers(tempTiers);
  }, []);

  useEffect(() => {
    async function fetchData() {
      try {
        const result = await getInvestment(userInfo.id, id);
        setAmount(result.amount);
        console.log(result);
        setTier(result.tier - 1);
        setDonationExists(true);
        setPreviousAmount(result.amount);
      } catch (err) {
        console.log(err);
        setAmount(0);
        setTier("not");
      }
    }
    fetchData();
  }, []);

  const handleAmount = (amount) => {
    if (isNaN(Number(amount)) && amount !== "") {
        return;
    }
    setAmount(Number(amount));
    let tierIndex = "not";
    for (let tier of tiers) {
      console.log(tier.amount, amount);
      if (tier.amount <= Number(amount)) {
        tierIndex === "not" ? (tierIndex = 0) : tierIndex++;
      }
    }
    console.log(amount);
    setTier(tierIndex);
    console.log(tierIndex);
  };

  const handleDonationFail = () => {
    setError("You can't donate less than you already have!");
  };

  const handleDonation = async () => {
    try {
      let check = true;
      !donationExists
        ? await createInvestment(id, amount)
        : amount >= previousAmount
        ? await updateInvestment(id, amount)
        : check = false;
      if (!check || amount < 0) {
        handleDonationFail();
        return;
      }
      alert("Succesfully made donation!");
      window.location.reload();
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className={classes.MakeDonation}>
      <div className={classes.DonationInfo}>
        <img
          src={
            base64regex.test(pic) && pic
              ? "data:image/png;base64," + pic
              : DefaultProfile
          }
          alt="Item"
        ></img>
        <span className={classes.DonationName}>{name}</span>
      </div>
      <span>Choose your token</span>
      <form className={classes.PaymentMethod}>
        <select
          name="paymentMethod"
          id="payment"
          onChange={(e) => setPayment(e.target.value)}
          value={payment}
        >
          <option value="USDT">USDT</option>
          <option value="USDC">USDC</option>
          <option value="BUSD">BUSD</option>
        </select>
        <img
          src={payment === "USDT" ? USDT : payment === "USDC" ? USDC : BUSD}
          alt=""
        />
        <input
          type="text"
          name="amount"
          id="amount"
          key={"amount"}
          value={amount}
          onChange={(e) => handleAmount(e.target.value)}
        />
      </form>
      <span>Tiers</span>
      <div className={classes.Tiers}>
        {tiers.map((tier, index) => (
          <div
            key={index}
            className={
              selectTier === index ? classes.SelectedTier : classes.Tier
            }
          >
            <div className={classes.TierName}>{tier.name}</div>
            <div className={classes.TierDesc}>{tier.description}</div>
            <div className={classes.TierAmount}>{tier.amount}$</div>
          </div>
        ))}
      </div>
      <div className={classes.Transparency}>
        <span>
          Your donation to {name} is {amount * 0.9}
        </span>
        <span>Your donation to EdInvest is {amount * 0.1}</span>
        <span>
          EdInvest has to take 10% of all donations to fund the cost for site
          maintainance
        </span>
      </div>
      <button disabled={(amount <= previousAmount && donationExists) || amount < prices[0]} type="submit" onClick={handleDonation}>
        Donate
      </button>
      <span className={classes.Error}>{error}</span>
    </div>
  );
};
