import React from 'react'
import { Routes, Route} from 'react-router-dom'
import { ConfirmAccunt, Login, Register } from './pages/auth'

export const Public = () => {
  return (
    <div>
      Public

      <Routes>
        
        <Route path='/login' element={<Login />}/>
        <Route path='/register' element={<Register />}/>
        <Route path='/confirm' element={<ConfirmAccunt />}/>
      </Routes>
    </div>
  )
}
