import auth0 from "auth0-js";
import {
  DOMAIN,
  CLIENT_ID,
  REDIRECT_URI,
} from "../../../vars";

const LogOutButton = () => {
  const handleLogOut = () => {
    localStorage.clear();
    const webAuth = new auth0.WebAuth({
      domain: DOMAIN,
      clientID: CLIENT_ID,
    });
  
    webAuth.logout({
      returnTo: REDIRECT_URI,
      clientID: CLIENT_ID,
    });
};
  return(
    <button className="bg- hover:bg-general_bg active:bg-general_bg text-white font-bold py-2 px-4 rounded mt-2"
    onClick={handleLogOut}
    >LogOut</button>
  )

}

export default LogOutButton;