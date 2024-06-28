"use client"
import { ConnectNHub } from "@/redux/services/Notifications/NotificationsHub";
import { HubConnection } from "@microsoft/signalr";
import { useEffect, useState } from "react";

const NotificationsList = () => {

    
    const [actualN,setActualN] = useState<Array<any>>([]);
    const [connection, setConnection] = useState<HubConnection | null>(null);

    useEffect(() => {

        const connect = ConnectNHub();
      setConnection(connect);
      connect
      .start()
      .then(() => {
        connect.on("ReceiveMessage", (sender, content, sentTime) => {
            setActualN((prev) => [...prev, content]);      
            console.log(sender);
                  
        });
      })
      .catch((err) =>
        console.error("Error while connecting to SignalR Hub:", err)
      );

      return () => {
        if (connection) {
          connection.stop();
          connection.off("ReceiveMessage");
        }
      };

    },[])

    return (
        <div>
            <ul>
                { actualN.length ? actualN.map((data,key) => 

                <li key={key}>{data}</li>

                ):<li>Notificacion Ejemplo</li>}
            </ul>
        </div>
    )

}

export default NotificationsList;