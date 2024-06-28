import { HttpTransportType, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

export const ConnectNHub = () => {
    try {
        const connect = new HubConnectionBuilder()
            .withUrl("http://localhost:5019/notifications-hub", {
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
