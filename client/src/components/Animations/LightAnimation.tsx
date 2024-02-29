"use client"
import React, { useState, useEffect } from 'react';
import styles from "./LightAnimation.module.css";

const LightAnimation = () => {
  const [isLightsOn, setIsLightsOn] = useState(false);

  useEffect(() => {
    const intervalId = setInterval(() => {
      setIsLightsOn((prev) => !prev);
    }, 1000);

    return () => clearInterval(intervalId);
  }, []);

  return (
    <div className={styles.lightcontainer}>
      <div className={styles.light} />
      <div className={styles.light} style={{ left: 'unset', right: 0 }} />
    </div>
  );
};

export default LightAnimation;
