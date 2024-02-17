import React, { useEffect, useState } from "react";
import { AxiosResponse } from "axios";
import { getUserProyects } from "@/Services/proyect/getUserProyects";
import style from "./AllItems.module.css"

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
        <div>
            <h1>Productos</h1>
            {
                allProducts.map((proyect,key) => 
                <a href={proyect.url} className="" target="_blank" key={key}>
                    <div className={`${style.container} bg-cards_bg 
                    border border-solid border-cards_border border-4 rounded-md`}>
                        <img className={`${style.image} max-w-48`} src={proyect.image} alt={proyect.name} />
                        <div className={style.details}>
                        <h2 className="text-xl font-semibold mb-2">{proyect.name}</h2>
                        <p className="mb-2">{proyect.url}</p>
                        <p className="">{proyect.role}</p>
                        </div>
                    </div>
                </a>


                )
            }
        </div>

    )

}

export default AllItems;