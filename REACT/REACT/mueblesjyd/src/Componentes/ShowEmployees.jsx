import React, { useEffect, useState } from "react";
import axios from "axios";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { show_alert } from "../Functions";
import "../assets/css/styles.css";
import Sidebar from "./Navbar/sidebar";
import Table from "./Table";
import useInput from "./Hooks/useInput";

const ShowJobs = () => {
  const url = "http://localhost:5089/api/empleados/";
  const [empleados, setEmpleados] = useState([]);
  const nombres = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });
  const apellidos = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });
  const sexo = useInput({ defaultValue: "", validate: /^[A-Za-z]*$/ });
  const fechaNacimiento = useInput({
    defaultValue: "",
    validate: /^\d{4}-\d{2}-\d{2}$/,
  });
  const estado = useInput({ defaultValue: "", validate: /^[0-9]+$/ });
  const [operation, setOperation] = useState([1]);
  const [title, setTitle] = useState();
  const [idToEdit, setidToEdit] = useState(null);
  const [filtro, setFiltro] = useState("");
  //Datos de contacto
  const urlContacto = "http://localhost:5089/api/empleados/";
  const [contacto, setContactoEmpleados] = useState([]);
  const [contactoId, setContactoEmpleadoID] = useState([]);
  const [contactExist, setContactExist] = useState(false);
  const telefono = useInput({ defaultValue: "", validate: /^\d{9}$/ });
  const direccion = useInput({
    defaultValue: "",
    validate: /^[a-zA-Z0-9\s.,#-]+$/,
  });
  const email = useInput({
    defaultValue: "",
    validate: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
  });
  const fechaRegistro = useInput({
    defaultValue: "",
    validate: /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$/,
  });

  useEffect(() => {
    getEmployees();
  }, []);

  const getEmployees = async () => {
    const respuesta = await axios.get(url);
    setEmpleados(respuesta.data);
  };

  const getEmployeesCont = async (id) => {
    try {
      const respuesta = await axios.get(
        `${urlContacto}${id}/contactoEmpleados`
      );
      setContactoEmpleados(respuesta.data);
      return respuesta.data;
    } catch (error) {
      console.error("Error al obtener datos de contacto:", error);
      throw error;
    }
  };

  const openModal = (op, empleado) => {
    const nombre = empleado?.nombres;
    const apellido = empleado?.apellidos;
    const genero = empleado?.sexo;
    const fNacimiento = empleado?.fechaNacimiento;
    const estados = empleado?.estado;
    const empleadoId = empleado?.empleadoId;
    console.log({
      nombres,
      apellidos,
      sexo,
      fechaNacimiento,
      estados,
      empleadoId,
      op,
    });

    estado.handleChange("");
    setOperation(op);
    if (op === 1) {
      setTitle("Registrar empleado");
      nombres.handleChange("");
      apellidos.handleChange("");
      sexo.handleChange("");
      fechaNacimiento.handleChange("");
      estado.handleChange("");
    } else if (op === 2) {
      setTitle("Editar empleado");
      nombres.handleChange(nombre);
      apellidos.handleChange(apellido);
      sexo.handleChange(genero);
      fechaNacimiento.handleChange(fNacimiento);
      estado.handleChange(estados);
      setidToEdit(empleadoId);
      console.log("Entro a edit con:", empleadoId);
    }
    window.setTimeout(function () {
      document.getElementById("nombres").focus();
    }, 500);
  };

  const openModalCont = async (empleado) => {
    try {
      console.log({ empleado });
      const contactos = await getEmployeesCont(empleado.empleadoId);
      console.log("contactos", contactos, "Telefono", contactos[0].telefono);
      setidToEdit(empleado.empleadoId);
      telefono.handleChange(contactos[0].telefono);
      direccion.handleChange(contactos[0].direccion);
      email.handleChange(contactos[0].email);
      fechaRegistro.handleChange(contactos[0].fechaCreacion);
      setContactoEmpleadoID(contactos[0].contEmpId);
      console.log({ contacto });
      setContactExist(true);
    } catch (error) {
      setContactExist(false);
      console.error("Error al obtener datos de contacto:", error);
    } finally {
      nombres.handleChange(empleado.nombres);
      apellidos.handleChange(empleado.apellidos);
    }
  };

  const validar = (empleadoId) => {
    var parametros;
    var metodo;

    if (nombres.input.trim() === "") {
      show_alert("error", "Escribe el nombre del empleado");
    } else if (apellidos.input.trim() === "") {
      show_alert("error", "Escribe los apellidos del empleado");
    } else if (sexo.input.trim() === "") {
      show_alert("error", "Escribe el sexo del empleado");
    } else if (fechaNacimiento.input.trim() === "") {
      show_alert("error", "Escribe fecha de nacimiento del empleado");
    } else if (estado.input.trim() === "") {
      show_alert("error", "Escribe el estado del empleado");
    } else {
      if (operation === 1) {
        parametros = {
          nombres: nombres.input,
          apellidos: apellidos.input,
          sexo: sexo.input,
          fechaNacimiento: fechaNacimiento.input,
          estado: estado.input,
        };
        metodo = "POST";
      } else {
        parametros = {
          nombres: nombres.input,
          apellidos: apellidos.input,
          sexo: sexo.input,
          fechaNacimiento: fechaNacimiento.input,
          estado: estado.input,
        };
        console.log(parametros);
        metodo = "PUT";
      }

      enviarSolicitud(metodo, parametros, empleadoId);
    }
  };

  const enviarSolicitud = async (metodo, parametros, empleadoId) => {
    if (metodo === "POST") {
      axios
        .post(`${url}`, parametros)
        .then(function (respuesta) {
          show_alert("success", "Empleado creado");
          document.getElementById("btnCerrar").click();
          getEmployees();
        })
        .catch(function (error) {
          show_alert("error", "Error de solucitud");
          console.log(error);
        });
    } else if (metodo === "PUT") {
      axios
        .put(`${url}${empleadoId}`, parametros)
        .then(function (respuesta) {
          console.log("Solicitud PUT exitosa:", respuesta.data);

          show_alert("success", "Empleado editado con exito");
          document.getElementById("btnCerrar").click();
          getEmployees();
        })
        .catch(function (error) {
          show_alert("Error de solucitud", "error");
          console.log(error);
        });
    }
  };

  const deleteEmpleado = (empleado) => {
    const empleadoId = empleado?.empleadoId;
    const name = empleado?.nombres + " " + empleado?.apellidos;
    const MySwal = withReactContent(Swal);
    MySwal.fire({
      title: "¿Seguro quieres eliminar el empleado " + name + "?",
      icon: "question",
      text: "No se podra dar marcha atras",
      showCancelButton: true,
      confirmButtonText: "Si, eliminar",
      cancelButtonText: "Cancelar",
    }).then(async (result) => {
      if (result.isConfirmed) {
        try {
          console.log(`${url}${empleadoId}`);
          await axios.delete(`${url}${empleadoId}`);
          show_alert("success", "Empleado eliminado exitosamente");
          getEmployees();
        } catch (error) {
          show_alert("error", "Error al eliminar el empleado");
          console.error(error);
        }
      } else {
        show_alert("info", "El empleado no fue eliminado");
      }
    });
  };

  return (
    <div className="App">
      <div className="wrapper">
        <Sidebar />
        <div className="main-panel">
          <nav
            style={{ backgroundColor: "white" }}
            className="navbar navbar-expand-md d-xl-flex d-xxl-flex justify-content-xl-center justify-content-xxl-center align-items-xxl-center navbar-light"
          >
            <div className="container-fluid">
              <div
                className="collapse navbar-collapse d-xl-flex d-xxl-flex justify-content-xl-center justify-content-xxl-center align-items-xxl-center"
                id="navcol-1"
              >
                <ul className="navbar-nav d-xl-flex d-xxl-flex justify-content-xl-center justify-content-xxl-center align-items-xxl-center">
                  <li className="nav-item d-xl-flex d-xxl-flex justify-content-xl-center justify-content-xxl-center align-items-xxl-center">
                    <h3 className="d-xl-flex d-xxl-flex justify-content-xl-center justify-content-xxl-center align-items-xxl-center">
                      Empleados
                    </h3>
                  </li>
                </ul>
              </div>
            </div>
          </nav>
          <div className="content">
            <div className="container-fluid" style={{ marginBottom: 50 }}>
              <div
                className="card"
                id="TableSorterCard"
                style={{ borderStyle: "none", borderRadius: "6.5px" }}
              >
                <div
                  className="card-header py-3"
                  style={{ borderWidth: 0, background: "rgb(23,25,33)" }}
                >
                  <div className="row table-topper align-items-center">
                    <div
                      className="col-12 col-sm-5 col-md-6 text-start"
                      style={{ margin: 0, padding: "5px 15px" }}
                    >
                      <div className="input-group">
                        <input
                          type="text"
                          placeholder="Filtrar por nombre de empleado"
                          value={filtro}
                          onChange={(e) => setFiltro(e.target.value)}
                          className="form-control"
                        />
                        <button
                          onClick={() => openModal(1)}
                          className="btn btn-primary"
                          data-bs-toggle="modal"
                          data-bs-target="#modalEmpleados"
                        >
                          <i className="fa-solid fa-circle-plus"></i> Añadir
                          empleado
                        </button>
                      </div>
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-12">
                    <div
                      className="table-responsive"
                      style={{ borderTopStyle: "none", background: "#171921" }}
                    >
                      {empleados.length > 0 && (
                        <Table
                          header={[...Object.keys(empleados[0]), "Acciones"]}
                          data={empleados}
                          onRemove={(item) => deleteEmpleado(item)}
                          modalId={"modalEmpleados"}
                          modalId2={"modalContactoEmpleados"}
                          filtroCampos={["nombres"]}
                          filtro={filtro}
                          onUpdate={(payload) => openModal(2, payload)}
                          onView={(payload) => openModalCont(payload)}
                        />
                      )}
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div id="modalEmpleados" className="modal fade" aria-hidden="true">
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header">
              <label className="h5">{title}</label>
              <button
                type="button"
                className="btn-close"
                data-bs-dismiss="modal"
                aria-label="close"
              ></button>
            </div>
            <div className="modal-body">
              <input type="hidden" id="id"></input>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-user"></i>
                </span>
                <input
                  type="text"
                  id="nombres"
                  className="form-control"
                  placeholder="Nombres"
                  value={nombres.input}
                  onChange={(e) => nombres.handleChange(e.target.value)}
                ></input>
              </div>
              {nombres.error && <p>{nombres.error}</p>}
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-user"></i>
                </span>
                <input
                  type="text"
                  id="apellidos"
                  className="form-control"
                  placeholder="Apellidos"
                  value={apellidos.input}
                  onChange={(e) => apellidos.handleChange(e.target.value)}
                ></input>
              </div>
              {apellidos.error && <p>{apellidos.error}</p>}
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-transgender-alt"></i>
                </span>
                <input
                  type="text"
                  id="sexo"
                  className="form-control"
                  placeholder="Sexo"
                  value={sexo.input}
                  onChange={(e) => sexo.handleChange(e.target.value)}
                ></input>
              </div>
              {sexo.error && <p>{sexo.error}</p>}
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-calendar"></i>
                </span>
                <input
                  type="date"
                  id="fechanacimiento"
                  className="form-control"
                  placeholder="Fecha de nacimiento"
                  value={fechaNacimiento.input}
                  onChange={(e) => fechaNacimiento.handleChange(e.target.value)}
                ></input>
              </div>
              {fechaNacimiento.error && <p>{fechaNacimiento.error}</p>}
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-power-off"></i>
                </span>
                <input
                  type="number"
                  id="estado"
                  className="form-control"
                  placeholder="Estado"
                  value={estado.input}
                  onChange={(e) => estado.handleChange(e.target.value)}
                ></input>
              </div>
              {estado.error && <p>{estado.error}</p>}
              <div className="d-grid col-6 mx-auto">
                <button
                  onClick={() => validar(idToEdit, nombres.input)}
                  className="btn btn-success"
                >
                  <i className="fa-solid fa-floppy-disk"></i> Guardar
                </button>
              </div>
            </div>
            <div className="modal-footer">
              <button
                id="btnCerrar"
                type="button"
                className="btn btn-secondary"
                data-bs-dismiss="modal"
              ></button>
            </div>
          </div>
        </div>
      </div>

      <div
        id="modalContactoEmpleados"
        className="modal fade"
        aria-hidden="true"
      >
        <div className="modal-dialog modal-lg">
          <div className="modal-content">
            <div className="container-fluid mt-5">
              <h3 className="text-center mt-3 mb-4">Contacto empleado</h3>
            </div>
            <div className="card text-center shadow m-5">
              <div className="card-body">
                <div className="row">
                  <div className="col-md-12">
                    <div className="contact-info">
                      <h4 className="card-title">
                        {nombres.input} {apellidos.input}
                      </h4>
                      <h5>Número telefónico:</h5>
                      <p>{`${telefono.input}`}</p>
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6">
                    <div className="contact-info">
                      <h5>Direccion:</h5>
                      <p>{direccion.input}</p>
                    </div>
                  </div>
                  <div className="col-md-6">
                    <div className="contact-info">
                      <h5>Correo electrónico:</h5>
                      <p>{email.input}</p>
                    </div>
                  </div>
                </div>
              </div>
              <div className="row m-3">
                <div className="col-md-6 text-center">
                  <button
                    className="btn btn-danger"
                    data-bs-dismiss="modal"
                    onClick={() => {
                      telefono.handleChange("");
                      direccion.handleChange("");
                      email.handleChange("");
                    }}
                  >
                    <i className="fa fa-arrow-left mr-2"></i> Regresar
                  </button>
                </div>
                <div className="col-md-6 text-center">
                  <button
                    className="btn btn-success"
                    data-bs-toggle="modal"
                    data-bs-target="#modalEditarContactoEmpleado"
                    onClick={() => {
                      telefono.handleChange("");
                      direccion.handleChange("");
                      email.handleChange("");
                    }}
                  >
                    <i className="fas fa-pencil-alt mr-2"></i> Editar
                  </button>
                </div>
              </div>

              <div className="text-center mt-4"></div>
            </div>
          </div>
        </div>
      </div>

      <div
        id="modalEditarContactoEmpleado"
        className="modal fade"
        aria-hidden="true"
      >
        <div className="modal-dialog modal-lg">
          <div className="modal-content">
            <div className="container-fluid mt-5">
              <h3 className="text-center mt-3 mb-4">Contacto empleado</h3>
            </div>
            <div className="card text-center shadow m-5">
              <div className="card-body">
                <div className="row">
                  <div className="col-md-12">
                    <div className="contact-info">
                      <h4 className="card-title">
                        {nombres.input} {apellidos.input}
                      </h4>
                      <h5>Número telefónico:</h5>
                      <input
                        placeholder="Introduce el numero telefonico"
                        value={telefono.input}
                        onChange={(e) => telefono.handleChange(e.target.value)}
                      ></input>
                    </div>
                    {telefono.error && <p>{telefono.error}</p>}
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6">
                    <div className="contact-info">
                      <h5>Direccion:</h5>
                      <input
                        placeholder="Introduce la direccion"
                        value={direccion.input}
                        onChange={(e) => direccion.handleChange(e.target.value)}
                      ></input>
                      {direccion.error && <p>{direccion.error}</p>}
                    </div>
                  </div>
                  <div className="col-md-6">
                    <div className="contact-info">
                      <h5>Correo electrónico:</h5>
                      <input
                        placeholder="Introduce tu correo electronico"
                        value={email.input}
                        onChange={(e) => email.handleChange(e.target.value)}
                      ></input>
                    </div>
                    {email.error && <p>{email.error}</p>}
                  </div>
                </div>
              </div>
              <div className="row m-3">
                <div className="col-md-6 text-center">
                  <button
                    className="btn btn-danger"
                    data-bs-toggle="modal"
                    data-bs-target="#modalEditarContactoEmpleado"
                  >
                    <i className="fa fa-arrow-left mr-2"></i> Regresar
                  </button>
                </div>
                <div className="col-md-6 text-center">
                  <button
                    className="btn btn-success"
                    data-bs-toggle="modal"
                    data-bs-target="#modalEditarContactoEmpleado"
                    onClick={async () => {
                      telefono.handleChange("");
                      direccion.handleChange("");
                      email.handleChange("");
                      if (contactExist) {
                        try {
                          await axios.put(
                            `${urlContacto}${idToEdit}/contactoEmpleados/${contactoId}`,
                            {
                              telefono: telefono.input,
                              direccion: direccion.input,
                              email: email.input,
                            }
                          );
                          show_alert("success", "Contacto actualizado");
                        } catch (error) {
                          console.log({ contacto });
                          show_alert("error", "Contacto no se actualizo");
                        }
                      } else {
                        try {
                          await axios.post(
                            `${urlContacto}${idToEdit}/contactoEmpleados/`,
                            {
                              telefono: telefono.input,
                              direccion: direccion.input,
                              email: email.input,
                              empleadoId: idToEdit,
                            }
                          );
                          show_alert("success", "Contacto credo");
                        } catch (error) {
                          console.log({ contacto });
                          show_alert("error", "Contacto no se creo");
                        }
                      }
                    }}
                  >
                    <i className="fas fa-floppy-disk mr-2"></i> Guardar
                  </button>
                </div>
              </div>

              <div className="text-center mt-4"></div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ShowJobs;
