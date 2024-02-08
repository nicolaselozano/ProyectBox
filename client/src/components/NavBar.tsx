import Link from "next/link";

const NavBar = () => {
  console.log("aaa");
  
    return (
        <nav>
          <ul>
            <li>
              <Link href="/">
                Inicio
              </Link>
            </li>
            <li>
              <Link href="/pages/proyects">
                Proyects
              </Link>
            </li>
            {/* Agrega más enlaces según sea necesario */}
          </ul>
        </nav>
      );

}

export default NavBar;