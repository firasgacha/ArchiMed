import axios from "axios";
import Card from "components/card";
import { useEffect, useState } from "react";
import { useQuery } from "react-query";

interface cardInput {
  name: string;
  description: string;
  image: string;
}

export default function MedicalFolder() {
  const [medicalHistory, SetMedicalHistory] = useState<cardInput[]>([]);
  const { data, isLoading, isFetched } = useQuery("Folder", async () => {
    const res = await axios.get(
      "https://zoo-animal-api.herokuapp.com/animals/rand/10"
    );
    return res;
  });

  useEffect(() => {
    if (isFetched && data) {
      console.log(data.data);
      SetMedicalHistory(
        data.data.map((el) => {
          const temp = {
            name: el.name,
            description: `${el.diet} | ${el.habitat}`,
            image: el.image_link,
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
              <div className="min-w-[250px] max-w-[350px]">
                <Card {...el} />
              </div>
            ))}
          </div>
        </>
      ) : (
        <div> ...Loading</div>
      )}
    </>
  );
}
