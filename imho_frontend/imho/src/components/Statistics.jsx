import React from 'react';
import styles from '../style';

import statistics from '../assets/statistics.png';

const Statistics = () => {
  return (
    <section className={`flex flex-col sm:flex-row justify-center items-stretch md:min-h-[500px] border-black border-b-2`}>
      <div className="flex justify-center items-center 
      sm:w-1/2 bg-[#F3BC2C] p-[16px] border-black border-b-2 sm:border-b-0 sm:border-r-2">
        <img className="img-responsive w-[400px]" src={statistics} alt="statistics"/>
      </div>
      <div className={`sm:w-1/2 flex flex-col h-full px-16 py-20`}>
        <p className={`text-6xl font-[Kumar One] font-bold`}>
        80% of freshmen...</p>
        <p className={`text-justify text-2xl`}>
        ...struggle with choosing the right teacher for their courses. They often rely on asking older students for recommendations or simply choosing a teacher based on their availability. This can lead to a less-than-optimal learning experience, impacting their academic performance. IMHO aims to address this issue by providing a platform where students can leave feedback and ratings for their teachers, which can help other students make informed decisions when choosing their courses and teachers. 
        </p>
        <button href="#" className="text-white bg-black 
        px-[40px] py-[10px] w-fit self-end mt-[20px]">Sign Up Now</button>
      </div>
    </section>
  )
}

export default Statistics