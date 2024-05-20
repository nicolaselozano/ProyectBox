import axios, { AxiosResponse } from "axios";
import { API_ENDPOINT } from "../../../vars"

export const getUserProyects = async () => {
    
    try {
        
        const response: AxiosResponse<any> = await axios.get(`${API_ENDPOINT}/Proyect`);

        console.log(response.data);
        return response;        

    } catch (error) {
        console.error('Error al tomar los Proyectos del Usuario'+error);
    }

}