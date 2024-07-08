"use client"
import style from "./NavBar.module.css";
import DropMenu from "./DropMenu/DropMenu";
import imgLogo from "../../../asset/OIG4.webp";
import ProfileNav from "../Profile/ProfileNav";
import { useEffect, useState } from "react";
import { ConnectNHub } from "@/redux/services/Notifications/NotificationsHub";
import { HubConnection } from "@microsoft/signalr";
import { useDispatch } from "react-redux";
import { AppDispatch } from "@/redux/store";
import { AddNotifications, ResetNotifications } from "@/redux/services/Notifications/ThunkNotifications";
import { usePathname } from "next/navigation";


const NavBar = () => {

  const [connection, setConnection] = useState<HubConnection | null>(null);
  const dispatch = useDispatch<AppDispatch>();

  const pathname = usePathname();

  useEffect(() => {
    const token = localStorage.getItem("token");
    const connect = ConnectNHub(token);
    setConnection(connect);
    connect
    .start()
    .then(() => {
      connect.on("ReceiveMessage", (sender, content, sentTime) => {
        
        if(`${sender}`.includes(`logueado`)!){
          console.log(`${sender}`);    
          dispatch(AddNotifications(sender));
        }

        if(`${sender}`.includes(`likeado`)!){
          console.log(`${sender}`);    
          dispatch(AddNotifications(sender));
        }
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
      dispatch(ResetNotifications)
    };

  },[dispatch, pathname == "/"]);


  return (
    <nav className={`${style.container} bg-gradient-to-b from-cards_bg to-transparent`}>
      <div className={`${style.container_profile}`}>
        <ProfileNav/>
      </div>

      <img className="h-16" src={imgLogo.src} alt="Logo My Proyects" />
      <div className={style.container__dropMenu}>
        <DropMenu/>
      </div>
    </nav>
  );
}

export default NavBar;
