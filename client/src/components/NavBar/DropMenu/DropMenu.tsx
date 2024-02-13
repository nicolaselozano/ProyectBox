"use client"
import { useState } from "react";
import style from "./DropMenu.module.css";
import NavOptions from "../NavOptions";

const DropMenu = () => {

    const [toggle,setTogle] = useState(false);
    
    const handleDropMenu = () => {
        setTogle(!toggle);
    }

    const handleMouseEnter = () => {
        setTogle(true);
    }

    const handleMouseLeave = () => {
        setTogle(false);
    }
    return (
        <div className={style.container}>
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
                onMouseLeave={handleMouseLeave}
                >
                <NavOptions/>
                </div> :
                null
            }

        </div>

    )

}

export default DropMenu;