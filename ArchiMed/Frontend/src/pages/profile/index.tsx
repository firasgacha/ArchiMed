import { useState } from "react";

export default function Profile() {
  const [count, setCount] = useState(0);

  return (
    <>
      <h1 className="px-5">Hiiiiiiii</h1>
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
