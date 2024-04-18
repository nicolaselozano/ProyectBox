import { reset, setError } from "@/redux/slices/Product";
import { Dispatch } from "@reduxjs/toolkit";
import axios, { AxiosRequestConfig, AxiosResponse } from "axios";
import { API_ENDPOINT } from "../../../../vars";
import { setLoading, setProduct } from "@/redux/slices/Detail";

export const getDetail = (id:string) => async (dispatch:Dispatch)  => {

    try {
        dispatch(reset())
        dispatch(setLoading(true));

        const response: AxiosResponse<any> = await axios.get(`${API_ENDPOINT}/Proyect/${id}`);
        console.log(response.data);
        
        dispatch(setProduct(response.data))

    } catch (error) {
        dispatch(setLoading(false));
        dispatch(setError(error));
        throw new Error("Error al obtner el detalle del Proyecto : " + error);
    }

}

export const resetDetail = (dispatch:Dispatch) => {
    dispatch(reset());
}

const getReviews = async () => {

    try {

        const config:AxiosRequestConfig<any> = {
            data:{
                "like": true,
                "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                "proyectId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
            }
        }
        
        const response:AxiosResponse<any> = await axios.get(`${API_ENDPOINT}/Review`,config);

        return response;

    } catch (error) {
        
    }

}