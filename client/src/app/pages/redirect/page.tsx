"use client"
import CatchRedirect from "@/components/Login/CatchRedirect";
import RegisterCatchRedirect from "@/components/Login/Register/RegisterCatchRedirect";
import { useSearchParams } from "next/navigation";
import { Suspense, useEffect, useState } from "react";

const RedirectLoginPage = () => {

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

export default function RedirectLogin() {
    return (
      <Suspense fallback={<div>Loading...</div>}>
        <RedirectLoginPage />
      </Suspense>
    );
  }