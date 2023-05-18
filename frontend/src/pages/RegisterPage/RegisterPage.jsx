import { useState } from "react";
import classes from "./RegisterPage.module.css";
import { createOrganisation } from "../../axios/UserCalls/OrganisationApiCalls";
import { createInvestor } from "../../axios/UserCalls/InvestorApiCalls";
import { login } from "../../axios/UserCalls/UserApiCalls";

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
  const [SocialLogins, setSocialLogins] = useState("");
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
      !SocialLogins ||
      !location ||
      !walletAddress
    ) {
      setError("Please fill in all required fields.");
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
        setError("Please fill in all required fields.");
        return;
      }
    } else {
      if (!numberOfMembers) {
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
      setError("Please upload a valid image.");
      return;
    }
    const user = {
      name,
      email,
      password,
      country,
      description,
      socialLogins: SocialLogins,
      location,
      walletAddress,
      profilePicture,
    };
    if (type === "Investor") user.numberOfEmployees = numberOfEmployees;
    else user.numberOfMembers = numberOfMembers;
    // Submit user object to server
    const response =
      user.type === "Investor"
        ? await createInvestor(user)
        : await createOrganisation(user);
    if (response.status === 200) {
      window.location.href = "/login";
      localStorage.setItem("userInfo", JSON.stringify(response.data));
      const token = await login(email, password);
      localStorage.setItem("token", token);
    } else {
      console.log(response);
      console.log(response.data);
      setError("Error on submit");
    }
  };

  return (
    <div className={classes.RegisterPage}>
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
        <input
          type="text"
          placeholder="Country"
          value={country}
          onChange={(e) => setCountry(e.target.value)}
        />
        <label for="description">Description</label>
        <input
          type="text"
          placeholder="Description"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
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
        <input
          type="text"
          placeholder="Social Logins"
          value={SocialLogins}
          onChange={(e) => setSocialLogins(e.target.value)}
        />
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
