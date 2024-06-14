import axios, { AxiosResponse } from "axios"
import Error from "next/error"
import { API_ENDPOINT } from "../../../vars"
import { UUID } from "crypto"

interface UserProyect{
    proyectsId?:string
    userId?: UUID
    user?:any
}
export interface IUData{
    email:string
    id:UUID
    name:string
    userProyects?: UserProyect[];
    rol?:any
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

export const editUser = async (data:IUData) => {

    try {
        console.log(data);
        
        const token = localStorage.getItem("token");
        const rToken= localStorage.getItem("rtoken");

        const response = await axios.put(`${API_ENDPOINT}/User`, data, {
            headers: {
              "Refresh-Token": `${rToken}`,
              "Authorization": `Bearer ${token}`,
            },
        });

        console.log(response.data);
        return data;

    } catch (error:any) {
        console.error('Bad request: ' + error.response.data);
    }

}

export const manageError = (error:Error) => {
    console.error(`Hubo un error ${error.state} : ${error.context}`)
}