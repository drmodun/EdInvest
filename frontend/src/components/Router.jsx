import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
  RouterProvider,
} from "react-router-dom";

import Layout from "./Layout";

import HomePage from "../pages/HomePage";
import ProjectPage from "../pages/ProjectPage";
import ProjectsPage from "../pages/ProjectsPage";

import NotFound from "../pages/NotFound";
import LoginPage from "../pages/LoginPage";

const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      <Route element={<Layout />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/projects">
          <Route index element={<ProjectsPage />} />
          <Route path=":projectId" element={<ProjectPage />} />
        </Route>
      <Route path="/login" element={<LoginPage />} />
      </Route>

      <Route path="*" element={<NotFound />} />
    </>
  )
);

const Router = () => {
  return <RouterProvider router={router} />;
};

export default Router;
