import React from 'react'
import { Link } from 'react-router-dom'

export default function Footer() {
  return (
      <div className=" bg-indigo-50 pb-12">
          <div className="mx-auto container pt-20 lg:pt-32 flex flex-col items-center justify-center">
              <div className="w-9/12  h-0.5 bg-indigo-200 rounded-full mb-10" />
              <div className="text-black flex flex-col md:items-center f-f-l pt-3">
                  <div className="h-16 w-full flex items-center px-8 mb-10">
                      <Link to={"/"}>
                          <img src="src\assets\archimedLogo.png" alt="logo" className="mt-6" />
                      </Link>
                  </div>
                  <h1 className="text-2xl font-black">Archi.MED.Online.</h1>
                  <div className="my-6 text-base text-color f-f-l">
                      <ul className="md:flex items-center">
                          <li className=" md:mr-6 cursor-pointer pt-4 lg:py-0"><a href="#about">About</a></li>
                          <li className=" md:mr-6 cursor-pointer pt-4 lg:py-0">License</li>
                          <li className=" md:mr-6 cursor-pointer pt-4 lg:py-0"><a href="#help">Help</a></li>
                          <li className="cursor-pointer pt-4 lg:py-0">Privacy Policy</li>
                      </ul>
                  </div>
                  <div className="text-sm text-color mb-10 f-f-l">
                      <p> Copyright © 2022 - All right reserved by ArchiMEDOnline</p>
                  </div>
              </div>
          </div>
      </div>
  )
}
