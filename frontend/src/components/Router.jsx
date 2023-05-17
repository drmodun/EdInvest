import {
  createBrowserRouter,
  createRoutesFromElements,
  json,
  Route,
  RouterProvider,
} from "react-router-dom";

import Layout from "./Layout";

import HomePage from "../pages/HomePage";
import ProjectPage from "../pages/ProjectPage";
import ProjectsPage from "../pages/ProjectsPage";

import NotFound from "../pages/NotFound";
import LoginPage from "../pages/LoginPage";
import InvestorPage from "../pages/InvestorPage/InvestorPage";
import OrganisationPage from "../pages/OrganisationPage";

const user = JSON.parse(localStorage.getItem("userInfo"));

const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      <Route element={<Layout />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/projects">
          <Route index element={<ProjectsPage />} />
          <Route path=":projectId" element={<ProjectPage />} />
        </Route>
        <Route path="/investors">
          {//Route index element={<InvestorsPage />} /> will be added here
          }
          <Route path=":investorId" element={<InvestorPage />} />

        </Route>
        <Route path="/organisations">
          {//Route index element={<OrganisationPage />} /> will be added here
          }
          <Route path=":organisationId" element={<OrganisationPage />} />
        </Route>
        <Route path="/me" element={
          user.type === 1 ?
        <InvestorPage /> : <OrganisationPage />}/>
      <Route path="/login" element={<LoginPage />} />
      </Route>

      <Route path="/login" element={<LoginPage />} />
      <Route path="*" element={<NotFound />} />
    </>
  )
);

const Router = () => {
  return <RouterProvider router={router} />;
};

export default Router;
