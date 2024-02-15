import style from "./NavBar.module.css";
import DropMenu from "./DropMenu/DropMenu";
import imgLogo from "../../../asset/OIG4.webp";

const NavBar = () => {
  return (
    <nav className={style.container}>
      <img className="h-16" src={imgLogo.src} alt="Logo My Proyects" />
      <DropMenu/>
    </nav>
  );
}

export default NavBar;
