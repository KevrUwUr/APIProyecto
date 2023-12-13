import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Carrito from "./Componentes/Carrito";
import Index from "./Componentes/index";
import IndexAdm from "./Componentes/IndexAdmin";
import ListaProductos from "./Componentes/ListaProductos";
import LogIn from "./Componentes/LogIn";
import QuienesSomos from "./Componentes/QuienesSomos";
import Registrarse from "./Componentes/Registrarse";
import ShowCategories from "./Componentes/ShowCategories";
import ShowEmployees from "./Componentes/ShowEmployees";
import ShowBuyBill from "./Componentes/ShowBuyBill";
import ShowJobs from "./Componentes/ShowJobs";
import ShowLoses from "./Componentes/ShowLoses";
import ShowProducts from "./Componentes/ShowProducts";
import ShowSellBill from "./Componentes/ShowSellBill";
import ShowSuppliers from "./Componentes/ShowSuppliers";
import ShowUsers from "./Componentes/ShowUsers";




function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" exact element={<Index />} />
        <Route path="/Admin" exact element={<IndexAdm />} />
        <Route path="/Carrito" exact element={<Carrito />} />
        <Route path="/Cargos" exact element={<ShowJobs />} />
        <Route path="/Categorias" exact element={<ShowCategories />} />
        <Route path="/Empleados" exact element={<ShowEmployees />} />
        <Route path="/Facturas/Compras" exact element={<ShowBuyBill />} />
        <Route path="/Facturas/Ventas" exact element={<ShowSellBill />} />
        <Route path="/ListaProductos" exact element={<ListaProductos />} />
        <Route path="/Login" exact element={<LogIn />} />
        <Route path="/Perdidas" exact element={<ShowLoses />} />
        <Route path="/Productos" exact element={<ShowProducts />} />
        <Route path="/Proveedores" exact element={<ShowSuppliers />} />
        <Route path="/QuienesSomos" exact element={<QuienesSomos />} />
        <Route path="/Registrarse" exact element={<Registrarse />} />
        <Route path="/Usuarios" exact element={<ShowUsers />} />
        

      </Routes>
    </BrowserRouter>
  );
}

export default App;
