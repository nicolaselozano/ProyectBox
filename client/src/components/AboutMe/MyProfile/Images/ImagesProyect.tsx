import Image from 'next/image';
import React from 'react';

interface IImage {
  id: string;
  proyectId: string;
  url: string;
}

const ImagesProyect: React.FC<{ imgs: IImage[] }> = ({ imgs }) => {
  return (
    <div className="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-5 gap-4">
      {imgs.length ? (
        imgs.map((img, key) => (
          <div key={key} className="relative m-5 overflow-hidden">
            <Image
            src={img.url}
            alt={`image_${key}`}
            className="w-full h-full"
            />
          </div>
        ))
      ) : (
        null
      )}
    </div>
  );
};

export default ImagesProyect;


