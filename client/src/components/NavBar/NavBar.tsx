import style from "./NavBar.module.css";
import DropMenu from "./DropMenu/DropMenu";
import imgLogo from "../../../asset/OIG4.webp";

const NavBar = () => {
  return (
    <nav className={`${style.container} bg-gradient-to-b from-cards_bg to-transparent`}>
      <img className="h-16" src={imgLogo.src} alt="Logo My Proyects" />
      <div className={style.container__dropMenu}>
        <DropMenu/>
      </div>
    </nav>
  );
}

export default NavBar;
