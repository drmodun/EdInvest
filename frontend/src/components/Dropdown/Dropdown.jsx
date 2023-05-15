import classes from "./index.module.css";

import DropdownArrow from "../../assets/icons/dropdown-arrow.svg";

const Dropdown = ({
  name,
  value,
  options,
  isOpened,
  focusEffect,
  selectEffect,
}) => {
  return (
    <div className={classes.dropdown}>
      <label htmlFor={name}>{name}</label>
      <input
        type="text"
        value={value || ""}
        id={name}
        readOnly
        onFocus={focusEffect}
      ></input>
      {isOpened && (
        <div className={classes.dropdownOptions}>
          {options.map((option, index) => {
            return (
              <p key={index} onClick={selectEffect}>
                {option}
              </p>
            );
          })}
        </div>
      )}
      <img
        src={DropdownArrow}
        alt=""
        className={isOpened ? classes.arrowOpened : null}
      />
    </div>
  );
};

export default Dropdown;
