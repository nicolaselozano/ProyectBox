import { ResetNotifications } from "@/redux/services/Notifications/ThunkNotifications";
import { AppDispatch, useAppSelector } from "@/redux/store";
import { useEffect, useState } from "react";
import { useDispatch } from "react-redux";

const NotificationsList = () => {

    const [actualN,setActualN] = useState<Array<any>>([]);
    const {actualNotifications,error} = useAppSelector(state => state.notificationsReducer);
    const dispatch = useDispatch<AppDispatch>();

    useEffect(() => {
      setActualN(actualNotifications);  

    },[dispatch]);

    return (
        <div className="bg-cards_bg p-4 rounded-lg shadow-md">
            <ul className="space-y-2">
            {actualN.length ? (
                actualN.map((data, key) => (
                <li key={key} className="bg-general_bg text-white p-3 rounded-md shadow-sm hover:bg-purple-800">
                    {data}
                </li>
                ))
            ) : (
                <li className="bg-general_bg text-white p-3 rounded-md shadow-sm">No hay notificaciones</li>
            )}
            </ul>
        </div>
    )

}

export default NotificationsList;