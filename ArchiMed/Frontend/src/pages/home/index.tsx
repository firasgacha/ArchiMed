import { useState } from "react";

export default function Home() {
  const [count, setCount] = useState(0);
  const [valueArray, setValueArry] = useState<string[]>([]);
  return (
    <>
      <button
        onClick={() => {
          setCount((v) => v + 1);
        }}
        className="px-5"
      >
        {count}
      </button>
      <ul>
        {valueArray.map((el) => (
          <li>{el} </li>
        ))}
      </ul>
    </>
  );
}
