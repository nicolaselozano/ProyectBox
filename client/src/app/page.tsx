import React from 'react';
import style from './page.module.css';
import homeImg from "../../asset/home.webp";

const Home = () => {
  return (
    <div className={style.container}>
        <img src={homeImg.src} alt="home image" />
    </div>
  );
};

export default Home;
