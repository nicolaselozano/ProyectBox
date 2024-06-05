import axios, { AxiosResponse } from "axios"
import { Console } from "console"
import Error from "next/error"
import { API_ENDPOINT } from "../../../vars"

export interface IUData{
    authId:string
    email:string
    id:string
    name:string
    rol:string
}

export interface IUserLikes{
    pserId:string 
    proyects:[]
}

export const getUserData = () => {
    const data = localStorage.getItem("user");
    if(data)return JSON.parse(data) as IUData; 
}

export const getUserFavs = async () => {
    try {
        const token = localStorage.getItem("token");
        const rToken= localStorage.getItem("rtoken");
        const userId= getUserData()?.id;
        const response:AxiosResponse<any> = await axios.get(`${API_ENDPOINT}/Review/userLikes?userId=${userId}`,
        {
            headers:{
                "Refresh-Token":`${rToken}`,
                "Authorization":`Bearer ${token}`
            }
        })
        console.log(response.data);
        
        return response.data as IUserLikes

    } catch (error) {
        manageError(error as Error);

        console.log("Error en getUserFavs",error);
    }
}

export const manageError = (error:Error) => {
    alert(`Hubo un error ${error.state} : ${error.context}`)
}