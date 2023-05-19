import { useState } from "react";

import USDT from "../../assets/USDT.svg";
import classes from "./MakeDonation.module.css";
import USDC from "../../assets/USDC.svg";
import BUSD from "../../assets/BUSD.svg";
import DefaultProfile from "../../assets/default-profile.png";
import { createInvestment } from "../../axios/InvestmentsApiCalls";

export const MakeDonation = ({ tiers, pic, name, id }) => {
  const base64regex =
    /^([0-9a-zA-Z+/]{4})*(([0-9a-zA-Z+/]{2}==)|([0-9a-zA-Z+/]{3}=))?$/;
  const userInfo = JSON.parse(localStorage.getItem("userInfo"));
  const [selectTier, setTier] = useState(null);
  const [amount, setAmount] = useState(0);
  const [payment, setPayment] = useState(null);

  useState(() => {
    let tierIndex = 0;
    for (let tier of tiers) {
      if (tier.amount <= amount) {
        tierIndex++;
      }
    }
    setTier(tiers[tierIndex]);
  }, [amount]);

  const handleDonation = async () => {
    try{
        await createInvestment(id, amount);
        alert("Succesfully made donation!")
        window.location.reload();
    }
    catch(err){
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
        <div className={classes.DonationName}>{name}</div>
      </div>
      <form className={classes.PaymentMethod}>
        <select
          name="method"
          id="method"
          defaultValue={USDT}
          value={payment}
          onChange={(e) => setPayment(e.target.value)}
        >
          <option value={USDC}>
            <img src={USDT} alt="USDT" />
          </option>
          <option value={USDT}>
            <img src={USDC} alt="USDC" />
          </option>
          <option value={BUSD}>
            <img src={BUSD} alt="BUSD" />
          </option>
        </select>
        <input
          type="number"
          name="amount"
          id="amount"
          value={amount}
          onChange={(e) => setAmount(e.target.value)}
        />
      </form>
      <div className={classes.Tiers}>
        <span>Tiers</span>
        {tiers.map((tier, index) => (
          <div
            key={index}
            className={
              selectTier === tier ? classes.SelectedTier : classes.Tier
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
      <button type="submit" onClick={handleDonation}>
        Donate
      </button>
    </div>
  );
};
