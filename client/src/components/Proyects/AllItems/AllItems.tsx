import React, { useEffect, useState } from "react";
import { AxiosResponse } from "axios";
import { getUserProyects } from "@/Services/proyect/getUserProyects";
import style from "./AllItems.module.css"
import Item from "../Item/Item";

const AllItems = () => {


    const [allProducts, setAllProducts] = useState<any[]>([]);


    useEffect(() => {

        const fetchData = async () => {

            try {
                if(!allProducts.length){
    
                    const response:AxiosResponse<any> = await getUserProyects();
                    setAllProducts(response.data);
        
                }
            } catch (error) {
                console.error(error);
            }
        }

        fetchData();

    },[allProducts])

    return(
        <div className={style.container}>
            <h1 className="text-4xl font-bold text-violet_text shadow-lg animate-shine">Proyectos</h1>
            {
                allProducts.map((proyect,key) => 
                <a href={proyect.url} className="" target="_blank" key={key}>
                    <div className={`${style.container__item} bg-cards_bg 
        border border-solid border-cards_border border-4 rounded-md animate-borde_shine`}>
                        <Item proyect={proyect} />
                    </div>
                </a>
                )
            }
        </div>

    )

}

export default AllItems;