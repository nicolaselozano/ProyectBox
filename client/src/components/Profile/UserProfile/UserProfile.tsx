import { getUserData, getUserFavs, IUData, IUserLikes } from "@/Services/Profile/UserDataManagment";
import { useEffect, useState } from "react";
import style from "./UserProfile.module.css";
import UserForm from "./UserForm/UserForm";

const UserProfile = () => {
    
    const [userData,setUserData] = useState<IUData|null>(null);
    const [userLikes,setUserLikes] = useState<IUserLikes|null|undefined>(null);
    const [rol, setRol] = useState<string|null|undefined>(null);

    useEffect(() => {
        setUserData(getUserData() as IUData);

        const setProyectLiked = async () => {
            const proyectList = await getUserFavs();
            const userRol = getUserData()?.rol;
            setRol(userRol);
            setUserLikes(proyectList);
        }

        setProyectLiked();
        
    },[])

    return (
        <div className="flex flex-col justify-center items-center text-center">
            <div>
                <h1>Bienvenido {userData?.name ? userData?.name : "loading..."}</h1>
            </div>

            <div>
                <fieldset className="border rounded-lg">
                    <legend>Tus favoritos</legend>
                    {
                        userLikes?.proyects ? userLikes.proyects.map((proyect,key) => 
                            <div className={`bg-cards_bg rounded-md p-2 m-2`}key={key}>
                                <h1>{proyect?.name}</h1>
                                <h1>Rol : {proyect?.role}</h1>
                            </div>
                        ):
                        <div>
                            <h1>Loading...</h1>
                            <div className={`${style.container__loader} bg-general_bg`}></div>
                            <div className={`${style.container__loader} bg-general_bg`}></div>
                            <div className={`${style.container__loader} bg-general_bg`}></div>
                        </div>
                    }
                </fieldset>
            </div>

            <div>
                <UserForm/>
            </div>
            
        </div>
    )

}

export default UserProfile;