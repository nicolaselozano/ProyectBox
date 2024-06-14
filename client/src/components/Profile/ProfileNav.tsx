"use client"
import { UUID } from "crypto";
import { usePathname } from "next/navigation";
import { useEffect, useState } from "react";
import Button_Nav from "../Button/Button_Nav";

export interface User {
    email:string
    id:UUID
    isDeleted:boolean
    name:string
    password:string
}

const ProfileNav = () => {

    const [user,setUser] = useState<User | null>();
    const location = usePathname();


    useEffect(() => {

        const localUser =  localStorage.getItem("user");

        if(user == null && localUser) setUser(JSON.parse(localUser) as User);        

    },[user ? null :location])

    return (
        <div>
            {user ? 
                <div className="flex-col items-center justify-center ml-5">
                    <h1>Bienvenido {user?.name}</h1> 
                    <div className="ml-3 -mt-3">
                        <Button_Nav to="/pages/Profile">Perfil</Button_Nav>
                    </div>
                </div>: null}
        </div>
    )

}

export default ProfileNav;