import React, { useEffect, useState } from "react";
import axios from "axios";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { show_alert } from "../Functions";
import "../assets/css/styles.css";
import "../assets/css/DashBoard-light-boostrap-animate.min.css";
import "../assets/css/DashBoard-light-boostrap-demo.css";
import "../assets/css/DashBoard-light-boostrap-pe-icon-7-stroke.css";
import "../assets/css/DashBoard-light-boostrap-light-bootstrap-dashboard.css";
import "../assets/css/Gamanet_Pagination_bs5.css";
import Sidebar from "./Navbar/sidebar";
import Table from "./Table";
import useInput from "./Hooks/useInput";

const Users = () => {
  const url = "http://localhost:5089/api/usuarios/";

  const [usuarios, setUsuarios] = useState([]);
  const primNombre = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });
  const segNombre = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });
  const primApellido = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });
  const segApellido = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });
  const sexo = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });
  const tipoDocumento = useInput({
    defaultValue: "",
    validate: /^[A-Za-z ]*$/,
  });
  const numDocumento = useInput({ defaultValue: "", validate: /^[0-9]+$/ });
  const fechaNacimiento = useInput({
    defaultValue: "",
    validate: /^\d{4}-\d{2}-\d{2}$/,
  });
  const estado = useInput({ defaultValue: "", validate: /^[0-9]+$/ });
  const fechaRegistro = useInput({
    defaultValue: "",
    validate: /^\d{4}-\d{2}-\d{2}$/,
  });
  const tipoUsuario = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });
  const fechaContrato = useInput({
    defaultValue: "",
    validate: /^\d{4}-\d{2}-\d{2}$/,
  });
  const cargo = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });
  const fechaFin = useInput({
    defaultValue: "",
    validate: /^\d{4}-\d{2}-\d{2}$/,
  });

  const [operation, setOperation] = useState([1]);
  const [title, setTitle] = useState();
  const [idToEdit, setidToEdit] = useState(null);
  const [filtro, setFiltro] = useState("");
  //Datos de contacto
  const urlContacto = "http://localhost:5089/api/usuarios/";
  const [contacto, setContactoUsuarios] = useState([]);
  const [contactoId, setContactoUsuarioID] = useState([]);
  const [contactExist, setContactExist] = useState(false);
  const barrioLocalidad = useInput({
    defaultValue: "",
    validate: /^[A-Za-z0-9 ]*$/,
  });
  const ciudad = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });
  const direccion = useInput({
    defaultValue: "",
    validate: /^[A-Za-z0-9 \#\.\-]*$/,
  });
  const email = useInput({
    defaultValue: "",
    validate: /^[^\s@]+@[^\s@]+\.[^\s@]*$/,
  });

  const indicativoCiudad = useInput({ defaultValue: "", validate: /^[0-9]+$/ });
  const numeroTelefonico = useInput({ defaultValue: "", validate: /^[0-9]+$/ });
  const tipoTelefono = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });

  useEffect(() => {
    getJobs();
  }, []);

  const getJobs = async () => {
    const respuesta = await axios.get(url);
    setUsuarios(respuesta.data);
  };

  const getUsuariosCont = async (id) => {
    try {
      const respuesta = await axios.get(`${urlContacto}${id}/contactoUsuarios`);
      setContactoUsuarios(respuesta.data);
      return respuesta.data;
    } catch (error) {
      console.error("Error al obtener datos de contacto:", error);
      throw error;
    }
  };

  const openModal = (op, usuario) => {
    setOperation(op);
    if (op === 1) {
      setTitle("Registrar usuario");
      primNombre.handleChange("");
      segNombre.handleChange("");
      primApellido.handleChange("");
      segApellido.handleChange("");
      sexo.handleChange("");
      tipoDocumento.handleChange("");
      numDocumento.handleChange("");
      fechaNacimiento.handleChange("");
      estado.handleChange("");
      fechaRegistro.handleChange("");
      tipoUsuario.handleChange("");
      fechaContrato.handleChange("");
      cargo.handleChange("");
      fechaFin.handleChange("");
    } else if (op === 2) {
      setTitle("Editar usuario");
      // Llenar campos con datos del usuario seleccionado
      primNombre.handleChange(usuario?.primNombre);
      segNombre.handleChange(usuario?.segNombre);
      primApellido.handleChange(usuario?.primApellido);
      segApellido.handleChange(usuario?.segApellido);
      sexo.handleChange(usuario?.sexo);
      tipoDocumento.handleChange(usuario?.tipoDocumento);
      numDocumento.handleChange(usuario?.numDocumento);
      fechaNacimiento.handleChange(usuario?.fechaNacimiento);
      estado.handleChange(usuario?.estado);
      fechaRegistro.handleChange(usuario?.fechaRegistro);
      tipoUsuario.handleChange(usuario?.tipoUsuario);
      fechaContrato.handleChange(usuario?.fechaContrato);
      cargo.handleChange(usuario?.cargo);
      fechaFin.handleChange(usuario?.fechaFin);
    }
    window.setTimeout(function () {
      document.getElementById("pNombre").focus();
    }, 500);
  };

  const openModalCont = async (usuario) => {
    try {
      console.log({ usuario });
      const contactos = await getUsuariosCont(usuario.idUsuario);
      console.log("contactos", contactos);
      setidToEdit(usuario.idUsuario);
      // barrioLocalidad.handleChange(contactos[0].barrio_localidad);
      // ciudad.handleChange(contacto[0].ciudad);
      direccion.handleChange(contactos[0].direccion);
      email.handleChange(contactos[0].email);
      // indicativoCiudad.handleChange(contactos[0].indicativoCiudad);
      numeroTelefonico.handleChange(contactos[0].numeroTelefonico);
      // tipoTelefono.handleChange(contacto[0].tipoTelefono);
      setContactoUsuarioID(contactos[0].contUsuarioId);
      console.log({ contacto });
      setContactExist(true);
    } catch (error) {
      setContactExist(false);
      console.error("Error al obtener datos de contacto:", error);
    } finally {
      primNombre.handleChange(usuario.primNombre);
      primApellido.handleChange(usuario.primApellido);
    }
  };

  const validar = (id) => {
    var parametros;
    var metodo;

    if (
      primNombre.input.trim() === "" ||
      segNombre.input.trim() === "" ||
      primApellido.input.trim() === "" ||
      segApellido.input.trim() === "" ||
      sexo.input.trim() === "" ||
      tipoDocumento === "" ||
      numDocumento.input.trim() === "" ||
      estado === "" ||
      fechaNacimiento.input.trim() === "" ||
      fechaRegistro.input.trim() === "" ||
      tipoUsuario.input.trim() === "" ||
      fechaContrato.input.trim() === "" ||
      cargo.trim() === "" ||
      fechaFin.input.trim() === ""
    ) {
      show_alert("error", "Completa todos los campos del formulario");
    } else {
      if (operation === 1) {
        parametros = {
          primNombre: primNombre.input,
          segNombre: segNombre.input,
          primApellido: primApellido.input,
          segApellido: segApellido.input,
          sexo: sexo.input,
          tipoDocumento: tipoDocumento.input,
          numDocumento: numDocumento.input,
          fechaNacimiento: fechaNacimiento.input,
          estado: estado.input,
          fechaRegistro: fechaRegistro.input,
          tipoUsuario: tipoUsuario.input,
          fechaContrato: fechaContrato.input,
          cargo: cargo.input,
          fechaFin: fechaFin.input,
        };
        metodo = "POST";
      } else {
        parametros = {
          primNombre: primNombre.input,
          segNombre: segNombre.input,
          primApellido: primApellido.input,
          segApellido: segApellido.input,
          sexo: sexo.input,
          tipoDocumento: tipoDocumento.input,
          numDocumento: numDocumento.input,
          fechaNacimiento: fechaNacimiento.input,
          estado: estado.input,
          fechaRegistro: fechaRegistro.input,
          tipoUsuario: tipoUsuario.input,
          fechaContrato: fechaContrato.input,
          cargo: cargo.input,
          fechaFin: fechaFin.input,
        };
        metodo = "PUT";
      }

      enviarSolicitud(metodo, parametros, id);
    }
  };

  const enviarSolicitud = async (metodo, parametros, id) => {
    if (metodo === "POST") {
      axios
        .post(`${url}`, parametros)
        .then(function (respuesta) {
          show_alert("success", "Usuario creado");
          document.getElementById("btnCerrar").click();
          getJobs();
        })
        .catch(function (error) {
          show_alert("error", "Error de solucitud");
          console.log(error);
        });
    } else if (metodo === "PUT") {
      axios
        .put(`${url}${id}`, parametros)
        .then(function (respuesta) {
          console.log("Solicitud PUT exitosa:", respuesta.data);
          show_alert("success", "Usuario editado con exito");
          document.getElementById("btnCerrar").click();
          getJobs();
        })
        .catch(function (error) {
          show_alert("Error de solucitud", "error");
          console.log(error);
        });
    }
  };

  const deleteCargo = (usuario) => {
    const id = usuario.id;
    const name = usuario.primNombre + " " + usuario.primApellido;
    const MySwal = withReactContent(Swal);
    MySwal.fire({
      title: "¿Seguro quieres eliminar el usuario " + name + "?",
      icon: "question",
      text: "No se podra dar marcha atras",
      showCancelButton: true,
      confirmButtonText: "Si, eliminar",
      cancelButtonText: "Cancelar",
    }).then(async (result) => {
      if (result.isConfirmed) {
        try {
          console.log(`${url}${id}`);
          await axios.delete(`${url}${id}`);
          show_alert("success", "Usuario eliminado exitosamente");
          getJobs();
        } catch (error) {
          show_alert("error", "Error al eliminar el usuario");
          console.error(error);
        }
      } else {
        show_alert("info", "El usuario no fue eliminado");
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
                      Usuarios
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
                          placeholder="Filtrar por nombre de usuario"
                          value={filtro}
                          onChange={(e) => setFiltro(e.target.value)}
                          className="form-control"
                        />
                        <button
                          onClick={() => openModal(1)}
                          className="btn btn-primary"
                          data-bs-toggle="modal"
                          data-bs-target="#modalUsuarios"
                        >
                          <i className="fa-solid fa-circle-plus"></i> Añadir
                          usuario
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
                      {usuarios.length > 0 && (
                        <Table
                          header={[...Object.keys(usuarios[0]), "Acciones"]}
                          data={usuarios}
                          onRemove={(item) => deleteCargo(item)}
                          modalId={"modalUsuarios"}
                          modalId2={"modalContactoUsuarios"}
                          filtroCampos={["primNombre"]}
                          filtro={filtro}
                          onUpdate={(payload) => openModal(2, payload)}
                          onView={(payload) => openModalCont(payload)}
                        />
                      )}
                    </div>
                  </div>
                </div>
                <div className="row"></div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div id="modalUsuarios" className="modal fade" aria-hidden="true">
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
                  id="pNombre"
                  className="form-control"
                  placeholder="Primer Nombre"
                  value={primNombre.input}
                  onChange={(e) => primNombre.handleChange(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-user"></i>
                </span>
                <input
                  type="text"
                  id="sNombre"
                  className="form-control"
                  placeholder="Segundo Nombre"
                  value={segNombre.input}
                  onChange={(e) => segNombre.handleChange(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-user"></i>
                </span>
                <input
                  type="text"
                  id="pApellido"
                  className="form-control"
                  placeholder="Primer Apellido"
                  value={primApellido.input}
                  onChange={(e) => primApellido.handleChange(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-user"></i>
                </span>
                <input
                  type="text"
                  id="sApellido"
                  className="form-control"
                  placeholder="Segundo Apellido"
                  value={segApellido.input}
                  onChange={(e) => segApellido.handleChange(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-venus-mars"></i>
                </span>
                <select
                  className="form-control"
                  id="sexo"
                  value={sexo.input}
                  onChange={(e) => sexo.handleChange(e.target.value)}
                >
                  <option value="">Seleccionar Sexo</option>
                  <option value="M">Masculino</option>
                  <option value="F">Femenino</option>
                </select>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-id-card"></i>
                </span>
                <select
                  className="form-control"
                  id="tipoDocumento"
                  value={tipoDocumento.input}
                  onChange={(e) => tipoDocumento.handleChange(e.target.value)}
                >
                  <option value="">Seleccionar Tipo de Documento</option>
                  <option value="1">Cedula de ciudadania</option>
                  <option value="2">Tarjeta de identidad</option>
                  <option value="3">Cedula de extrangeria</option>
                  <option value="4">Permiso especial de permanencia</option>
                </select>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-user"></i>
                </span>
                <input
                  type="text"
                  id="nDocumento"
                  className="form-control"
                  placeholder="Numero de documento"
                  value={numDocumento.input}
                  onChange={(e) => numDocumento.handleChange(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-user"></i>
                </span>
                <input
                  type="date"
                  id="fechaNacimiento"
                  className="form-control"
                  value={fechaNacimiento.input}
                  onChange={(e) => fechaNacimiento.handleChange(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-id-card"></i>
                </span>
                <select
                  className="form-control"
                  id="Estado"
                  value={estado.input}
                  onChange={(e) => estado.handleChange(e.target.value)}
                >
                  <option value="">Seleccionar estado</option>
                  <option value="1">Activo</option>
                  <option value="2">Inactivo</option>
                </select>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-user"></i>
                </span>
                <input
                  type="date"
                  id="fechaNacimiento"
                  className="form-control"
                  value={fechaRegistro.input}
                  onChange={(e) => fechaRegistro.handleChange(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-id-card"></i>
                </span>
                <select
                  className="form-control"
                  id="tipoUsuario"
                  value={tipoUsuario.input}
                  onChange={(e) => tipoUsuario.handleChange(e.target.value)}
                >
                  <option value="">Seleccionar Tipo de usuario</option>
                  <option value="1">Comprador</option>
                  <option value="2">Administrador</option>
                </select>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-user"></i>
                </span>
                <input
                  type="date"
                  id="fechaContrato"
                  className="form-control"
                  value={fechaContrato.input}
                  onChange={(e) => fechaContrato.handleChange(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-user"></i>
                </span>
                <input
                  type="text"
                  id="cargo"
                  className="form-control"
                  placeholder="Cargo"
                  value={cargo.input}
                  onChange={(e) => cargo.handleChange(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-user"></i>
                </span>
                <input
                  type="date"
                  id="fechaFin"
                  className="form-control"
                  value={fechaFin.input}
                  onChange={(e) => fechaFin.handleChange(e.target.value)}
                ></input>
              </div>
              <div className="d-grid col-6 mx-auto">
                <button
                  onClick={() => validar(idToEdit)}
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
              >
                Cerrar
              </button>
            </div>
          </div>
        </div>
      </div>

      <div id="modalContactoUsuarios" className="modal fade" aria-hidden="true">
        <div className="modal-dialog modal-lg">
          <div className="modal-content">
            <div className="container-fluid mt-5">
              <h3 className="text-center mt-3 mb-4">Contacto usuario</h3>
            </div>
            <div className="card text-center shadow m-5">
              <div className="card-body">
                <div className="row">
                  <div className="col-md-12">
                    <div className="contact-info">
                      <h4 className="card-title">
                        {primNombre.input} {primApellido.input}
                      </h4>
                      <h5>Número telefónico:</h5>
                      <p>{`${numeroTelefonico.input}`}</p>
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
                    data-bs-target="#modalContactoUsuario"
                    onClick={() => {
                      numeroTelefonico.handleChange("");
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
                    data-bs-target="#modalEditarContactoUsuario"
                    onClick={() => {
                      numeroTelefonico.handleChange("");
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
        id="modalEditarContactoUsuario"
        className="modal fade"
        aria-hidden="true"
      >
        <div className="modal-dialog modal-lg">
          <div className="modal-content">
            <div className="container-fluid mt-5">
              <h3 className="text-center mt-3 mb-4">Contacto Usuario</h3>
            </div>
            <div className="card text-center shadow m-5">
              <div className="card-body">
                <div className="row">
                  <div className="col-md-12">
                    <div className="contact-info">
                      <h4 className="card-title">
                        {primNombre.input} {primApellido.input}
                      </h4>
                      <h5>Número telefónico:</h5>
                      <input
                        placeholder="Introduce el numero telefonico"
                        value={numeroTelefonico.input}
                        onChange={(e) =>
                          numeroTelefonico.handleChange(e.target.value)
                        }
                      ></input>
                    </div>
                    {numeroTelefonico.error && <p>{numeroTelefonico.error}</p>}
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
                      numeroTelefonico.handleChange("");
                      direccion.handleChange("");
                      email.handleChange("");
                      if (contactExist) {
                        try {
                          await axios.put(
                            `${urlContacto}${idToEdit}/contactoEmpleados/${contactoId}`,
                            {
                              direccion: direccion.input,
                              email: email.input,
                              numeroTelefonico: numeroTelefonico.input,
                              indicativoCiudad: indicativoCiudad.input,
                              tipoTelefono: tipoTelefono.input,
                              ciudad: ciudad.input,
                              barrio_Localidad: barrioLocalidad.input,
                              idUsuario: idToEdit,
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
                              telefono: numeroTelefonico.input,
                              direccion: direccion.input,
                              email: email.input,
                              idUsuario: idToEdit,
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

export default Users;
