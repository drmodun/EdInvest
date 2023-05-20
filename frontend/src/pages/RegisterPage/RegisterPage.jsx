import { useEffect, useState } from "react";
import AppStore from "../../assets/IOS.svg";
import Facebook from "../../assets/facebook.svg";
import Google from "../../assets/google.svg";
import Twitter from "../../assets/twitter.svg";
import { GetCountries } from "../../axios/CountryApiCalls";
import { createInvestor } from "../../axios/UserCalls/InvestorApiCalls";
import { createOrganisation } from "../../axios/UserCalls/OrganisationApiCalls";
import { login } from "../../axios/UserCalls/UserApiCalls";
import classes from "./RegisterPage.module.css";
export const RegisterPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [passwordConfirmation, setPasswordConfirmation] = useState("");
  const [error, setError] = useState("");
  const [country, setCountry] = useState("");
  const [description, setDescription] = useState("");
  const [name, setName] = useState("");
  const [type, setType] = useState("");
  const [numberOfEmployees, setNumberOfEmployees] = useState(0);
  const [numberOfMembers, setNumberOfMembers] = useState(0);
  const [facebook, setFacebook] = useState("");
  const [twitter, setTwitter] = useState("");
  const [google, setGoogle] = useState("");
  const [appStore, setAppStore] = useState("");
  const [countries, setCountries] = useState([]);
  const [location, setLocation] = useState("");
  const [walletAddress, setWalletAddress] = useState("");
  const [profilePicture, setProfilePicture] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Validate form data here
    if (
      !name ||
      !email ||
      !password ||
      !passwordConfirmation ||
      !country ||
      !description ||
      !location ||
      !walletAddress
    ) {
      console.log(countries);
      setError("Please fill in all required fields" + country);
      console.log(
        name,
        email,
        password,
        passwordConfirmation,
        country,
        description,
        location,
        walletAddress
      );
      return;
    }

    if (password !== passwordConfirmation || password.length < 8) {
      setError("Passwords do not match or are not valid");
      return;
    }
    if (!email.includes("@") || !email.includes(".")) {
      setError("Please enter a valid email address.");
      return;
    }
    if (type === "Investor") {
      if (!numberOfEmployees) {
        console.log(numberOfEmployees, type);
        setError("Please fill in all required fields.");
        return;
      }
    } else {
      if (!numberOfMembers) {
        console.log(numberOfMembers, type);
        setError("Please fill in all required fields.");
        return;
      }
    }
    if (
      (Number(numberOfEmployees) < 0 && Number(numberOfMembers) < 0) ||
      Number(numberOfEmployees) > 1000000 ||
      Number(numberOfMembers) > 1000000
    ) {
      setError("Please enter a valid number of employees/members.");
      return;
    }
    if (description.length > 500 || description.length < 20) {
      setError("Please enter a description between 20 and 500 characters.");
      return;
    }
    if (location.length > 100 || location.length < 5) {
      setError("Please enter a location between 5 and 100 characters.");
      return;
    }
    if (walletAddress.length < 26 || walletAddress.length > 36) {
      setError("Please enter a valid wallet address.");
      return;
    }
    let base64regex =
      /^([0-9a-zA-Z+/]{4})*(([0-9a-zA-Z+/]{2}==)|([0-9a-zA-Z+/]{3}=))?$/;
    if (!base64regex.test(profilePicture)) {
      setProfilePicture("default");
      return;
    }
    const socialLogins = {
      facebook: facebook ? facebook : null,
      twitter: twitter ? twitter : null,
      google: twitter ? google : null,
      appStore: appStore ? appStore : null,
    };
    const user = {
      name,
      email,
      password,
      countryId: country,
      description,
      socialLinks: socialLogins,
      locationName: location,
      walletAddress,
      profilePicture,
    };
    if (type === "Investor") user.numberOfEmployees = numberOfEmployees;
    else user.numberOfMembers = numberOfMembers;
    // Submit user object to server
    const response =
      type === "Investor"
        ? await createInvestor(user)
        : await createOrganisation(user);
    if (response.success) {
      localStorage.setItem(
        "userInfo",
        JSON.stringify(
          type === "Investor" ? response.investor : response.organisation
        )
      );
      const token = await login(email, password);
      setError("");
      localStorage.setItem("token", token);
      window.location.href = "/";
    } else {
      console.log(response);
      console.log(response.data);
      setError("Error on submit");
    }
  };

  useEffect(() => {
    async function fetchCountries() {
      try {
        const response = await GetCountries();
        setCountries(response.sort((a, b) => a.name.localeCompare(b.name)));
        console.log(response.data);
      } catch (err) {
        console.log(err);
      }
    }
    fetchCountries();
  }, []);
  return (
    <div className={classes.RegisterPage}>
      <span className={classes.Title}>Register your account</span>
      <div className={classes.Bars}>
        <div className={classes.BlueBar}></div>
        <div className={classes.GreyBar}></div>
      </div>
      <form className={classes.RegisterForm} onSubmit={handleSubmit}>
        <label for="type">Type</label>
        <select
          type="text"
          placeholder="Type"
          value={type}
          onChange={(e) => setType(e.target.value)}
        >
          <option value="Investor">Investor</option>
          <option value="Startup">Organisation</option>
        </select>
        <label for="name">Name</label>
        <input
          type="text"
          placeholder="Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <label for="email">Email</label>
        <input
          type="text"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <label for="password">Password</label>
        <input
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <label for="passwordConfirmation">Password Confirmation</label>
        <input
          type="password"
          placeholder="Password Confirmation"
          value={passwordConfirmation}
          onChange={(e) => setPasswordConfirmation(e.target.value)}
        />
        <label for="country">Country</label>
        <select
          type="text"
          placeholder="Country"
          value={country}
          defaultValue={""}
          onChange={(e) => {
            console.log(e.target.value);
            setCountry(e.target.value);
          }}
        >
          <option disabled></option>
          {countries.map((country) => (
            <option key={country.id} value={country.id}>
              {country.name}
            </option>
          ))}
        </select>
        <label for="description">Description</label>
        <textarea
          type="text"
          placeholder="Description"
          value={description}
          rows={10}
          onChange={(e) => setDescription(e.target.value)}
          style={{ resize: "none", width: "500px" }}
        />
        {type === "Investor" ? (
          <>
            <label for="numberOfEmployees">Number of Employees</label>
            <input
              type="text"
              placeholder="Number of Employees"
              value={numberOfEmployees}
              onChange={(e) => setNumberOfEmployees(e.target.value)}
            />
          </>
        ) : (
          <>
            <label for="numberOfMembers">Number of Members</label>
            <input
              type="text"
              placeholder="Number of Members"
              value={numberOfMembers}
              onChange={(e) => setNumberOfMembers(e.target.value)}
            />
          </>
        )}
        <label for="SocialLogins">Social Logins</label>
        <div className={classes.socialLink}>
          <img src={Facebook} alt="facebook" />
          <input
            type="text"
            placeholder="Facebook"
            value={facebook}
            onChange={(e) => setFacebook(e.target.value)}
          />
        </div>
        <div className={classes.socialLink}>
          <img src={Twitter} alt="twitter" />
          <input
            type="text"
            placeholder="Twitter"
            value={twitter}
            onChange={(e) => setTwitter(e.target.value)}
          />
        </div>
        <div className={classes.socialLink}>
          <img src={Google} alt="google" />
          <input
            type="text"
            placeholder="Website"
            value={google}
            onChange={(e) => setGoogle(e.target.value)}
          />
        </div>
        <div className={classes.socialLink}>
          <img src={AppStore} alt="appStore" />
          <input
            type="text"
            placeholder="Apple Store"
            value={appStore}
            onChange={(e) => setAppStore(e.target.value)}
          />
        </div>
        <label for="location">Location</label>
        <input
          type="text"
          placeholder="Location"
          value={location}
          onChange={(e) => setLocation(e.target.value)}
        />
        <label for="walletAddress">Wallet Address</label>
        <input
          type="text"
          placeholder="Wallet Address"
          value={walletAddress}
          onChange={(e) => setWalletAddress(e.target.value)}
        />
        <button type="submit">Register</button>
        <label htmlFor="profilePicture">Profile Picture</label>
        <input
          type="file"
          accept="image/*"
          onChange={(e) => setProfilePicture(e.target.files[0])}
        />
        <p className={classes.Error}>{error ? error : ""}</p>
      </form>
    </div>
  );
};
