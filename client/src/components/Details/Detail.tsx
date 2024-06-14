import { UUID } from "crypto";
import Item from "../Proyects/Item/Item";
import { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { AppDispatch, useAppSelector } from "@/redux/store";
import { getDetail, resetDetail } from "@/redux/services/Detail/getDetail";
import { Product } from "../Proyects/AllItems/AllItems";

import style from "./Detail.module.css";
import { setReviews } from "@/redux/services/Reviews/setReviews";
import { getProyectReview } from "@/redux/services/Reviews/getProyectReview";

interface IId {
    id:UUID
}

const CDetail = ({id}:IId) => {

    const {product,reviews,loading}:{product:Product | any | {},reviews:number | null, loading:boolean} = useAppSelector(state => state.detailReducer);
    const {error}:{error:any|{status:any}}= useAppSelector(state => state.reviewReducer);

    const [actualR, setActualR] = useState<any>(reviews);

    const dispatch = useDispatch<AppDispatch>();
    
    const [buttonStatus,setButtonStatus] = useState(0)

    useEffect(() => {
        
        const email = localStorage.getItem("email");
        
        dispatch(getDetail(id));

        const getLikeCountUser = async () => {
            
            const response = await getProyectReview(id,email);

            if(response){
                setButtonStatus(1);
                setActualR(reviews);
                handleLikeButton();
            } else setButtonStatus(0);
        }
        
        getLikeCountUser();

        return () => {
            dispatch(resetDetail);
        };

    },[dispatch,id]); 

    useEffect(() => {
        setActualR(reviews);
        console.log(error);
        if(error?.status == 429) alert("Se hicieron muchas request");
    },[dispatch,error.status])

    useEffect(() => {
        
        const getLikeCountUser = async () => {
            if(actualR == null) setActualR(reviews);
        }

        getLikeCountUser();

    },[reviews,loading,dispatch])

    const handleLikeButton = () => {

        if(!localStorage.getItem("token")) return alert("inicie sesion para poder dar me gusta")      

        const email = localStorage.getItem("email");
        
        if (buttonStatus === -1) {
            return ;
        }
        if (buttonStatus === 1) {
            setActualR((prev: any) => prev - 1); 
            setButtonStatus(0);
            dispatch(setReviews(id, email, false));

        } else {
            setActualR((prev: any) => prev + 1);
            setButtonStatus(1);
            dispatch(setReviews(id, email, true));
        }

    };

    return (
        <div className="flex justify-center">
            {
            product && Object.keys(product).length > 0 ?
            <div>
                <div className={style.container__like}>

                    <button type="button" 
                    className="text-violet-700 border border-violet-700 hover:bg-violet-700 hover:text-violet-200 focus:ring-2 focus:outline-none focus:ring-violet-300 font-medium rounded-full text-sm p-2.5 text-center inline-flex items-center dark:border-violet-500 dark:text-violet-500 dark:hover:text-violet-900 dark:focus:ring-violet-900 dark:hover:bg-violet-500"
                    onClick={handleLikeButton}>
                        <svg className="w-4 h-4" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 18 18">
                        <path d="M3 7H1a1 1 0 0 0-1 1v8a2 2 0 0 0 4 0V8a1 1 0 0 0-1-1Zm12.954 0H12l1.558-4.5a1.778 1.778 0 0 0-3.331-1.06A24.859 24.859 0 0 1 6 6.8v9.586h.114C8.223 16.969 11.015 18 13.6 18c1.4 0 1.592-.526 1.88-1.317l2.354-7A2 2 0 0 0 15.954 7Z"/>
                        </svg>
                        <span className="sr-only">Icon description</span>
                    </button>

                    <span className="ml-5">{actualR ? actualR : 0}</span>

                </div>
                <Item proyect={product as Product} />
                
                <h1 className="ml-4">{product.description}</h1>
            </div> : <button disabled type="button" className="w-32 text-white bg-general_bg  focus:ring-4  font-medium rounded-lg text-sm px-5 py-2.5 text-center me-2 dark:bg-general_bg inline-flex items-center">
            <svg aria-hidden="true" role="status" className="inline w-4 h-4 me-3 text-white animate-spin" viewBox="0 0 100 101" fill="none" xmlns="http://www.w3.org/2000/svg">
            <path d="M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z" fill="#E5E7EB"/>
            <path d="M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z" fill="currentColor"/>
            </svg>
            Loading...
            </button>
            }
        </div>
    )

}

export default CDetail;