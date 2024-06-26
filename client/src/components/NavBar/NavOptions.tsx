import { useEffect, useState } from "react";
import Button_Nav from "../Button/Button_Nav";
import LoginButton from "../Login/LoginButton";
import RegisterButton from "../Login/Register/RegisterButton";
import style from "./NavOptions.module.css";
import LogOutButton from "../Login/LogOutButton";
import { usePathname } from "next/navigation";
import NotificationNav from "./Notifications/NotificationNav";

const NavOptions = () => {

  const [isLoged,setIsLoged] = useState<boolean>(false);
  const location = usePathname();
  useEffect(() => {

    if(localStorage.getItem("email")) setIsLoged(true); 

  },[location]);

  return (
    <div>
      <ul className={`flex ${style.list__button}`}>
        <li className={`${style.container__button}`}>
          <Button_Nav to="/">Inicio</Button_Nav>
        </li>
        <li>
          <Button_Nav to="/pages/proyects">Proyectos</Button_Nav>
        </li>
        {
          !isLoged ?
          <>
            <li>
              <LoginButton/>
            </li>
            <li>
              <RegisterButton/>
            </li>
          </> 

          :
          <>
            <li>
              <LogOutButton/>
            </li>
            <li>
              <NotificationNav/>
            </li>
          </>
        }
      </ul>
    </div>
  );
};

export default NavOptions;

