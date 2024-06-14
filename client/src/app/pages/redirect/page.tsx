"use client"
import CatchRedirect from "@/components/Login/CatchRedirect";
import RegisterCatchRedirect from "@/components/Login/Register/RegisterCatchRedirect";
import { useSearchParams } from "next/navigation";
import { useEffect, useState } from "react";

const RedirectLogin = () => {

    const [tokenExist,setTokenExist] = useState(0);
    const code = useSearchParams().get("code");
    const signin = useSearchParams().get("signin");
    useEffect(() => {
        
        if(!signin)
        {            
            setTokenExist(1);
        }else{
            setTokenExist(2);
        }
    },[signin])

    return(
        <div>
            {
                tokenExist == 1 ? <div>
                    <CatchRedirect code={code}/>
                </div> : (
                    tokenExist == 2 ?                 
                    <div>
                        <RegisterCatchRedirect code={code}/>
                    </div> :
                    null
                )

            }

        </div>
    )

}

export default RedirectLogin;