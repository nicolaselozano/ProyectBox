import Button_Nav from "../Button/Button_Nav";

const NavOptions = () => {

    return (
        <div>
            <ul className="flex justify-around">
                <li className=" m-2">
                <Button_Nav to="/">
                    Inicio
                </Button_Nav>
                </li>
                <li className=" m-2">
                <Button_Nav to="/pages/proyects" >
                    Proyectos
                </Button_Nav>
                </li>
                {/* Agrega más enlaces según sea necesario */}
            </ul>
        </div>
    )

}

export default NavOptions;