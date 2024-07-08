import { useState } from "react";
import style from "./NotificationNav.module.css";
import NotificationsList from "./ListNotifications";
import { useDispatch } from "react-redux";
import { AppDispatch } from "@/redux/store";
import { setShowIcon } from "@/redux/slices/Notifications";

const NotificationNav = () => {

    const [toggle,setTogle] = useState(false);
    const dispatch = useDispatch<AppDispatch>();
    
    const handleDropMenu = () => {
        dispatch(setShowIcon(false))
        setTogle(!toggle);
    }

    const handleMouseLeave = () => {
        setTogle(false);
    }

    return (
    <div className={style.container}>
        <button 
        className={`bg- hover:bg-general_bg active:bg-general_bg 
        text-white font-bold py-2 px-4 rounded mt-2`}
        onClick={handleDropMenu}>Notificaciones</button>
                {/* togled Menu */}
                {
                    toggle ? 
                    <div
                    className={style.modalContainer}
                    onMouseLeave={handleMouseLeave}
                    >
                    <NotificationsList/>
                    </div> :
                    null
                }
    </div>
    
    )

}

export default NotificationNav;