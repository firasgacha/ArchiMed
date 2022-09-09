import "./App.css";
import Home from "./pages/home";
import { Routes, Route, Navigate } from "react-router-dom";
import Login from "pages/Login";
import NotFound from "pages/NotFound";
import Profile from "pages/home/profile";
import Signup from "pages/Singup";
import About from "pages/About";
import MedicalFolder from "pages/home/MedicalFolder";
import ListOfDoctors from "pages/home/ListOfDoctors";
import ListOfPatients from "pages/home/ListOfPatients";
import LandingPage from "pages/LandingPage";
import Contact from "pages/Contact";
import ListOfServices from "pages/home/ListOfDepartements";
import ListOfHopital from "pages/home/ListOfHopital";
import ListOfMedicaments from "pages/home/ListOfMedicaments";
import ListOfAppointment from "pages/home/ListOfAppointment";
import ListOfEmployee from "pages/home/ListOfEmployee";
import ListOfDepartements from "pages/home/ListOfDepartements";

function App() {
  return (
    <>
      <Routes>
        <Route element={<Home />}>
          <Route path="profile" element={<Profile />} />
          <Route path="medical-folder" element={<MedicalFolder />} />
          <Route path="doctors" element={<ListOfDoctors />} />
          <Route path="patients" element={<ListOfPatients />} />
          <Route path="departements" element={<ListOfDepartements />} />
          <Route path="hospitals" element={<ListOfHopital />} />
          <Route path="medications" element={<ListOfMedicaments />} />
          <Route path="hopital" element={<ListOfHopital />} />
          <Route path="appointment" element={<ListOfAppointment />} />
          <Route path="employee" element={<ListOfEmployee />} />
        </Route>
        <Route path="/login" element={<Login />} />
        <Route path="/" element={<LandingPage />} />
        <Route path="/signup" element={<Signup />} />
        <Route path="/about" element={<About />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/NotFound" element={<NotFound />} />
        <Route path="*" element={<Navigate to="/NotFound" replace />} />
      </Routes>
    </>
  );
}

export default App;
