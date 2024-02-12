import Button_Nav from "./Button/Button_Nav";

const NavBar = () => {
  
    return (
        <nav>
          <ul>
            <li>
              <Button_Nav to="/">
                Inicio
              </Button_Nav>
            </li>
            <li>
              <Button_Nav to="/pages/proyects" >
                Proyecto
              </Button_Nav>
            </li>
            {/* Agrega más enlaces según sea necesario */}
          </ul>
        </nav>
      );

}

export default NavBar;