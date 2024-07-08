import { useEffect, useState } from "react";
import { User } from "../Profile/ProfileNav";

import { API_ENDPOINT } from "../../../vars";
import Button_Nav from "../Button/Button_Nav";

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
      <div className="text-center">
        <div className="text-purple-600 bg-purple-100 p-4 rounded-md">
          {user ? (
            <h1 className="text-purple-900 font-bold">Te Logueaste con exito {user?.name}</h1>
          ) : (
            <h1 className="text-purple-700 font-medium">Loading...</h1>
          )}
        </div>
        {user && <Button_Nav to="/">Ir al Inicio</Button_Nav>}
      </div>
    )

}

export default CatchRedirect;