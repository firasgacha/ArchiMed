import { PageWithSide } from "@AppLayout";
import NavBar from "./NavBar";

const listOfLinks = [
  {
    name: "home",
    icon: "home",
    link: "/",
  },
];

export default function Home() {
  return (
    <>
      <NavBar />
      <PageWithSide linkList={listOfLinks}>
        <h1>HI</h1>
        <p> LoooooL </p>
        <div className="mockup-code bg-primary text-primary-content">
          <pre>
            <code>can be any color!</code>
          </pre>
        </div>
      </PageWithSide>
    </>
  );
}
