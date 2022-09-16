import axios from "axios";
import { useState } from "react";
import { Link } from "react-router-dom";

export default function Contact() {

    const [name, setname] = useState(String);
    const [email, setemail] = useState(String);
    const [message, setmessage] = useState(String);

    const addContact = async () => {
        await axios.post('Contact',
            {
                "name": name,
                "email": email,
                "message": message
            }
        )
            .then((res) => {
                console.log(res.data);
                alert("Contact sended");
            }).catch((err) => {
                console.log(err);
            }
            )
    }
    return (
        <>
            <div className="w-full flex items-center justify-center my-12">
                <div className="mt-10 md:text-5xl text-4xl font-black text-center text-indigo-600 leading-snug lg:w-3/4">
                    <Link to={"/"}>
                        <h2>ArchiMEDOnline</h2>
                    </Link>
                </div>
                <div className="absolute top-40 bg-white shadow rounded py-12 lg:px-28 px-8">
                    <p className="md:text-3xl text-xl font-bold leading-7 text-center text-gray-700">Let’s chat and get a quote!</p>
                    <div className="md:flex items-center mt-12">
                        <div className="md:w-72 flex flex-col">
                            <label className="text-base font-semibold leading-none text-gray-800">Name</label>
                            <input onChange={(e)=>setname(e.target.value)} tabIndex={0} arial-label="Please input name" type="name" className="text-base leading-none text-gray-900 p-3 focus:oultine-none focus:border-indigo-700 mt-4 bg-gray-100 border rounded border-gray-200 placeholder-gray-100" placeholder="Please input  name" />
                        </div>
                        <div className="md:w-72 flex flex-col md:ml-6 md:mt-0 mt-4">
                            <label className="text-base font-semibold leading-none text-gray-800">Email Address</label>
                            <input onChange={(e) => setemail(e.target.value)} tabIndex={0} arial-label="Please input email address" type="name" className="text-base leading-none text-gray-900 p-3 focus:oultine-none focus:border-indigo-700 mt-4 bg-gray-100 border rounded border-gray-200 placeholder-gray-100" placeholder="Please input email address" />
                        </div>
                    </div>
                    <div>
                        <div className="w-full flex flex-col mt-8">
                            <label className="text-base font-semibold leading-none text-gray-800">Message</label>
                            <textarea onChange={(e) => setmessage(e.target.value)} placeholder="Write your message here." tabIndex={0} aria-label="leave a message" role="textbox" className="h-36 text-base leading-none text-gray-900 p-3 focus:oultine-none focus:border-indigo-700 mt-4 bg-gray-100 border rounded border-gray-200 placeholder-gray-100 resize-none"/>
                        </div>
                    </div>
                    <p className="text-xs leading-3 text-gray-600 mt-4">By clicking submit you agree to our terms of service, privacy policy and how we use data as stated</p>
                    <div className="flex items-center justify-center w-full">
                        <Link to={"/"}>
                            <button className="mt-9 text-base font-semibold leading-none text-white py-4 px-10 bg-indigo-700 rounded hover:bg-indigo-600 focus:ring-2 focus:ring-offset-2 focus:ring-indigo-700 focus:outline-none mr-5">CANCEL</button>
                        </Link>
                        <button type="reset" onClick={()=>addContact()} className="mt-9 text-base font-semibold leading-none text-white py-4 px-10 bg-indigo-700 rounded hover:bg-indigo-600 focus:ring-2 focus:ring-offset-2 focus:ring-indigo-700 focus:outline-none">SUBMIT</button>
                    </div>
                </div>
            </div>
        </>
    );
}