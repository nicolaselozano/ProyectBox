import { HttpTransportType, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import signalR from "@microsoft/signalr";

export const ConnectNHub = (token:string) => {
    try {
        const connect = new HubConnectionBuilder()
            .withUrl("http://localhost:5019/notifications-hub", {
                accessTokenFactory: () => "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IkJDYWlmYTVLc0lxV09aWVVnLWxzSCJ9.eyJjdXN0b21fbmFtZV9jbGFpbSI6Ik5pY29sYXMgTG96YW5vIiwiY3VzdG9tX3BpY3R1cmVfY2xhaW0iOiJodHRwczovL2xoMy5nb29nbGV1c2VyY29udGVudC5jb20vYS9BQ2c4b2NKZnoyR005WmlScXktLUk5U05zX3VseUpvYmN1ejNwaXI0ek56cE52Z2FSbTNtekZoVD1zOTYtYyIsImN1c3RvbV9lbWFpbF9jbGFpbSI6Im5pY29lbG96YTEyQGdtYWlsLmNvbSIsImlzcyI6Imh0dHBzOi8vZGV2LXYycm95Z2FsbXk2cXlpeDIudXMuYXV0aDAuY29tLyIsInN1YiI6Imdvb2dsZS1vYXV0aDJ8MTAzNjE0NDU3NTIxMDY1ODIyMDg1IiwiYXVkIjoiaHR0cHM6Ly9QT1JUQUZPTElPX0FQSS5jb20iLCJpYXQiOjE3MjA0NTY5MzMsImV4cCI6MTcyMDU0MzMzMywic2NvcGUiOiJvZmZsaW5lX2FjY2VzcyIsImF6cCI6IkZpR2dGWnFCTlJUWE10cm9ObFJ4ZXJyUzlGRXdXY2E4IiwicGVybWlzc2lvbnMiOlsidXNlcjp1c2VyIl19.Um2uE8QEvp5G_-bccMVys57gAosp0M7KYtbuobjsEhv3zDg9A52nzLF_Z488G983fk2X5nfqr0rPSYlRz2vI0GJ5EDJuVUfR0X8cVljEkEGPwNaNsJVt0ObYHbOp7cQB5bA_zWMY5VEVwIX25zm7-fnIicTGX9DX_RpdpPcczOkTSZxfJEPxFW9EV7GPnBDclvBv08IC3IGtGeEC7IcXHt481Y6I5dkjpxz1eo5Zq5z2VNV_VPnEosnRvzg9dtdVwhn3Z8cDHpBY46x5ktvQMNY1sagqJy8x5TrdwfOMN3H6IH7ILossNIWFXGE2xSKO_FiLjUe9Y9G6il_djX3hMw",
                skipNegotiation:false,
                transport: HttpTransportType.WebSockets,

            })
            .withAutomaticReconnect()
            .configureLogging(LogLevel.Information)
            .build();
        
        return connect;
    } catch (error) {
        throw error;
    }
}
