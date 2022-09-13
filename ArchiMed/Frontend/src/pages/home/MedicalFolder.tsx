import axios from "axios";
import Card from "components/card";
import Modal from "components/model";
import { useEffect, useState, useRef } from "react";
import { useQuery } from "react-query";

interface cardInput {
  id: number;
  name: string;
  description: string;
  image: string;
  callToAction: Function;
}

export default function MedicalFolder() {
  const [medicalHistory, setMedicalHistory] = useState<cardInput[]>([]);
  const [show, setShow] = useState<boolean>(false);
  const elmId = useRef<number | undefined>();
  const showModal = (id: number) => {
    console.log("hiiiiiiiiiiiiiiiiiiii");
    elmId.current = id;
    setShow(true);
  };
  const { data, isLoading, isFetched } = useQuery("Folder", async () => {
    const res = await axios.get(
      "https://zoo-animal-api.herokuapp.com/animals/rand/10"
    );
    return res;
  });

  useEffect(() => {
    if (isFetched && data) {
      setMedicalHistory(
        data.data.map((el) => {
          const temp = {
            id: el.id,
            name: el.name,
            description: `${el.diet} | ${el.habitat}`,
            image: el.image_link,
            callToAction: showModal,
          };
          return temp;
        })
      );
    }
  }, [isFetched, data]);

  return (
    <>
      {!isLoading ? (
        <>
          <h2
            className="text-2xl mt-12 font-bold text-blue-500 after:content-['']
after:inline-block after:bg-blue-500 after:h-1 after:ml-5 after:w-[80%] mb-2"
          >
            2022
          </h2>

          <div className="flex justify-start flex-wrap pl-5 border-solid border-l-4 border-blue-500">
            {medicalHistory.map((el) => (
              <div className="min-w-[250px] max-w-[350px]" key={el.id}>
                <Card {...el} />
              </div>
            ))}
          </div>
          <Modal show={show} id={elmId.current} setShow={setShow} />
        </>
      ) : (
        <div> ...Loading</div>
      )}
    </>
  );
}
