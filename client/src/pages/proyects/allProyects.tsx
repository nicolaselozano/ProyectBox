import React, { useEffect, useState } from "react";
import Link from "next/link";
import { getUserProyects } from "@/Services/proyect/getUserProyects";
import { AxiosResponse } from "axios";

const Proyects : React.FC = () => {

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
                    
                    <div key={key}>
                        <ul>
                            <li>{proyect.name}</li>
                            <li>{proyect.url}</li>
                            <li>{proyect.image}</li>
                            <li>{proyect.role}</li>
                        </ul>
                    </div>

                )
            }
        </div>
    )

}

export default Proyects;