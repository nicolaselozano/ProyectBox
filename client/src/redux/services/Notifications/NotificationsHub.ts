import { HttpTransportType, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import { API_ENDPOINT_HUB } from "../../../../vars";


export const ConnectNHub = (token:string) => {
    try {
        
        const connect = new HubConnectionBuilder()
            .withUrl(`${API_ENDPOINT_HUB}/notifications-hub`, {
                accessTokenFactory: () => token,
                skipNegotiation: true,
                transport: HttpTransportType.WebSockets
            })
            .withAutomaticReconnect()
            .configureLogging(LogLevel.Information)
            .build();
        
        return connect;
    } catch (error) {
        throw error;
    }
}
