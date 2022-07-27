import { useState } from "react";
import Navbar from "../../components/Navbar";

export default function Profile() {
  const [count, setCount] = useState(0);

  return (
    <>
      <Navbar />
        <div>Profile</div>
    </>
  );
}
