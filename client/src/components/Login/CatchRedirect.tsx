import { useEffect } from "react";

const CatchRedirect = (props) => {
    let bandera = true;
    useEffect(() => {
        const getUser = async () => {
          try {
            if (props.code && bandera) {
                console.log(props.code);

                bandera = false;
                
              const response = await fetch(`http://localhost:5019/api/user?code=${props.code}`,{
                method:"POST",
                body:JSON.stringify({
                  "Name": "Juan",
                  "Email": "Juan@gmail.com",
                  "Password": "321"
                })
              });
      
              if (!response.ok) {
                throw new Error(`Error en la solicitud: ${response.statusText}`);
              }
      
              const data = await response.json();
              console.log('Data:', data);
            }
          } catch (error) {
            console.error('Error al obtener el usuario:', error);
            // Maneja el error según tus necesidades
          }
        };
      
        getUser();
      }, [props.code]);
      
    return (
        <div></div>
    )

}

export default CatchRedirect;