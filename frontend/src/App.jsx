import "./App.css";
import "./fonts.css";
import Router from "./components/Router";
import { UserInfoProvider } from "./Providers/UserInfoProvider";

function App() {
  return (
    <UserInfoProvider>
      <Router />
    </UserInfoProvider>
  );
}

export default App;
