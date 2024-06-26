import { useState } from "react";

const NotificationsList = () => {

    
    const [actualN,setActualN] = useState<Array<any>>([]);

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