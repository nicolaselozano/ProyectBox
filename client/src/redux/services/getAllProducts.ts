import axios, { AxiosResponse } from "axios";
import { API_ENDPOINT } from "../../../vars";
import { addProduct, reset, setError, setLoadingFalse, setLoadingTrue } from "../slices/Product";
import { Dispatch } from "@reduxjs/toolkit";

export const getAllProducts = async (dispatch:Dispatch) =>  {

    try {
        dispatch(setLoadingTrue())
        const response: AxiosResponse<any> = await axios.get(`${API_ENDPOINT}/Proyect`);

        
        dispatch(setLoadingFalse());
        dispatch(setError({}))
        dispatch(addProduct(response.data));  

    } catch (error) {
        dispatch(setLoadingFalse());
        dispatch(setError(error.response));
        console.error('Error al tomar los Proyectos del Usuario'+error);
    }


}

export const resetAllProducts = async (dispatch:Dispatch) =>  {
    dispatch(reset());
}

