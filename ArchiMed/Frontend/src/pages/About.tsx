import React from "react";

const About = () => {
    return (
        <div id="about">
            <div className="2xl:container 2xl:mx-auto lg:py-16 lg:px-20 md:py-12 md:px-6 py-9 px-4">
                <div className="flex flex-col lg:flex-row justify-between gap-8">
                    <div className="w-full lg:w-5/12 flex flex-col justify-center">
                        <h1 className="text-3xl lg:text-4xl font-bold leading-9 text-gray-800 pb-4">About Us</h1>
                        <p className="font-normal text-base leading-6 text-gray-600 ">
                            Hospitals need a managed service for managing their clients' medical records.
                            Clients need the ability to access and transfer their medical data easily.
                        </p>
                    </div>
                    <div className="w-full lg:w-8/12 ">
                        <img className="w-full h-full" src="https://i.ibb.co/FhgPJt8/Rectangle-116.png" alt="A group of People" />
                    </div>
                </div>
                <div className="w-full lg:w-5/12 flex flex-col justify-center mt-20">
                    <h1 className="text-3xl lg:text-4xl font-bold leading-9 text-gray-800 pb-4">Our Team Members</h1>
                </div>
                <div className="flex justify-evenly mt-10">
                    <div className="p-4 pb-6 flex justify-center flex-col items-center">
                        <img className="md:block hidden w-[109px] h-[136px]" src="src/assets/mj.png" alt="Jihed Mastouri Img" />
                        <p className="font-medium text-xl leading-5 text-gray-800 mt-4">Jihed Mastouri</p>
                    </div>
                    <div className="p-4 pb-6 flex justify-center flex-col items-center">
                        <img className="md:block hidden w-[109px] h-[136px]" src="src/assets/fg.jpg" alt="Firas Gacha Img" />
                        <p className="font-medium text-xl leading-5 text-gray-800 mt-4">Firas Gacha</p>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default About;
