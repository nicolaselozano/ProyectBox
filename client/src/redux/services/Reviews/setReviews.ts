import { reset, setError, setLoading } from "@/redux/slices/Reviews";
import { Dispatch } from "@reduxjs/toolkit";
import axios, { AxiosResponse } from "axios";
import { UUID } from "crypto";
import { API_ENDPOINT } from "../../../../vars";
import { headers } from "next/headers";

export const setReviews = (id:UUID,emailUser:string | null,like:boolean ) => async (dispatch:Dispatch) => {

    try {
        dispatch(reset());
        dispatch(setLoading(true));

        const data = {
            like: like, 
            emailUser: emailUser,
            proyectId: id
        };

        const token = localStorage.getItem("token");

        const headers = {
            'Authorization': `Bearer ${token}`,
            "Content-Type": "application/json"
        };

        const response = await axios.post(`${API_ENDPOINT}/Review`, data, { headers });
        
        console.log(response.data);
        
        dispatch(setLoading(false));
        
    } catch (error) {
        dispatch(setError(error));

        console.error('Error response:', error);
    }

}