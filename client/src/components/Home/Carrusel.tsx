"use client"
import { getAllProducts } from "@/redux/services/getAllProducts";
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
        dispatch(getAllProducts())
    },[dispatch])

  return (
    <div className="mt-4 h-56 sm:h-64 xl:h-80 2xl:h-96">
      <Carousel theme={customTheme}>
        <div className="flex h-full items-center justify-center bg-general_bg/30 dark:bg-general_bg dark:text-white">
            {allProduct.length && !error.message ? 
            <a href={allProduct[0].url} target="_blank">
              <Item proyect={allProduct[0]}/>
            </a>
            : error.message ? <h1>{error.message}</h1> : <h1>loading...</h1>}
        </div>
        <div className="flex h-full items-center justify-center bg-general_bg/30 dark:bg-general_bg dark:text-white">
            {allProduct[0] && !error.message ? 
            <h1>Item 2</h1>
            : error.message || !allProduct[1]  ? <h1>{error.message}</h1> : <h1>loading...</h1>}
        </div>
        <div className="flex h-full items-center justify-center bg-general_bg/30 dark:bg-general_bg dark:text-white">
            {allProduct[0] && !error.message ?
            <h2>item 3</h2>
            : error.message || !allProduct[2]  ? <h1>{error.message}</h1> : <h1>loading...</h1>}
        </div>
      </Carousel>
    </div>
  );
};

export default Carrusel;
