import React, {useContext, useEffect, useState} from 'react'

import styles from '../style';
import { UserContext } from '../App';
import { useForm } from "react-hook-form";
import { api_getFacultiesInUniversity } from '../api/FacultyApi';
import { api_UpdateUser } from '../api/UserApi';

const Settings = () => {
  const {user, setUser} = useContext(UserContext);
  const { register, watch,setError, setValue, handleSubmit, formState: { errors } } = useForm();
  const [faculties, setFaculties] = useState([]);
  const watchCourse = watch('course')
  const [passwordHidden, setPasswordHidden] = useState(true)

  useEffect(() => {
    if(user !== null) {
      console.log(user)
      setValue('userId', user.id);
      setValue('email', user.email);
      setValue('firstName', user.firstName);
      setValue('lastName', user.lastName);
      setValue('course', user.year);
      setValue('password', user.password);
      setValue('facultyId', user.facultyId)

      api_getFacultiesInUniversity(1)
      .then(responseData => {
        setFaculties(responseData)
        console.log(responseData)
      })
    }
  }, [user])

  async function handleEditSubmit(data) {
    console.log(data);
    setValue('course', parseInt(watchCourse))
    await api_UpdateUser(data)
    .then((dataResponse) => {
      console.log(dataResponse)
      setUser(dataResponse)
    })
    .catch(err => console.log(err))

  }

  return (
      <div className="mt-[10px] m-auto max-w-[600px] py-8">
          <form onSubmit={handleSubmit(handleEditSubmit)}
          className="flex flex-col sm:flex-row">
            <div className='flex flex-col w-full sm:w-[60%]'>
              <label className="mb-[2px]">Email</label>
              <input className="w-full border-[1px] border-primary border-solid mb-[5px] px-[15px] py-[5px]" 
              {...register('email')} type="email"/>
              {/* <input className="w-[60%] border-[1px] border-primary border-solid mb-[5px] px-[15px] py-[5px]" type="email" defaultValue={user.email}/> */}

              <label className="mb-[2px]">First Name</label>
              <input className="w-full border-[1px] border-primary border-solid mb-[5px] px-[15px] py-[5px]" 
              {...register('firstName')} type="name"/>
              {/* <input className="w-[60%] border-[1px] border-primary border-solid mb-[5px] px-[15px] py-[5px]" type="name" defaultValue={user.firstName}/> */}

              <label className="mb-[2px]">Last Name</label>
              <input className="w-full border-[1px] border-primary border-solid mb-[5px] px-[15px] py-[5px]" 
              {...register('lastName')} type="name"/>
              {/* <input className="w-[60%] border-[1px] border-primary border-solid mb-[5px] px-[15px] py-[5px]" type="name" defaultValue={user.lastName}/> */}
              
              <label className="mb-[2px]">Course</label>
              <select className="w-full border-[1px] border-primary border-solid mb-[5px] px-[15px] py-[5px]"
              {...register('course')}>
                <option value={1}>1</option>
                <option value={2}>2</option>
                <option value={3}>3</option>
                <option value={4}>4</option>
              </select>

              <label className="mb-[2px]">Faculty</label>
              <select className="w-full border-[1px] border-primary border-solid mb-[5px] px-[15px] py-[5px]"
              {...register('facultyId')}>
                {faculties.map((faculty) => {
                  return <option key={faculty.facultyId} value={faculty.facultyId}>{faculty.facultyName}</option>
                })}
              </select>

              <label className="mb-[2px]">Password</label>
              <input className="w-full border-[1px] border-primary border-solid mb-[5px] px-[15px] py-[5px]" 
              {...register('password')} type={passwordHidden ? 'password' : 'text'}/>
              <span onClick={() => setPasswordHidden(!passwordHidden)}
              className='cursor-pointer text-sm hover:text-blue-500 underline'>
                {passwordHidden ? 'Show Password' : 'Hide Password'}
              </span>
            </div>
            <div className='grow flex flex-row sm:flex-col align-end justify-center sm:justify-start'>
              <button className="sm:ml-auto w-[200px] mt-[24px] text-white bg-black px-[20px] py-[0.35em]"
              type="submit">Save changes</button>            
            </div>
          </form>
      </div>
  )
}

export default Settings;