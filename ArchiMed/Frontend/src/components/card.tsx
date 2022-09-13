interface props {
  name: string;
  description: string;
  image: string;
}

export default function MedicalFolder(props: props) {
  return (
    <>
      <div className="cursor-pointer rounded overflow-hidden shadow-lg m-5 hover:scale-110">
        <img
          className="w-full"
          src={props.image}
          alt="Sunset in the mountains"
        />
        <div className="px-6 py-4">
          <div className="font-bold text-xl mb-2">{props.name}</div>
          <p className="text-gray-700 text-base">{props.description}</p>
        </div>
        <div className="pb-2 flex justify-around">
          <button className="bg-blue-100 rounded-full px-3 py-1 text-l font-semibold text-gray-700 mr-2 mb-2">
            Voir Plus
          </button>
        </div>
      </div>
    </>
  );
}
