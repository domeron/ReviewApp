import React, { useContext, useEffect, useState } from 'react'

import styles from '../style';
import { UserContext } from '../App';
import { api_getFacultiesInUniversity } from '../api/FacultyApi';


function Account({setActiveTab}) {
  const {user, setUser} = useContext(UserContext);
  const [faculties, setFaculties] = useState([]);

  useEffect(() => {
    api_getFacultiesInUniversity(1)
      .then(responseData => {
        setFaculties(responseData)
        console.log(responseData)
        console.log(responseData.find((fac) => fac.facultyId == user.facultyId).facultyName)
      })
  }, [])

  return (
      <div className="mt-[10px] m-auto max-w-[600px] py-8">
          <div className="flex flex-col mt-[20px]">
            <p className="border-black border-b-2 mb-[10px] text-xl font-semibold py-1">{user.firstName}</p>
            <p className="border-black border-b-2 mb-[10px] text-xl font-semibold py-1">{user.lastName}</p>
            <p className="border-black border-b-2 mb-[10px] text-xl font-semibold py-1">{user.year}</p>
            {faculties.length > 0 &&
            <p className="border-black border-b-2 mb-[10px] text-xl font-semibold py-1">{faculties.find((fac) => fac.facultyId == user.facultyId).facultyName}</p>
            }

            <button className="w-full sm:w-[200px] mt-[30px] text-white mx-1 bg-black px-[30px] py-[10px]"
            onClick={() => setActiveTab(4)}>
            Edit</button>
          </div>
      </div>
  )
}

export default Account;