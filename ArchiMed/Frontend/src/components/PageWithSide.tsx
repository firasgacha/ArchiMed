import React from "react";
import { Link } from "react-router-dom";

type Props = {
  linkList: Array<{
    name: string;
    icon: string;
    link: string;
  }>;
  children: React.ReactNode;
};

const PageWithSide: React.FC<Props> = ({ linkList, children }) => (
  <div className="drawer drawer-mobile">
    <input id="my-drawer-2" type="checkbox" className="drawer-toggle" />
    <div className="drawer-content flex flex-col items-center justify-center">
      {children}
      <label
        htmlFor="my-drawer-2"
        className="btn btn-primary drawer-button lg:hidden"
      >
        Open drawer
      </label>
    </div>
    <div className="drawer-side">
      <label htmlFor="my-drawer-2" className="drawer-overlay"></label>
      <ul className="menu p-4 overflow-y-auto w-80 bg-zinc-500 text-base-content">
        {linkList.map((el) => {
          return (
            <li key={el.name}>
              <Link to={el.link}>
                <a>
                  <span>el.icon</span>
                  el.name
                </a>
              </Link>
            </li>
          );
        })}
      </ul>
    </div>
  </div>
);

export default PageWithSide;
