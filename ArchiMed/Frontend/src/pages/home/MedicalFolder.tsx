import Card from "components/card";

export default function MedicalFolder() {
  const listNames = [
    {
      name: "Mohamed",
      description: "hwudwopdpqwdkwqp",
      image: "https://via.placeholder.com/150",
    },
    {
      name: "Jihed",
      description: "hwudwopdpqwdkwqp",
      image: "https://via.placeholder.com/150",
    },
    {
      name: "Salah",
      description: "hwudwopdpqwdkwqp",
      image: "https://via.placeholder.com/150",
    },
    {
      name: "Salah",
      description: "hwudwopdpqwdkwqp",
      image: "https://via.placeholder.com/150",
    },
    {
      name: "Salah",
      description: "hwudwopdpqwdkwqp",
      image: "https://via.placeholder.com/150",
    },
  ];
  return (
    <>
      <h1>Hello Jihed</h1>
      <div className="flex justify-between">
        {listNames.map((el) => (
          <div className="w-[25%] ">
            <Card {...el} />
          </div>
        ))}
      </div>
    </>
  );
}
