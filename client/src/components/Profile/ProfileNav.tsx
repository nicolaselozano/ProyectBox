"use client"
import { UUID } from "crypto";
import { usePathname } from "next/navigation";
import { useEffect, useState } from "react";

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
            {user ? <h1>Bienvenido {user?.name}</h1> : null}
        </div>
    )

}

export default ProfileNav;