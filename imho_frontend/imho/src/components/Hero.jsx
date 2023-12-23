  import React, { useState } from 'react';
import styles from '../style';
import '../index.css';

import { Link, useNavigate } from 'react-router-dom';
import SearchProfessorsInput from './SearchProfessorsInput';
import SearchUniversitiesInput from './SearchUniversitiesInput';

import bonnet_1 from '../assets/bonnet 1.svg';
import bonnet_2 from '../assets/bonnet 2.svg';
import bonnet_3 from '../assets/bonnet 3.svg';
import bonnet_4 from '../assets/bonnet 4.svg';
import bonnet_5 from '../assets/bonnet 5.svg';

const Hero = () => {
  const navigate = useNavigate();
  const [searchUniversity, setSearchUniversity] = useState(false);

  function handleUniversitySelect(uni) {
    setSearchUniversity(false);
    navigate('/uni-review-info', {state: uni.id})
  }

  function handleProfessorSearch(searchInput) {
    navigate(`/search-professors`, {state: {searchInput: searchInput}});
  }

  return (
    <section id="hero" className={`relative flex flex-col items-center pb-32 pt-40
    bg-cover border-black border-b-2`}>
        <div className='-z-30 absolute top-0 bottom-0 right-0 left-0 border-2'>
          <img src={bonnet_1} alt='bonnet 1' className='absolute top-8 left-48 w-48'/>
          <img src={bonnet_2} alt='bonnet 1' className='absolute top-56 left-20 w-36'/>
          <img src={bonnet_3} alt='bonnet 1' className='absolute bottom-24 left-52 w-32'/>
          <img src={bonnet_5} alt='bonnet 1' className='absolute top-52 right-16 w-44'/>
          <img src={bonnet_4} alt='bonnet 1' className='absolute top-7 right-56 w-32'/>
          <img src={bonnet_2} alt='bonnet 1' className='absolute bottom-24 right-56 w-36'/>
        </div>
        <p id="hero-title-main" className={`text-[24px] md:text-[48px] mb-[24px] mt-[-30px]`}>
          RATE YOUR PROFESSORS</p>
        {searchUniversity ? 
       <p className='text-[30px]'>Find a <span className='font-bold'>university</span></p>
       :
        <p className='text-[30px]'>Find a <span className='font-bold'>professor</span></p>
        }

        <div className='w-[312px] md:w-[700px] my-8'>
          {searchUniversity ?
          <SearchUniversitiesInput onSelect={handleUniversitySelect}/>
          :
          <SearchProfessorsInput onSearch={handleProfessorSearch}/>
          }
        </div>

        {searchUniversity ?
        <p onClick={() => setSearchUniversity(false)}
        className='text-[30px] md:text-[30px] hover:underline cursor-pointer'>I'd like to look up a professor by name</p>
        :
        <p onClick={() => setSearchUniversity(true)}
        className='text-[30px] md:text-[30px] hover:underline cursor-pointer'>I want to find a university</p>
        }
    </section>
  )
}

export default Hero