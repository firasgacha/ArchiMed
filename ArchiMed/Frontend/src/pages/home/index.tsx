import React, { useEffect, useState } from "react";
import { Link, Outlet, useLocation, useParams } from "react-router-dom";

// SVG
import SVGA from "assets/a.svg";
import CompasSVG from "assets/compas.svg";
import UserSVG from "assets/user.svg";
import GridSVG from "assets/grid.svg";
import PuzzleSVG from "assets/puzzle.svg";
import CodeSVG from "assets/code.svg";
import SearchSVG from "assets/search.svg";
import BellSvg from "assets/bell.svg";
import PuzzleSvg from "assets/puzzle.svg";
import MessagesSvg from "assets/messages.svg";
import LogoutSvg from "assets/logout.svg";
import PointerSvg from "assets/pointer.svg";
import ChevronSvg from "assets/chevron.svg";

export default function Navbar() {
  const [show, setShow] = useState(false);
  const [profile, setProfile] = useState(false);
  const location = useLocation();
  const [pageName, setPageName] = useState("");

  useEffect(() => {
    const temp = location.pathname.slice(1).replace(/([A-Z])/g, " $1");
    setPageName(location.pathname.charAt(1).toUpperCase() + temp.slice(1));
  }, [location]);

  return (
    <div
      className="w-full min-h-screen h-fit bg-gray-200"
      style={{ overflow: show ? "clip" : "" }}
    >
      <div className="flex flex-no-wrap">
        {/* Sidebar starts */}
        <div className="fixed w-64 h-screen top-16 shadow bg-gray-100 hidden lg:block">
          <div className="h-16 w-full flex items-center px-8">
            <SVGA />
          </div>
          <ul aria-orientation="vertical" className=" py-6">
            <li className="pl-6 cursor-pointer text-white text-sm leading-3 tracking-normal pb-4 pt-5 text-indigo-700 focus:text-indigo-700 focus:outline-none">
              <div className="flex items-center">
                <div>
                  <GridSVG />
                </div>
                <Link to={"/medical-folder"}>
                  <span className="ml-2">Medical Folder</span>
                </Link>
              </div>
            </li>
            <li className="pl-6 cursor-pointer text-gray-600 text-sm leading-3 tracking-normal mt-4 mb-4 py-2 hover:text-indigo-700 focus:text-indigo-700 focus:outline-none">
              <div className="flex items-center">
                <PuzzleSvg />
                <Link to={"doctors"}>
                  <span className="ml-2">List of doctors</span>
                </Link>
              </div>
            </li>
            <li className="pl-6 cursor-pointer text-gray-600 text-sm leading-3 tracking-normal mb-4 py-2 hover:text-indigo-700 focus:text-indigo-700 focus:outline-none">
              <div className="flex items-center">
                <CompasSVG />
                <Link to={"patients"}>
                  <span className="ml-2">List of patients</span>
                </Link>
              </div>
            </li>
            <li className="pl-6 cursor-pointer text-gray-600 text-sm leading-3 tracking-normal py-2 hover:text-indigo-700 focus:text-indigo-700 focus:outline-none">
              <div className="flex items-center">
                <CodeSVG />
                <span className="ml-2">Deliverables</span>
              </div>
            </li>
          </ul>
        </div>
        {/*Mobile responsive sidebar*/}
        <div
          className={
            show
              ? "w-full h-full fixed z-40  transform  translate-x-0 "
              : "   w-full h-full absolute z-40  transform -translate-x-full"
          }
          id="mobile-nav"
        >
          <div
            className="bg-gray-800 opacity-50 absolute h-full w-full lg:hidden"
            onClick={() => setShow(!show)}
          />
          <div className="absolute z-40 sm:relative w-64 md:w-96 shadow pb-4 bg-gray-100 lg:hidden transition duration-150 ease-in-out h-full">
            <div className="flex flex-col justify-between h-full w-full">
              <div>
                <div className="flex items-center justify-between px-8">
                  <div className="h-16 w-full flex items-center">
                    <SVGA />
                  </div>
                  <div
                    id="closeSideBar"
                    className="flex items-center justify-center h-10 w-10"
                    onClick={() => setShow(!show)}
                  ></div>
                </div>
                <ul aria-orientation="vertical" className=" py-6">
                  <li className="pl-6 cursor-pointer text-white text-sm leading-3 tracking-normal pb-4 pt-5 text-indigo-700 focus:text-indigo-700 focus:outline-none">
                    <div className="flex items-center">
                      <div className="w-6 h-6 md:w-8 md:h-8">
                        <GridSVG />
                      </div>
                      <Link to={"/medical-folder"}>
                        <span className="ml-2">Medical Folder</span>
                      </Link>{" "}
                    </div>
                  </li>
                  <li className="pl-6 cursor-pointer text-gray-600 text-sm leading-3 tracking-normal mt-4 mb-4 py-2 hover:text-indigo-700 focus:text-indigo-700 focus:outline-none">
                    <div className="flex items-center">
                      <div className="w-6 h-6 md:w-8 md:h-8">
                        <PuzzleSVG />
                      </div>
                      <Link to={"doctors"}>
                        <span className="ml-2">List of doctors</span>
                      </Link>
                    </div>
                  </li>
                  <li className="pl-6 cursor-pointer text-gray-600 text-sm leading-3 tracking-normal mb-4 py-2 hover:text-indigo-700 focus:text-indigo-700 focus:outline-none">
                    <div className="flex items-center">
                      <div className="w-6 h-6 md:w-8 md:h-8">
                        <CompasSVG />
                      </div>
                      <Link to={"patients"}>
                        <span className="ml-2">List of patients</span>
                      </Link>
                    </div>
                  </li>
                  <li className="pl-6 cursor-pointer text-gray-600 text-sm leading-3 tracking-normal py-2 hover:text-indigo-700 focus:text-indigo-700 focus:outline-none">
                    <div className="flex items-center">
                      <div className="w-6 h-6 md:w-8 md:h-8">
                        <CodeSVG />
                      </div>
                      <span className="ml-2 xl:text-base md:text-2xl text-base">
                        Deliverables
                      </span>
                    </div>
                  </li>
                </ul>
              </div>
              {/* New Section */}
              <div className="w-full">
                <div className="flex justify-center mb-4 w-full px-6">
                  <div className="relative w-full">
                    <div className="text-gray-500 absolute ml-4 inset-0 m-auto w-4 h-4">
                      <SearchSVG />
                    </div>
                    <input
                      className="bg-gray-200 focus:outline-none rounded w-full text-sm text-gray-500  pl-10 py-2"
                      type="text"
                      placeholder="Search"
                    />
                  </div>
                </div>
                <div className="border-t border-gray-300">
                  <div className="w-full flex items-center justify-between px-6 pt-1">
                    <div className="flex items-center">
                      <img
                        alt="profile-pic"
                        src="https://tuk-cdn.s3.amazonaws.com/assets/components/boxed_layout/bl_1.png"
                        className="w-8 h-8 rounded-md"
                      />
                      <p className="md:text-xl text-gray-800 text-base leading-4 ml-2">
                        Jane Doe
                      </p>
                    </div>
                    <ul className="flex">
                      <li className="cursor-pointer text-white pt-5 pb-3">
                        <MessagesSvg />
                      </li>
                      <li className="cursor-pointer text-white pt-5 pb-3 pl-3">
                        <BellSvg />
                      </li>
                    </ul>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        {/*Mobile responsive sidebar*/}
        {/* Sidebar ends */}
        <div className="w-full">
          {/* Navigation starts */}
          <nav className="h-16 flex items-center lg:items-stretch justify-end lg:justify-between bg-white shadow fixed w-full z-10">
            <div className="hidden lg:flex w-full pr-6">
              <div className="w-1/2 h-full hidden lg:flex items-center pl-6 pr-24">
                <div className="relative w-full">
                  <div className="text-gray-500 absolute ml-4 inset-0 m-auto w-4 h-4">
                    <SearchSVG />
                  </div>
                  <input
                    className="border border-gray-100 focus:outline-none focus:border-indigo-700 rounded w-full text-sm text-gray-500 bg-gray-100 pl-12 py-2"
                    type="text"
                    placeholder="Search"
                  />
                </div>
              </div>
              <div className="w-1/2 hidden lg:flex">
                <div className="w-full flex items-center pl-8 justify-end">
                  <div className="h-full w-20 flex items-center justify-center border-r border-l">
                    <div className="relative cursor-pointer text-gray-600">
                      <BellSvg />
                      <div className="w-2 h-2 rounded-full bg-red-400 border border-white absolute inset-0 mt-1 mr-1 m-auto" />
                    </div>
                  </div>
                  <div className="h-full w-20 flex items-center justify-center border-r mr-4 cursor-pointer text-gray-600">
                    <BellSvg />
                  </div>
                  <div
                    className="flex items-center relative cursor-pointer"
                    onClick={() => setProfile(!profile)}
                  >
                    <div className="rounded-full">
                      {profile ? (
                        <ul className="p-2 w-full border-r bg-white absolute rounded left-0 shadow mt-12 sm:mt-16 ">
                          <li className="flex w-full justify-between text-gray-600 hover:text-indigo-700 cursor-pointer items-center">
                            <Link to={"/profile"} className="flex items-center">
                              <UserSVG />
                              <span className="text-sm ml-2">My Profile</span>
                            </Link>
                          </li>
                          <li className="flex w-full justify-between text-gray-600 hover:text-indigo-700 cursor-pointer items-center mt-2">
                            <div className="flex items-center">
                              <LogoutSvg />
                              <span className="text-sm ml-2">Sign out</span>
                            </div>
                          </li>
                        </ul>
                      ) : (
                        ""
                      )}
                      <div className="relative">
                        <img
                          className="rounded-full h-10 w-10 object-cover"
                          src="https://tuk-cdn.s3.amazonaws.com/assets/components/sidebar_layout/sl_1.png"
                          alt="avatar"
                        />
                        <div className="w-2 h-2 rounded-full bg-green-400 border border-white absolute inset-0 mb-0 mr-0 m-auto" />
                      </div>
                    </div>
                    <p className="text-gray-800 text-sm mx-3">Jane Doe</p>
                    <div className="cursor-pointer text-gray-600">
                      <ChevronSvg />
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div
              className="text-gray-600 mr-8 visible lg:hidden relative"
              onClick={() => setShow(!show)}
            >
              {show ? " " : <PointerSvg />}
            </div>
          </nav>
          {/* Navigation ends */}
          {/* Remove class [ h-64 ] when adding a card block */}
          {/* MAIN */}
          <div
            className="relative top-16 lg:ml-64 mx-auto container bg-gray-200 lg:max-w-[calc(100%-17rem)] w-screen min-h-[calc(100vh-5rem)]"
            style={{ overflow: show ? "hidden" : "visible" }}
          >
            {/* Remove class [ border-dashed border-2 border-gray-300 ] to remove dotted border */}
            {/* Place your content here */}
            <div className="pt-5 lg:pl-10 mb-24">
              <div className="bg-white p-10 2xl:p-5">
                <div className="container mx-auto bg-white rounded">
                  <div className="xl:w-full border-b border-gray-300 py-5 bg-white">
                    <div className="flex w-11/12 mx-auto xl:w-full xl:mx-0 items-center">
                      <p className="text-lg text-gray-800 font-bold">
                        {pageName}
                      </p>
                      <div className="ml-2 cursor-pointer text-gray-600 ">
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          viewBox="0 0 24 24"
                          width={16}
                          height={16}
                        >
                          <path
                            className="heroicon-ui"
                            d="M12 22a10 10 0 1 1 0-20 10 10 0 0 1 0 20zm0-2a8 8 0 1 0 0-16 8 8 0 0 0 0 16zm0-9a1 1 0 0 1 1 1v4a1 1 0 0 1-2 0v-4a1 1 0 0 1 1-1zm0-4a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"
                            fill="currentColor"
                          />
                        </svg>
                      </div>
                    </div>
                  </div>
                  <div className="mx-auto">
                    {/*Content*/}
                    <Outlet />
                    {/*Content*/}
                  </div>
                </div>
              </div>
            </div>
            {/*Footer*/}
            <footer className="sticky top-full footer p-4 justify-center text-base-content">
              <p>
                Copyright © 2022 - All right reserved by ACME Industries Ltd
              </p>
            </footer>
            {/*Footer*/}
          </div>
        </div>
      </div>
    </div>
  );
}
