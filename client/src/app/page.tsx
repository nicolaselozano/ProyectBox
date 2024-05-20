"use client"
import React from 'react';
import HomePage from '@/components/Home/HomePage';
import { Footer } from 'flowbite-react';
import { useInView } from 'react-intersection-observer';

const Home = () => {

  const [ref, inView] = useInView({
    triggerOnce: false,
  });

  return (
    <div 
    ref={ref}
    className={`transition-opacity duration-5000 ${inView ? 'opacity-100' : 'opacity-0'}`}>
      <HomePage/>
    </div>
  );
};

export default Home;
