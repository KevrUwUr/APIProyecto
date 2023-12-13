import React from "react";

import Logo from "../assets/img/Logo.png";
import "../assets/css/Index.css"
import Navbar from "./Navbar";
import Footer from "./Footer";


const QuienesSomos = () => {
  
  return (
    <div className="App">
      <Navbar/>
          <div style={{ background: '#f9f5eb', width: '100%', height: '99%' }}>
      <div className="container" style={{ marginTop: '50px', marginBottom: '50px', width: '1160px' }}>
        <div className="row" style={{ padding: '25px', paddingRight: '0px', paddingLeft: '0px' }}>
          <div className="col-md-6" style={{ width: '70%', fontSize: '18px', textAlign: 'justify', fontFamily: 'ABeeZee, sans-serif' }}>
            <h1 style={{ marginTop: '0px', padding: '10px', fontFamily: 'ABeeZee, sans-serif', fontWeight: 'bold' }}>¿Quiénes somos?</h1>
            <p style={{ height: '150px', width: '600px', textAlign: 'justify', padding: '10px', fontFamily: 'ABeeZee, sans-serif' }}>Somos una empresa familiar creada en 1990 dedicada a la fabricación de muebles en madera, con la opción de personalizarlos a gusto del cliente, actualmente nos encontramos ubicados en bosa la estanzuela y contamos con distribución por toda Bogotá o sus cercanías realizamos ventas al mayor y al detal</p>
          </div>
          <div className="col-md-6 align-self-center" style={{ width: '30%' }}>
            <img src={Logo} alt="Logo" style={{ width: '256px' }} />
          </div>
        </div>
      </div>
    </div>
    <Footer/>
    </div>
  );
}

export default QuienesSomos;