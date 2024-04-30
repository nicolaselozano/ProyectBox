"use client"
import CatchRedirect from "@/components/Login/CatchRedirect";
import { useSearchParams } from "next/navigation";

const RedirectLogin = () => {

    const code = useSearchParams().get("code");

    return(
        <div>
            <CatchRedirect code={code}/>
        </div>
    )

}

export default RedirectLogin;