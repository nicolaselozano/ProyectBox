"use client"
import { getAllProducts, resetAllProducts } from "@/redux/services/getAllProducts";
import { AppDispatch, useAppSelector } from "@/redux/store";
import { Carousel, CustomFlowbiteTheme } from "flowbite-react";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import Item from "../Proyects/Item/Item";

const customTheme: CustomFlowbiteTheme["carousel"] = {
  control: {
    base: "inline-flex h-8 w-8 items-center justify-center rounded-full bg-general_bg/30 group-hover:bg-general_bg group-focus:outline-none group-focus:ring-2 group-focus:ring-white dark:bg-gray-800/30 dark:group-hover:bg-gray-800/60 dark:group-focus:ring-gray-800/70 sm:h-10 sm:w-10",
    icon: "h-5 w-5 text-violet_text/70 dark:text-white sm:h-6 sm:w-6",
  },
};

const Carrusel = () => {

    const {allProduct, error} = useAppSelector((state) => state.productReducer)
    const dispatch = useDispatch<AppDispatch>();

    useEffect(() => {
        dispatch(getAllProducts)

        return () => {dispatch(resetAllProducts)}
        
    },[dispatch])

  return (
    <div className="mt-4 h-56 sm:h-64 xl:h-80 2xl:h-96">
      <Carousel theme={customTheme}>
        {
          allProduct.length ? allProduct.slice(0, Math.min(3,allProduct.length)).map((proyect,key) => 
          <div key={key} className="flex h-full items-center justify-center bg-general_bg/30 dark:bg-general_bg dark:text-white">
            <a href={proyect.url} target="_blank">
              <Item proyect={proyect}/>
            </a>
          </div>
          ): error.message ? <h1>{error.message}</h1> : <h1>loading...</h1>
        }

      </Carousel>
    </div>
  );
};

export default Carrusel;
