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
            <img className={`${style.image} max-w-48 mx-auto mb-4`} src={image} alt={name} />
            <div className="text-center">
                <h2 className="text-2xl font-bold mb-2 text-darkPurple-200">{name}</h2>
                <p className="text-darkPurple-300 mb-2">Url: <span className="text-darkPurple-100">{url}</span></p>
                <p className="text-darkPurple-300">Role: <span className="text-darkPurple-100">{role}</span></p>
            </div>
        </div>

    )

}

export default Item;