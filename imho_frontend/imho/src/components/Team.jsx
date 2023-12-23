import React from 'react';
import styles from '../style';

import empty_circle from '../assets/empty_circle.png';
import darish_img from '../assets/daerish.png'
import rakhat_img from '../assets/rakhat.png'
import aizharkyn_img from '../assets/aizharkyn.png'
import yerkenaz_img from '../assets/yerke.png'
import karina_img from '../assets/karina.png'

const TeamMember = ({name, img}) => {
  return (
    <div className={`flex flex-col items-center w-[150px] mx-[20px]`}>
      <img src={img} className="aspect-square" />
      <p className="w-[100px] text-white font-medium text-center mt-[10px] text-xl">{name}</p>
    </div>
  )
}

const Team = () => { 
  return (
    <section className={`py-16 border-black border-b-2 bg-[#1D1D1D]`}>
      <p className={`text-center text-white text-[24px] sm:text-[48px] font-[KumarOne]
      mb-[20px]`}>About us</p>
      <p  className="max-w-5xl text-white text-center mt-[50px] mx-auto mb-[60px] text-2xl">
        Our team, consisting of senior students, developed IMHO as our diploma project. We hope that one day, IMHO will become a real working platform to help students choose the best teachers for their courses and help teachers improve their teaching effectiveness.</p>
      <div className="flex flex-wrap gap-[24px] justify-center items-center">
        <TeamMember name="Aizharkyn Alipova" img={aizharkyn_img}/>
        <TeamMember name="Yerkenaz Yershege" img={yerkenaz_img}/>
        <TeamMember name="Darish Daudekenkyzy" img={darish_img}/>
        <TeamMember name="Rakhat Shalbuidakov" img={rakhat_img}/>
        <TeamMember name="Karina Kinazarova" img={karina_img}/>
      </div>
    </section>
  )
}

export default Team 