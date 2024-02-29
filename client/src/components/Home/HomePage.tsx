import homeImg from "../../../asset/home.webp";
import homeImg_dialog from "../../../asset/home_wdialog.webp";
import homeImg_button from "../../../asset/home_pet_button.webp";
import homeImg_pet from "../../../asset/pet_compu.webp";
import style from "./HomePage.module.css";
import Carrusel from "./Carrusel";

const HomePage = () => {

    return(
        <div className={style.container__homeImg}>
            
            <div className={style.container__button}>
                <a href="/pages/AboutMe/">
                    <button>Contact Me</button>
                </a>
                <img src={homeImg_button.src} alt="Pet_button" />
            </div>
            <div className={`${style.container__dialog_text} text-violet_text`}>
                <h1>Conoce mis Proyectos</h1>
                <p>En esta web podras ver todos mis proyectos con sus detalles,  
                    tecnologias, desafios y aprendizajes que hice a travez del proceso de los mismos
                </p>
            </div>
            <div className={style.container__pet}>
                <img src={homeImg_pet.src} alt="Pet_pointing" />
            </div>
            <div className={style.container__dialog_imgDialog}>
                <img src={homeImg_dialog.src} alt="home_dialog" />
            </div>
            <div>
                <img src={homeImg.src} alt="home_image" />
            </div>

            {/* carrusel */}

            <Carrusel/>

        </div>
    )

}

export default HomePage;