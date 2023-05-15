import classes from "./index.module.css";

const Dropdown = ({ name, options, isOpened, focusEffect }) => {
  return (
    <div className={classes.dropdown}>
      <label htmlFor={name}>{name}</label>
      <input
        id={name}
        readOnly
        onFocus={focusEffect}
        onBlur={focusEffect}
      ></input>
      {isOpened && (
        <div className={classes.dropdownOptions}>
          {options.map((option, index) => {
            return <p key={index}>{option}</p>;
          })}
        </div>
      )}
    </div>
  );
};

export default Dropdown;
