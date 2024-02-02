import React  from "react";
import Link from "next/link";

const Home : React.FC = () =>{

    return(
        <div>
            <h1>Bienvenido al home</h1>
            <Link href="/proyects/allProyects">Proyects</Link>
        </div>
    )

}

export default Home;