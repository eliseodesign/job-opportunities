import React from 'react'
import { Routes, Route} from 'react-router-dom'
import { ConfirmAccount, Login, Register } from './pages/auth'

export const Public = () => {
  return (
    <div>

      <Routes>
        
        <Route path='/login' element={<Login />}/>
        <Route path='/register' element={<Register />}/>
        <Route path='/auth/:token' element={<ConfirmAccount />}/>
      </Routes>
    </div>
  )
}
