"use client"
import { GetHour, getDay } from "@/Services/TimeZone/GetHour";
import { useEffect, useState } from "react";
import pfpImage from "../../../../asset/pfp1.webp";
import style from "./MyProfile.module.css";
import imgPet from "../../../../asset/face_Pet.webp";
import { AppDispatch, useAppSelector } from "@/redux/store";
import { useDispatch } from "react-redux";
import { getAllProducts } from "@/redux/services/getAllProducts";
import Item from "@/components/Proyects/Item/Item";
import ImagesProyect from "./Images/ImagesProyect";
import { useInView } from "react-intersection-observer";
import { Product } from "@/components/Proyects/AllItems/AllItems";

interface IProject {
    id: string;
    name: string;
    url: string;
    image: string;
    role: string;
    description: string;
    usersID: string[];
    imgs: IImage[];
    isDeleted: boolean;
}

interface IImage {
    id: string;
    proyectId: string;
    url: string;
}
  

const MyProfile = () => {

    
    const [currentTime,setCurrentTime] = useState("");
    const [currentDay,setCurrentDay] = useState("");

    const {allProduct,error} = useAppSelector((state) => state.productReducer);
    const dispatch = useDispatch<AppDispatch>();

    const [ref, inView] = useInView({
        triggerOnce: false,
    });
    
    const [welcomingRef, welcomingInView] = useInView({
    triggerOnce: false,
    });

    const [projectsRef, projectsInView] = useInView({
    triggerOnce: false,
    });

    const [toolsRef, toolsInView] = useInView({
    triggerOnce: false,
    });
    
    const [aboutMeRef, aboutMeInView] = useInView({
    triggerOnce: false,
    });

    useEffect(() => {

        setCurrentTime(GetHour);
        setCurrentDay(getDay);
        dispatch(getAllProducts);
        

    },[dispatch,currentTime,currentDay]);
    
    return (

        <fieldset 
        ref={ref}
        className={`border-4 border-cards_border p-4 transition-opacity duration-1000 ${inView ? 'opacity-100' : 'opacity-0'}`}>
            <legend className="text-4xl font-black">Sobre Mi</legend>

            <div className={`${style.container}`}>

                <div 
                ref={welcomingRef}
                className={`mb-24 ${style.container__welcoming} transition-opacity duration-1000 ${welcomingInView ? 'opacity-100' : 'opacity-0'}`}>
                    <div className="flex-col m-32">
                        <h1  className={`${style.container__welcoming_txt}`}>
                            {currentTime ? currentTime : "Buenas"} 
                        </h1>
                        <h1 className={`${style.container__welcoming_name}`}>Soy Nicolas Lozano</h1>
                        <h1 className={`${style.container__welcoming_txt}`}>Espero que estes teniendo un lindo {currentDay ? currentDay : "dia"} 
                        </h1>

                        <div className={style.container__welcoming_pet}>
                            <img src={imgPet.src} alt="" />
                        </div>
                    </div>
                </div>

                {/* Lista de proyectos */}
                <div 
                ref={projectsRef}
                className={`mb-36 transition-opacity duration-1000 ${projectsInView ? 'opacity-100' : 'opacity-0'}`}>

                    <h1 className="text-center font-semibold text-4xl text-violet_text">Algunos Proyectos personales y otros en los que he participado</h1>

                    <div className="m-5">
                        {allProduct.length ? 
                            allProduct.slice(0, Math.min(3,allProduct.length)).map((proyect:IProject,key) => 
                            <a href={proyect.url} className="" target="_blank" key={key}>
                                <div className={`m-5 bg-cards_bg border border-solid border-profile_border rounded-md`}>
                                    <div className="flex flex-col justify-around">
                                        <Item proyect={proyect as Product} />
                                        <ImagesProyect imgs={proyect.imgs}/>
                                    </div>
                                    <div className="m-4">
                                        <h2>Descripcion</h2>
                                        <p className="whitespace-pre-line">{proyect.description}</p>
                                    </div>
                                </div>
                            </a>
                        ) : <span>Loading...</span>
                        }
                    </div>

                </div>

                <div 
                ref={toolsRef}
                className={`transition-opacity duration-1000 ${toolsInView ? 'opacity-100' : 'opacity-0'}`}>
                    <p className="font-semibold text-4xl">
                        Mis herramientas son: 
                    </p>
                    
                    <div className={`${style.container__welcoming_img}`}>
                        <img src="https://img.shields.io/badge/TypeScript-007ACC?style=for-the-badge&logo=typescript&logoColor=white" alt="TypeScript" />
                        <img src="https://img.shields.io/badge/Java-007396?style=for-the-badge&logo=java&logoColor=white" alt="Java" />
                        <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
                        <img src="https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black" alt="JavaScript" />
                        <img src="https://img.shields.io/badge/HTML-E34F26?style=for-the-badge&logo=html5&logoColor=white" alt="HTML" />
                        <img src="https://img.shields.io/badge/CSS-1572B6?style=for-the-badge&logo=css3&logoColor=white" alt="CSS" />
                        <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white" alt=".NET" />
                        <img src="https://img.shields.io/badge/Sequelize-52B0E7?style=for-the-badge&logo=sequelize&logoColor=white" alt="Sequelize" />
                        <img src="https://img.shields.io/badge/Auth0-EB5424?style=for-the-badge&logo=auth0&logoColor=white" alt="Auth0" />
                        <img src="https://img.shields.io/badge/React-61DAFB?style=for-the-badge&logo=react&logoColor=black" alt="React" />
                        <img src="https://img.shields.io/badge/Next.js-000000?style=for-the-badge&logo=next.js&logoColor=white" alt="Next.js" />
                        <img src="https://img.shields.io/badge/SQL-4479A1?style=for-the-badge&logo=sql&logoColor=white" alt="SQL" />
                        <img src="https://img.shields.io/badge/Postgres-336791?style=for-the-badge&logo=postgresql&logoColor=white" alt="Postgres" />
                        <img src="https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white" alt="Postman" />
                        <img src="https://img.shields.io/badge/Spring-6DB33F?style=for-the-badge&logo=spring&logoColor=white" alt="Spring" />
                        <img src="https://img.shields.io/badge/Hibernate-59666C?style=for-the-badge&logo=hibernate&logoColor=white" alt="Hibernate" />
                    </div>

                </div>

                <div 
                ref={aboutMeRef}
                className={`text-center font-semibold transition-opacity duration-5000 ${style.container__welcoming_aboutMe} ${aboutMeInView ? 'opacity-100' : 'opacity-0'}`}>
                    <span className={`${style.container__welcoming_intro}`}> 
                        Me encanta enfrentar y resolver desafíos en el área de 
                        programación, y mi compromiso con la actualización constante
                        me lleva a explorar las últimas tecnologías. 
                        
                    </span>
                    <div className={`${style.container__welcoming_aboutMe_pfpContainer}`}>
                        <img className={`${style.container__welcoming_aboutMe_pfpImage}`} src={pfpImage.src} alt="Descripción de la imagen" />
                    </div>

                    
                    <p> Estudie en la UTN la Tecnicatura Universitaria en Programación, con un enfoque sólido en API REST, Java y Hibernate. Luego decidí mejorar mis habilidades tecnológicas y me sumergí en un bootcamp intensivo llamado Henry, dónde me especialice en back-end NodeJs,Express y con herramientas de front como React, Redux, tambien aprendi y familiarice con .NET 8, C# y NextJS, TypeScript, logrando hacer un proyecto web funcional pensado para mostrar tus logros y proyectos (este Portafolio).</p>
                </div>

            </div>

        </fieldset>

    )

}

export default MyProfile;