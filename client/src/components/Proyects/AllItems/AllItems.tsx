import React, { useEffect } from "react";
import style from "./AllItems.module.css"
import Item from "../Item/Item";
import { AppDispatch, useAppSelector } from "@/redux/store";
import { useDispatch } from "react-redux";
import { getAllProducts, resetAllProducts } from "@/redux/services/getAllProducts";
import { UUID } from "crypto";
import Link from "next/link";

export interface Product {
    id:UUID
    name:string,
    image:string,
    url:string,
    role:string,
    description:string
}

const AllItems = () => {

    const {allProduct} = useAppSelector(state => state.productReducer);
    const dispatch = useDispatch<AppDispatch>();

    useEffect(() => {
        dispatch(resetAllProducts);
        
        dispatch(getAllProducts);

    },[dispatch])

    return(
        <div>
            <h1 className="text-4xl font-bold text-violet_text shadow-lg animate-shine">Proyectos</h1>
            <div className={style.container}>
                
                {
                    allProduct.length ? allProduct.map((proyect:Product,key) => 
                    <Link href={{
                            pathname:"/pages/detail",
                            query:{id:proyect.id}
                        }} key={key}>
                        <div className={`${style.container__item} bg-cards_bg 
                            border border-solid border-cards_border border-4 rounded-md animate-borde_shine`}>
                            <Item proyect={proyect} />
                        </div>
                    </Link>
                    ): 
                    <div className="text-center">
                        <h1>Loading...</h1>
                        <div className="flex flex-wrap justify-center">
                            <div className={`${style.container__loader} bg-general_bg`}></div>
                            <div className={`${style.container__loader} bg-general_bg`}></div>
                            <div className={`${style.container__loader} bg-general_bg`}></div>
                            <div className={`${style.container__loader} bg-general_bg`}></div>
                            <div className={`${style.container__loader} bg-general_bg`}></div>
                        </div>
                    </div>

                }
            </div>
        </div>


    )

}

export default AllItems;