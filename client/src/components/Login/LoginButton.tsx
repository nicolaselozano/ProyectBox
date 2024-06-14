import auth0 from "auth0-js";

import {
    DOMAIN,
    AUDIENCE,
    SCOPE,
    CLIENT_ID,
    RESPONSE_TYPE,
    REDIRECT_URI,
  } from "../../../vars";

const LoginButton = () => {

    
    const handleClick = async () =>{
        localStorage.clear();
        const webAuth = new auth0.WebAuth({
            domain:`${DOMAIN}`,
            clientID:`${CLIENT_ID}`
        })

        let url = webAuth.client.buildAuthorizeUrl({
            clientID: `${CLIENT_ID}`,
            responseType: `${RESPONSE_TYPE}`,
            redirectUri: `${REDIRECT_URI}/pages/redirect`,
            scope: `${SCOPE}`,
            audience: `${AUDIENCE}`,
          });

        window.location.replace(url);

    }

    return (
        <button className="bg- hover:bg-general_bg active:bg-general_bg text-white font-bold py-2 px-4 rounded mt-2"
        onClick={handleClick}
        >Login</button>
    )

}

export default LoginButton;