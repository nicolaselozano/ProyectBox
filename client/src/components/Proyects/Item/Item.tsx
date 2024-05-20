import { Url } from "next/dist/shared/lib/router/router"
import style from "./Item.module.css"
import Image from "next/image"
import { UUID } from "crypto"

interface Item{
    proyect:{
        id:UUID
        image:string
        name:string
        url:string
        role:string
        description:string
    }
}

const Item = ({proyect}:Item) => {
    
    const {image,name,url,role} = proyect;

    return(

        <div className="m-4">
            <img className={`${style.image} max-w-48`} src={image} alt={name} />
            <div className={style.details}>
            <h2 className="text-xl font-semibold mb-2">{name}</h2>
            <p className="mb-2">Url : {url}</p>
            <p className="">Role : {role}</p>
            </div>
        </div>

    )

}

export default Item;