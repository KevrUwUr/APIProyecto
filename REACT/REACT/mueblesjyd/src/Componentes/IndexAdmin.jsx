import React from "react";

import "../assets/css/Index.css";

const IndexAdm = () => {
  return (
    <div className="App">
        <section>
          <div className="container-fluid" id="page-top">
            <div className="d-flex align-items-center order-5" style={{ marginTop: '-20px', marginBottom: '21px' }}>
              <div className="container text-center" style={{ marginTop: '50px' }}>
                <h1 className="text-center" style={{ fontSize: '53px', fontFamily: 'ABeeZee, sans-serif', color: 'rgb(76,76,77)', fontWeight: 'bold' }}>Control de inventarios y ventas</h1>
                <h3 className="text-center" style={{ paddingTop: '0.25em', paddingBottom: '0.25em', fontWeight: 'normal', fontSize: '24px', fontFamily: 'ABeeZee, sans-serif' }}>Seleccione la opción deseada</h3>
                <a className="btn btn-outline-danger btn-lg" role="button" href="./Cargos" style={{ marginTop: '20px', width: '160px', fontFamily: 'ABeeZee, sans-serif' }}>Cargos</a><br/><br/>
                <a className="btn btn-outline-danger btn-lg" role="button" href="./Categorias" style={{ width: '160px', fontFamily: 'ABeeZee, sans-serif' }}>Categorias</a><br/><br/>
                <a className="btn btn-outline-danger btn-lg" role="button" href="./Empleados" style={{ width: '160px', fontFamily: 'ABeeZee, sans-serif' }}>Empleados</a><br/><br/>
                <a className="btn btn-outline-danger btn-lg" role="button" href="./Perdidas" style={{ width: '160px', fontFamily: 'ABeeZee, sans-serif' }}>Perdidas</a><br/><br/>
                <a className="btn btn-outline-danger btn-lg" role="button" href="./Productos" style={{ width: '160px', fontFamily: 'ABeeZee, sans-serif' }}>Productos</a><br/><br/>
                <a className="btn btn-outline-danger btn-lg" role="button" href="./Proveedores" style={{ width: '160px', fontFamily: 'ABeeZee, sans-serif' }}>Proveedores</a><br/><br/>
              </div>
            </div>
          </div>
        </section>
      
    </div>
  );
};

export default IndexAdm;
