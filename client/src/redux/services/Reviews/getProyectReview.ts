import axios, { AxiosResponse } from "axios"
import { API_ENDPOINT } from "../../../../vars"
import { UUID } from "crypto"

export const getProyectReview = async (PId:UUID,emailUser:string | null) => {

    try {
        
        const  response:AxiosResponse<any> = await axios.get(`${API_ENDPOINT}/Review?PId=${PId}&userEmail=${emailUser}`)
        console.log(response.data);
        
        return response.data;

    } catch (error:any) {
        console.error(error.response);
    }

}