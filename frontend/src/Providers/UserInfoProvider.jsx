import { createContext, useContext, useState, useEffect } from "react";
import { GetMe } from "../axios/UserCalls/UserApiCalls";

const defaultUserInfo = {
  id: "",
  name: "",
  email: "",
  profilePicture: "",
  description: "",
  countryId: "",
  location: "",
  type: "",
  userTypes: {
    investor: 1,
    organisation: 2,
  },
  isLogged: false,
  NumberOfMembers: 0,
  NumberOfEmployees: 0,
  logOut: () => {},
  fetchUserInfo: () => {},
};

const UserInfoContext = createContext(defaultUserInfo);

export const UserInfoProvider = ({ children }) => {
  const [userInfo, setUserInfo] = useState(defaultUserInfo);

  useEffect(() => {
    fetchUserInfo();
  }, []);

  async function fetchUserInfo() {
    try {
      const response = await GetMe();
      if (response) {
        setUserInfo({
          ...response,
          isLogged: true,
          logOut: logOut,
          fetchUserInfo: fetchUserInfo,
        });
      }
    } catch (error) {
      console.log(error);
    }
  }
  const logOut = () => {
    localStorage.removeItem("token");
    setUserInfo({
      ...defaultUserInfo,
    });
  };

  return (
    <UserInfoContext.Provider value={userInfo}>
      {children}
    </UserInfoContext.Provider>
  );
};
const useUserInfo = () => useContext(UserInfoContext);
export default useUserInfo;
