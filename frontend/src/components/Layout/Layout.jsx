import { Outlet } from "react-router-dom";

import Navigation from "../Navigation";
import Footer from "../Footer";

const Layout = () => {
  return (
    <>
      <Navigation />
      <main>
        <Outlet />
      </main>
      <Footer />
    </>
  );
};

export default Layout;
