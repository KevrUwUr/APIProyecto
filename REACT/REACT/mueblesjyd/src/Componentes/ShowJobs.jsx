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

const ShowJobs = () => {
  const url = "http://localhost:5089/api/cargos/";

  const [cargos, setCargos] = useState([]);
  const [NombreCargo, setNombreCargoActual] = useState("");
  const [estado, setEstado] = useState();
  const [operation, setOperation] = useState([1]);
  const [title, setTitle] = useState();
  const [idToEdit, setidToEdit] = useState(null);
  const [filtro, setFiltro] = useState("");

  useEffect(() => {
    getJobs();
  }, []);

  const getJobs = async () => {
    const respuesta = await axios.get(url);
    setCargos(respuesta.data);
  };

  const openModal = (op, cargo) => {
    const nombreCargo = cargo?.nombreCargo;
    const estado = cargo?.estado;
    const id = cargo?.id;
    console.log({ nombreCargo, estado, id, op });

    setEstado("");
    setOperation(op);
    if (op === 1) {
      setTitle("Registrar cargo");
      setNombreCargoActual("");
      setEstado("");
    } else if (op === 2) {
      setTitle("Editar cargo");
      setNombreCargoActual(nombreCargo);
      setEstado(estado);
      setidToEdit(id);
    }
    window.setTimeout(function () {
      document.getElementById("nombreCargo").focus();
    }, 500);
  };

  const validar = (id) => {
    var parametros;
    var metodo;

    if (NombreCargo.trim() === "") {
      show_alert("error", "Escribe el nombre del cargo");
    } else if (estado === "") {
      show_alert("error", "Escribe el estado del cargo");
    } else {
      if (operation === 1) {
        parametros = { NombreCargo: NombreCargo, estado: estado };
        metodo = "POST";
      } else {
        parametros = { NombreCargo: NombreCargo, estado: estado };
        console.log(parametros);
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
          show_alert("success", "Cargo creado");
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
          show_alert("success", "Cargo editado con exito");
          document.getElementById("btnCerrar").click();
          getJobs();
        })
        .catch(function (error) {
          show_alert("Error de solucitud", "error");
          console.log(error);
        });
    }
  };

  const deleteCargo = (cargo) => {
    const id = cargo.id;
    const name = cargo.nombreCargo;
    const MySwal = withReactContent(Swal);
    MySwal.fire({
      title: "¿Seguro quieres eliminar el cargo " + name + "?",
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
          show_alert("success", "Cargo eliminado exitosamente");
          getJobs();
        } catch (error) {
          show_alert("error", "Error al eliminar el cargo");
          console.error(error);
        }
      } else {
        show_alert("info", "El cargo no fue eliminado");
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
                      Cargos
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
                          placeholder="Filtrar por nombre de cargo"
                          value={filtro}
                          onChange={(e) => setFiltro(e.target.value)}
                          className="form-control"
                        />
                        <button
                          onClick={() => openModal(1)}
                          className="btn btn-primary"
                          data-bs-toggle="modal"
                          data-bs-target="#modalCargos"
                        >
                          <i className="fa-solid fa-circle-plus"></i> Añadir
                          cargo
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
                      {cargos.length > 0 && (
                        <Table
                          header={[...Object.keys(cargos[0]), "Acciones"]}
                          data={cargos}
                          onRemove={(item) => deleteCargo(item)}
                          modalId={"modalCargos"}
                          filtroCampos={["nombreCargo"]}
                          filtro={filtro}
                          onUpdate={(payload) => openModal(2, payload)}
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
      <div id="modalCargos" className="modal fade" aria-hidden="true">
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
                  id="nombreCargo"
                  className="form-control"
                  placeholder="Nombre"
                  value={NombreCargo}
                  onChange={(e) => setNombreCargoActual(e.target.value)}
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
                  value={estado}
                  onChange={(e) => setEstado(e.target.value)}
                ></input>
              </div>
              <div className="d-grid col-6 mx-auto">
                <button
                  onClick={() => validar(idToEdit, NombreCargo)}
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
    </div>
  );
};

export default ShowJobs;
