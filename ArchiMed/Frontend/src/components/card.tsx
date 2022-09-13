interface props {
    id: number;
    name: string;
    description: string;
    image: string;
    callToAction: Function;
}

export default function MedicalFolder(props: props) {
    const click = () => {
        props.callToAction(props.id);
    };
    return (
        <>
            <div
                onClick={click}
                className="cursor-pointer rounded overflow-hidden shadow-lg m-5 hover:scale-110"
            >
                <img
                    className="w-[300px] h-[200px]"
                    src={props.image}
                    alt="Sunset in the mountains"
                />
                <div className="px-6 py-4">
                    <div className="font-bold text-xl mb-2 text-center">{props.name}</div>
                    <p className="text-gray-700 text-base text-center">{props.description}</p>
                </div>
                <div className="pb-2 flex justify-around">
                    <button className="bg-blue-100 rounded-full px-3 py-1 text-l font-semibold text-gray-700 mr-2 mb-2">
                        See more
                    </button>
                </div>
            </div>
        </>
    );
}