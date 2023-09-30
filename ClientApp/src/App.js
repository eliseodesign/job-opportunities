import React from 'react';
import { Routes, Route} from 'react-router-dom'
import { Admin } from './views/admin/Admin'
import { Public } from './views/public/Public'
import { NotFound } from './views/NotFound'
import './index.css'

function App() {
  return (
    <>
      <Routes>
        <Route path='/admin' element={<Admin />}/>
        <Route path='/*' element={<Public />}/>
        <Route path='*' element={<NotFound />}/>
      </Routes>
    </>
  )
}

export default App