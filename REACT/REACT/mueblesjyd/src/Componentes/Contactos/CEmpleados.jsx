import React from "react";

const CEmpleados = ({
  nombre,
  telefono,
  indicativo,
  tipoTelefono,
  ciudad,
  barrio,
  direccion,
  localidad,
  correo,
}) => {
  return (
    <div className="App">
      <div className="wrapper">
        <div className="main-panel">
          <div className="container-fluid mt-5">
            <h3 className="text-center mt-3 mb-4">Contacto empleado</h3>
          </div>
          <div className="card text-center shadow m-5">
            <div className="card-body">
              <h4 className="card-title">{nombre}</h4>
              <div className="row">
                <div className="col-md-12">
                  <div className="contact-info">
                    <h5>Número telefónico:</h5>
                    <p>{`${telefono} | Indicativo: ${indicativo} | Tipo: ${tipoTelefono}`}</p>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-md-6">
                  <div className="contact-info">
                    <h5>Ciudad:</h5>
                    <p>{ciudad}</p>

                    <h5>Barrio:</h5>
                    <p>{barrio}</p>
                  </div>
                </div>
                <div className="col-md-6">
                  <div className="contact-info">
                    <h5>Dirección:</h5>
                    <p>{direccion}</p>

                    <h5>Localidad:</h5>
                    <p>{localidad}</p>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-md-12">
                  <div className="contact-info">
                    <h5>Correo electrónico:</h5>
                    <p>{correo}</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div className="row m-3">
            <div className="col-md-6 text-center">
              <a href="/Empleados">
                <button className="btn btn-danger">
                  <i className="fa fa-arrow-left mr-2"></i> Regresar
                </button>
              </a>
            </div>
            <div className="col-md-6 text-center">
              <button className="btn btn-success">
                <i className="fas fa-pencil-alt mr-2"></i> Editar
              </button>
            </div>
          </div>
          <div className="text-center mt-4"></div>
        </div>
      </div>
    </div>
  );
};

export default CEmpleados;
