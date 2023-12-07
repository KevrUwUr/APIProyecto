import {BrowserRouter, Routes, Route} from 'react-router-dom'
import ShowJobs from './Componentes/ShowJobs'
import ShowProducts from './Componentes/ShowProducts'
import ShowCategories from './Componentes/ShowCategories'
import ShowLoses from './Componentes/ShowLoses'
import ShowEmployees from './Componentes/ShowEmployees'
import ShowSuppliers from './Componentes/ShowSuppliers'
import Index from './Componentes/index'
import QuienesSomos from './Componentes/QuienesSomos';
import Registrarse from './Componentes/Registrarse';
import LogIn from './Componentes/LogIn';
import IndexAdm from './Componentes/IndexAdmin.js'

function App() {
  return(
    <BrowserRouter>
      <Routes>
        <Route path='/' exact element={<Index/>}></Route>
        <Route path='/Admin' exact element={<IndexAdm/>}></Route>
        <Route path='/QuienesSomos' exact element={<QuienesSomos/>}></Route>
        <Route path='/Registrarse' exact element={<Registrarse/>}></Route>
        <Route path='/Login' exact element={<LogIn/>}></Route>
        <Route path='/Cargos' exact element={<ShowJobs/>}></Route>
        <Route path='/Productos' exact element={<ShowProducts/>}></Route>
        <Route path='/Categorias' exact element={<ShowCategories/>}></Route>
        <Route path='/Perdidas' exact element={<ShowLoses/>}></Route>
        <Route path='/Empleados' exact element={<ShowEmployees/>}></Route>
        <Route path='/Proveedores' exact element={<ShowSuppliers/>}></Route> 
      </Routes>
    </BrowserRouter>
  );
}

export default App;
