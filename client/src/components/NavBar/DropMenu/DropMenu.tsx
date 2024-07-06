"use client"
import { useEffect, useState } from "react";
import style from "./DropMenu.module.css";
import NavOptions from "../NavOptions";
import { AppDispatch, useAppSelector } from "@/redux/store";
import { useDispatch } from "react-redux";
import { setShowIcon } from "@/redux/slices/Notifications";

const DropMenu = () => {

    const [toggle,setTogle] = useState(false);
    const [actualN,setActualN] = useState<Array<any>>([]);
    const {actualNotifications,showIcon,error} = useAppSelector(state => state.notificationsReducer);

    const dispatch = useDispatch<AppDispatch>();

    const handleDropMenu = () => {
        setTogle(!toggle);
    }

    const handleMouseEnter = () => {
        setTogle(true);
    }

    const handleMouseLeave = () => {
        setTogle(false);
    }

    useEffect(() => {
        if (actualNotifications.length !== actualN.length) {
          dispatch(setShowIcon(true));
        }
        setActualN(actualNotifications);
    }, [actualNotifications]);

    return (
        <div className={style.container}>

            <div className={style.options_sreen}>
                <NavOptions/>
            </div>

            <div className={style.menu_button} 
            onClick={handleDropMenu} 
            onMouseEnter={handleMouseEnter}
            >
                <span></span>
            </div>

            {/* togled Menu */}

            {
                toggle ? 
                <div
                className={style.modalContainer}
                onMouseLeave={handleMouseLeave}
                >
                {showIcon && (
                    <div className="absolute top-0 right-0 mt-40 bg-purple-600 text-white rounded-full p-1">
                    !
                    </div>
                )}
                <NavOptions/>
                </div> :
                null
            }

        </div>

    )

}

export default DropMenu;