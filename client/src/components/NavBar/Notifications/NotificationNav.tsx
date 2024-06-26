import { useEffect, useState } from "react";
import style from "./NotificationNav.module.css";
import NavOptions from "../NavOptions";
import NotificationsList from "./ListNotifications";

const NotificationNav = () => {

    const [toggle,setTogle] = useState(false);
    
    const handleDropMenu = () => {
        setTogle(!toggle);
    }

    const handleMouseLeave = () => {
        setTogle(false);
    }

    useEffect(() => {

    },[]);

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