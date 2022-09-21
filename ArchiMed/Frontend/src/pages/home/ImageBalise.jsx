import { Image } from 'cloudinary-react';
import React from 'react'

export default function ImageBalise(props) {
  return (
    <div className="h-24 w-20 lg:mb-0 mr-4">
      <Image className=" h-full w-full rounded-full overflow-hidden shadow" cloudName="du8mkgw6r" publicId={props.image} />
    </div>
  )
}
