import "./App.css";
import Home from "./pages/home";
import {Routes, Route, Navigate, BrowserRouter} from "react-router-dom";
import Login from "pages/Login";
import NotFound from "pages/NotFound";
import React from "react";
import Profile from "./pages/home/profile";

function App() {
  return (
    <>
      <Routes>
        <Route element={<Home />} >
              <Route path="profile" element={<Profile />} />
        </Route>
        <Route path="/login" element={<Login />} />
        {/*<Route path="/signup" element={<Signup />} />*/}
        {/*<Route path="/about" element={<About />} />*/}
        {/*<Route path="/NotFound" element={<NotFound />} />*/}
        {/*  <Route*/}
        {/*      path="*"*/}
        {/*      element={<Navigate to="/NotFound" replace />}*/}
        {/*  />*/}
      </Routes>
    </>
  );
}

export default App;
