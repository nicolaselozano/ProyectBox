import { getUserData, getUserFavs, IUData, IUserLikes } from "@/Services/Profile/UserDataManagment";
import { useEffect, useState } from "react";
import UserForm from "./UserForm/UserForm";

const UserProfile = () => {
    
    const [userData,setUserData] = useState<IUData|null>(null);
    const [userLikes,setUserLikes] = useState<IUserLikes|undefined>(undefined);

    useEffect(() => {
        setUserData(getUserData() as IUData);

        const setProyectLiked = async () => {
            const proyectList = await getUserFavs();
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
                <h2>Tus favoritos</h2>
                {
                    userLikes?.proyects ? userLikes.proyects.map((proyect,key) => 
                        <div key={key}>
                            <h1>{proyect?.name}</h1>
                        </div>
                    ):
                    <div>
                        <h1>Loading...</h1>
                    </div>
                }
            </div>

            <div>
                <UserForm/>
            </div>
            
        </div>
    )

}

export default UserProfile;