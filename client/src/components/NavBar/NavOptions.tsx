import Button_Nav from "../Button/Button_Nav";
import style from "./NavOptions.module.css";

const NavOptions = () => {
  return (
    <div>
      <ul className={`flex ${style.list__button}`}>
        <li className={`${style.container__button}`}>
          <Button_Nav to="/">Inicio</Button_Nav>
        </li>
        <li>
          <Button_Nav to="/pages/proyects">Proyectos</Button_Nav>
        </li>
        {/* Agrega más enlaces según sea necesario */}
      </ul>
    </div>
  );
};

export default NavOptions;

