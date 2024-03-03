import React, { useEffect } from "react";
import style from "./AllItems.module.css"
import Item from "../Item/Item";
import { AppDispatch, useAppSelector } from "@/redux/store";
import { useDispatch } from "react-redux";
import { getAllProducts, resetAllProducts } from "@/redux/services/getAllProducts";

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
                    allProduct.length ? allProduct.map((proyect,key) => 
                    <a href={proyect.url} className="" target="_blank" key={key}>
                        <div className={`${style.container__item} bg-cards_bg 
            border border-solid border-cards_border border-4 rounded-md animate-borde_shine`}>
                            <Item proyect={proyect} />
                        </div>
                    </a>
                    ): <h1>Loading...</h1>
                }
            </div>
        </div>


    )

}

export default AllItems;