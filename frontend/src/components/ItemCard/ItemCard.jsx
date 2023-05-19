import classes from "./ItemCard.module.css";
import { Link } from "react-router-dom";
import ItemDefault from "../../assets/item-default.svg";

const dict = {
  0: "Course",
  1: "Application",
  3: "Online Course",
  4: "Event",
};

export const ItemCard = ({
  title,
  type,
  author,
  description,
  picture,
  goal,
  currentAmount,
  itemId,
  organisationId,
}) => {
  const base64StringRegex =
    /^([0-9a-zA-Z+/]{4})*(([0-9a-zA-Z+/]{2}==)|([0-9a-zA-Z+/]{3}=))?$/;

  return (
    <div className={classes.ItemCard}>
      <div className={classes.Image}>
        {picture && base64StringRegex.test(picture) ? (
          <img src="data:image/png;base64," alt="item" />
        ) : (
          <img src={ItemDefault} alt="item"></img>
        )}
      </div>
      <div className={classes.Details}>
        <Link to={"/projects/" + itemId}>
          <div className={classes.Title}>{title}</div>{" "}
        </Link>
        <Link to={"/organisations/" + organisationId}>
          <div className={classes.Author}>{author}</div>{" "}
        </Link>
        <div className={classes.Type}>{dict[type]}</div>
        <div className={classes.Desc}>{description}</div>
        <div className={classes.Goal}>
          <div className={classes.GoalText}>Goal: {goal}$</div>
          <div className={classes.GoalBar}>
            <div
              className={classes.CurrentBar}
              style={{ width: (currentAmount / goal) * 100 + "%" }}
            ></div>
          </div>
          <div className={classes.CurrentAmount}>{currentAmount}$</div>
        </div>
      </div>
    </div>
  );
};
