
import { Dispatch } from "@reduxjs/toolkit";
import axios, { AxiosRequestConfig, AxiosResponse } from "axios";
import { API_ENDPOINT } from "../../../../vars";
import { setLoading, setProduct,reset,setError } from "@/redux/slices/Detail";

export const getDetail = (id:string) => async (dispatch:Dispatch)  => {

    try {
        dispatch(reset());
        dispatch(setLoading(true));

        const response: AxiosResponse<any> = await axios.get(`${API_ENDPOINT}/Proyect/${id}`);
        const reviewCount:number  = await getReviews(id);



        console.log(response.data, reviewCount);

        dispatch(setProduct({product:response.data,reviews:reviewCount}))
        dispatch(setLoading(false));
    } catch (error:any) {
        dispatch(reset());
        dispatch(setLoading(false));
        dispatch(setError(error.response));
        console.error("Error al obtner el detalle del Proyecto : " + error);
    }

}

export const resetDetail = (dispatch:Dispatch) => {
    dispatch(reset());
}

const getReviews = async (id:string) => {

    try {
        
        const response:AxiosResponse<any> = await axios.get(`${API_ENDPOINT}/Review/count?PId=${id}`);
        
        return response.data;

    } catch (error) {
        console.error(error);
    }

}