import { useEffect, useState } from "react";
import { User } from "../Profile/ProfileNav";

import { API_ENDPOINT } from "../../../vars";

const CatchRedirect = (props: { code: unknown; }) => {
    let bandera = true; 
    const [user,setUser] = useState<User | null>();
   


    useEffect(() => {
        const getUser = async () => {
          try {
            if (props.code && bandera) {
                console.log(props.code);

                bandera = false;
              const response = await fetch(`${API_ENDPOINT}/user/login?code=${props.code}`,{
                method:"GET"
              });
      
              if (!response.ok) {
                console.error(`Error en la solicitud: ${response.statusText}`);
              }
      
              const data = await response.json();

              localStorage.setItem("token",data.token);
              localStorage.setItem("rtoken",data.refreshToken);
              localStorage.setItem("email",data.user.email);
              localStorage.setItem("user",JSON.stringify(data.user));

              if(user == null) setUser(data.user as User);

              console.log('Data:', data);
            }
          } catch (error) {
            console.error('Error al obtener el usuario:', error);
          }
        };
      
        getUser();
      }, [props.code]);
      
    return (
        <div>
          {user ? <h1>Te Logueaste con exito {user?.name}</h1> : <h1>Loading...</h1>}
        </div>
    )

}

export default CatchRedirect;