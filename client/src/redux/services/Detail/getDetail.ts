import { reset, setError } from "@/redux/slices/Product";
import { Dispatch } from "@reduxjs/toolkit";
import axios, { AxiosResponse } from "axios";
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