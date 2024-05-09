import axios, { AxiosResponse } from "axios"
import { API_ENDPOINT } from "../../../../vars"

export const MvotedProyect = async () => {
    try {
        
        const response:AxiosResponse = await axios.get(`${API_ENDPOINT}/Review/mostv`);
        
        return response.data;

    } catch (error) {
        return error;
    }
}