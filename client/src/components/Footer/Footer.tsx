import Link from "next/link";
import imgLogo from "../../../asset/OIG4.webp";
import style from "./Footer.module.css";
import Image from "next/image";

const Footer = () =>{

    return (
        <footer className={`${style.container} bg-gradient-to-b from-cards_bg to-transparent`}>
            <div className={style.container__imgLogo}>
                <Link href="/">
                    <Image src={imgLogo.src} alt="Logo" />
                </Link>
            </div>

            <div>
                <fieldset className={style.container__form}>
                    <legend>Mis contactos</legend>
                    <ul>
                        <li>Email : nicoeloza12@gmail.com</li>
                        <li>
                            <Link href="https://www.linkedin.com/in/nicoelozano/" target="_blank">Linkedin</Link>
                        </li>
                        <li>
                            <Link href="https://github.com/nicolaselozano" target="_blank">Github</Link>
                        </li>
                    </ul>
                </fieldset>
            </div>

            <div>
                <button>Gracias por el espacio</button>
            </div>
        </footer>
    )

}

export default Footer;