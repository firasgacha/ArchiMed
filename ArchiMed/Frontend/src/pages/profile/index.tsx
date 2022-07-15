import { useState } from "react";

export default function Profile() {
  const [count, setCount] = useState(0);

  return (
    <>
      Hello Fedi
      <button
        onClick={() => {
          setCount((v) => v + 1);
        }}
      >
        {count}
      </button>
    </>
  );
}
