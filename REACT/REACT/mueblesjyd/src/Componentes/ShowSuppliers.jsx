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

const ShowSuppliers = () => {
  const url = "http://localhost:5089/api/proveedores/";

  const [proveedores, setProveedores] = useState([]);
  const razonSocial = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });
  const estado = useInput({ defaultValue: "", validate: /^[0-9]+$/ });
  const [operation, setOperation] = useState([1]);
  const [title, setTitle] = useState();
  const [idToEdit, setidToEdit] = useState(null);
  const [filtro, setFiltro] = useState("");
  //Datos de contacto
  const urlContacto = "http://localhost:5089/api/proveedores/";
  const [contacto, setContactoEmpleados] = useState([]);
  const [contactoId, setContactoProveedorID] = useState([]);
  const [contactExist, setContactExist] = useState(false);
  const estadoContacto = useInput({ defaultValue: "", validate: /^[0-9]+$/ });

  const email = useInput({
    defaultValue: "",
    validate: /^[^\s@]+@[^\s@]+\.[^\s@]*$/,
  });

  const fechaAlta = useInput({
    defaultValue: "",
    validate: /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$/,
  });

  const fechaBaja = useInput({
    defaultValue: "",
    validate: /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$/,
  });

  const nombreProv = useInput({ defaultValue: "", validate: /^[A-Za-z ]*$/ });

  const telefono = useInput({ defaultValue: "", validate: /^\d{9}$/ });

  useEffect(() => {
    getSuppliers();
  }, []);

  const getSuppliers = async () => {
    const respuesta = await axios.get(url);
    setProveedores(respuesta.data);
  };

  const getSuppliersCont = async (id) => {
    try {
      const respuesta = await axios.get(
        `${urlContacto}${id}/contactoProveedores`
      );
      setContactoEmpleados(respuesta.data);
      return respuesta.data;
    } catch (error) {
      console.error("Error al obtener datos de contacto:", error);
      throw error;
    }
  };

  const openModal = (op, proveedor) => {
    const idProveedor = proveedor?.idProveedor;
    const razonSocia = proveedor?.razonSocial;
    const estados = proveedor?.estado;
    setOperation(op);
    if (op === 1) {
      setTitle("Registrar proveedor");
      razonSocial.handleChange("");
      estado.handleChange("");
    } else if (op === 2) {
      setTitle("Editar proveedor");
      razonSocial.handleChange(razonSocia);
      estado.handleChange(estados);
      setidToEdit(idProveedor);
    }
    window.setTimeout(function () {
      document.getElementById("razonSocial").focus();
    }, 500);
  };

  const openModalCont = async (proveedor) => {
    try {
      console.log({ proveedor });
      const contactos = await getSuppliersCont(proveedor.idProveedor);
      console.log("contactos", contactos);
      setidToEdit(proveedor.idProveedor);
      telefono.handleChange(contactos[0].telefono);
      nombreProv.handleChange(contactos[0].nombreProv);
      email.handleChange(contactos[0].email);
      estadoContacto.handleChange(contactos[0].estado);
      setContactoProveedorID(contactos[0].contProvId);
      console.log({ contacto });
      setContactExist(true);
    } catch (error) {
      setContactExist(false);
      console.error("Error al obtener datos de contacto:", error);
    } finally {
      razonSocial.handleChange(proveedor.razonSocial);
    }
  };

  const validar = (idProveedor) => {
    var parametros;
    var metodo;

    if (razonSocial.input.trim() === "") {
      show_alert("error", "Escribe el nombre del proveedor");
    } else if (estado.input === "") {
      show_alert("error", "Escribe el estado del proveedor");
    } else {
      if (operation === 1) {
        parametros = { razonSocial: razonSocial.input, estado: estado.input };
        metodo = "POST";
      } else {
        parametros = { razonSocial: razonSocial.input, estado: estado.input };
        console.log(parametros);
        metodo = "PUT";
      }

      enviarSolicitud(metodo, parametros, idProveedor);
    }
  };

  const enviarSolicitud = async (metodo, parametros, idProveedor) => {
    if (metodo === "POST") {
      axios
        .post(`${url}`, parametros)
        .then(function (respuesta) {
          show_alert("success", "Proveedor creado");
          document.getElementById("btnCerrar").click();
          getSuppliers();
        })
        .catch(function (error) {
          show_alert("error", "Error de solucitud");
          console.log(error);
        });
    } else if (metodo === "PUT") {
      axios
        .put(`${url}${idProveedor}`, parametros)
        .then(function (respuesta) {
          console.log("Solicitud PUT exitosa:", respuesta.data);

          show_alert("success", "Proveedor editado con exito");
          document.getElementById("btnCerrar").click();
          getSuppliers();
        })
        .catch(function (error) {
          show_alert("Error de solucitud", "error");
          console.log(error);
        });
    }
  };

  const deleteCargo = (proveedor) => {
    const idProveedor = proveedor.idProveedor;
    const name = proveedor.razonSocial;
    const MySwal = withReactContent(Swal);
    MySwal.fire({
      title: "¿Seguro quieres eliminar el proveedor " + name + "?",
      icon: "question",
      text: "No se podra dar marcha atras",
      showCancelButton: true,
      confirmButtonText: "Si, eliminar",
      cancelButtonText: "Cancelar",
    }).then(async (result) => {
      if (result.isConfirmed) {
        try {
          console.log(`${url}${idProveedor}`);
          await axios.delete(`${url}${idProveedor}`);
          show_alert("success", "Proveedor eliminado exitosamente");
          getSuppliers();
        } catch (error) {
          show_alert("error", "Error al eliminar el proveedor");
          console.error(error);
        }
      } else {
        show_alert("info", "El proveedor no fue eliminado");
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
                      Proveedores
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
                          placeholder="Filtrar por nombre de proveedor"
                          value={filtro}
                          onChange={(e) => setFiltro(e.target.value)}
                          className="form-control"
                        />
                        <button
                          onClick={() => openModal(1)}
                          className="btn btn-primary"
                          data-bs-toggle="modal"
                          data-bs-target="#modalProveedores"
                        >
                          <i className="fa-solid fa-circle-plus"></i> Añadir
                          proveedor
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
                      {proveedores.length > 0 && (
                        <Table
                          header={[...Object.keys(proveedores[0]), "Acciones"]}
                          data={proveedores}
                          onRemove={(item) => deleteCargo(item)}
                          modalId={"modalProveedores"}
                          modalId2={"modalContactoProveedores"}
                          filtroCampos={["razonSocial"]}
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

      <div id="modalProveedores" className="modal fade" aria-hidden="true">
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
                  id="razonSocial"
                  className="form-control"
                  placeholder="Nombre"
                  value={razonSocial.input}
                  onChange={(e) => razonSocial.handleChange(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-power-off"></i>
                </span>
                <input
                  type="text"
                  id="estado"
                  className="form-control"
                  placeholder="Estado"
                  value={estado.input}
                  onChange={(e) => estado.handleChange(e.target.value)}
                ></input>
              </div>
              <div className="d-grid col-6 mx-auto">
                <button
                  onClick={() => validar(idToEdit, razonSocial)}
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

      <div
        id="modalContactoProveedores"
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
                      <h4 className="card-title">{razonSocial.input}</h4>
                      <h5>Número telefónico:</h5>
                      <p>{`${telefono.input}`}</p>
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6">
                    <div className="contact-info">
                      <h5>Correo electronico:</h5>
                      <p>{email.input}</p>
                    </div>
                  </div>
                  <div className="col-md-6">
                    <div className="contact-info">
                      <h5>Nombre:</h5>
                      <p>{nombreProv.input}</p>
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
                      nombreProv.handleChange("");
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
                      <h4 className="card-title">{razonSocial.input}</h4>
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
                      <h5>Nombre del proveedor:</h5>
                      <input
                        placeholder="Introduce el nombre del proveedor"
                        value={nombreProv.input}
                        onChange={(e) =>
                          nombreProv.handleChange(e.target.value)
                        }
                      ></input>
                      {nombreProv.error && <p>{nombreProv.error}</p>}
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
                      if (contactExist) {
                        try {
                          await axios.put(
                            `${urlContacto}${idToEdit}/contactoProveedores/${contactoId}`,
                            {
                              telefono: telefono.input,
                              nombreProv: nombreProv.input,
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
                            `${urlContacto}${idToEdit}/contactoProveedores/`,
                            {
                              telefono: telefono.input,
                              nombreProv: nombreProv.input,
                              email: email.input,
                              empleadoId: idToEdit,
                            }
                          );
                          show_alert("success", "Contacto creado");
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

export default ShowSuppliers;
