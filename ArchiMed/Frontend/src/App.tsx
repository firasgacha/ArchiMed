import "./App.css";
import Home from "./pages/home";
import {Routes, Route, Navigate} from "react-router-dom";
import Profile from "./pages/profile";
import Login from "./pages/Login";
import NotFound from "./pages/NotFound";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/profile" element={<Profile />} />
        <Route path="/login" element={<Login />} />
        <Route path="/NotFound" element={<NotFound />} />
        <Route path="/NotFound" element={<NotFound />} />
          <Route
              path="*"
              element={<Navigate to="/NotFound" replace />}
          />
      </Routes>
    </>
  );
}

export default App;
