import { UUID } from "crypto";
import Item from "../Proyects/Item/Item";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { AppDispatch, useAppSelector } from "@/redux/store";
import { getDetail, resetDetail } from "@/redux/services/Detail/getDetail";
import { Product } from "../Proyects/AllItems/AllItems";
interface IId {
    id:string
}

const CDetail = ({id}:IId) => {

    const {product}:{product:Product | {}} = useAppSelector(state => state.detailReducer);

    const dispatch = useDispatch<AppDispatch>();

    

    useEffect(() =>{
        dispatch(getDetail(id));

        return () => dispatch(resetDetail);
    },[dispatch,id])

    return (
        <div>
            {
            product && Object.keys(product).length > 0 &&
            <div>
                <Item proyect={product as Product} />
                <h1 className="ml-4">{product.description}</h1>

                <button></button>
            </div>
            }
        </div>
    )

}

export default CDetail;