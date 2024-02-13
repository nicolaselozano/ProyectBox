import style from "./NavBar.module.css";
import DropMenu from "./DropMenu/DropMenu";
import NavOptions from "./NavOptions";

const NavBar = () => {
  return (
    <nav className={style.container}>
      <div className={style.hide_mobile}>
        <NavOptions/>
      </div>
      <DropMenu/>
    </nav>
  );
}

export default NavBar;
