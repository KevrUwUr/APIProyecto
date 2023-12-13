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

const ShowLoses = () => {
  const url = "http://localhost:5089/api/perdidas/";
  const urle = "http://localhost:5089/api/empleados/";
  const [idEmpleadoSeleccionado, setIdEmpleadoSeleccionado] = useState("");
  const [perdidas, SetPerdidas] = useState([]);
  const [empleados, setEmpleados] = useState([]);
  const [fechaPerdida, setFecha] = useState("");
  const [estado, setEstado] = useState("");
  const [total, setTotal] = useState("");
  const [empleadoId, setIdEmpleado] = useState([1]);
  const [operation, setOperation] = useState(1);
  const [title, setTitle] = useState("");
  const [idToEdit, setidToEdit] = useState(null);
  const [filtro, setFiltro] = useState("");

  useEffect(() => {
    getLoses();
    getEmployees();
  }, []);

  const getLoses = async () => {
    try {
      const respuesta = await axios.get(url);
      SetPerdidas(respuesta.data);
    } catch (error) {
      console.error("Error al obtener las pérdidas: ", error);
    }
  };

  const getEmployees = async () => {
    const respuesta = await axios.get(urle);
    setEmpleados(respuesta.data);
  };

  const openModal = (op, perdida) => {
    const fechaPerdida = perdida?.fechaPerdida;
    const estado = perdida?.estado;
    const total = perdida?.total;
    const idPerdida = perdida?.idPerdida;
    setOperation(op);
    if (op === 1) {
      setTitle("Registrar pérdida");
      setFecha("");
      setEstado("");
      setTotal("");
      setIdEmpleado("");
    } else if (op === 2) {
      setTitle("Editar pérdida");
      setFecha(fechaPerdida);
      setEstado(estado);
      setTotal(total);
      setidToEdit(idPerdida);
      setIdEmpleado(empleadoId);
    }
    window.setTimeout(function () {
      document.getElementById("estado").focus();
    }, 500);
  };

  const validar = (id) => {
    var parametros;
    var metodo;

    if (fechaPerdida === "") {
      show_alert("error", "Escribe la fecha de la pérdida");
    } else if (estado === "") {
      show_alert("error", "Escribe el estado de la pérdida");
    } else if (total === "") {
      show_alert("error", "Escribe el total de la pérdida");
    } else if (empleadoId) {
      // Corregir esta línea
      show_alert("error", "Selecciona un empleado");
    } else {
      if (operation === 1) {
        parametros = {
          fechaPerdida: fechaPerdida,
          estado: estado,
          total: total,
          empleadoId: empleadoId,
        };
        metodo = "POST";
      } else {
        parametros = {
          fechaPerdida: fechaPerdida,
          estado: estado,
          total: total,
          empleadoId: empleadoId,
        };
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
          show_alert("success", "Perdida creada");
          document.getElementById("btnCerrar").click();
          getLoses();
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
          show_alert("success", "Perdida editada con exito");
          document.getElementById("btnCerrar").click();
          getLoses();
        })
        .catch(function (error) {
          show_alert("Error de solucitud", "error");
          console.log(error);
        });
    }
  };

  const deletePerdida = (perdida) => {
    const idPerdida = perdida.idPerdida;
    const name = perdida.idPerdida;

    const MySwal = withReactContent(Swal);
    MySwal.fire({
      title: `¿Seguro quieres eliminar la pérdida ${name}?`,
      icon: "question",
      text: "No se podrá dar marcha atrás",
      showCancelButton: true,
      confirmButtonText: "Si, eliminar",
      cancelButtonText: "Cancelar",
    }).then(async (result) => {
      if (result.isConfirmed) {
        try {
          await axios.delete(`${url}${idPerdida}`);
          show_alert("success", "Pérdida eliminada exitosamente");
          getLoses();
        } catch (error) {
          show_alert("error", "Error al eliminar la pérdida");
          console.error("Error al eliminar la pérdida: ", error);
        }
      } else {
        show_alert("info", "La pérdida no fue eliminada");
      }
    });
  };

  return (
    <div className="App">
      <div className="wrapper">
        <Sidebar/>
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
                      Perdidas
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
                          type="date"
                          placeholder="Filtrar por nombre de cargo"
                          value={filtro}
                          onChange={(e) => setFiltro(e.target.value)}
                          className="form-control"
                        />
                        <hr/>
                        <button
                          onClick={() => openModal(1)}
                          className="btn btn-primary mt-3"
                          data-bs-toggle="modal"
                          data-bs-target="#modalCargos"
                        >
                          
                          <i className="fa-solid fa-circle-plus"></i> Añadir
                          perdida
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
                      {perdidas.length > 0 && (
                        <Table
                          header={[...Object.keys(perdidas[0]), "Acciones"]}
                          data={perdidas}
                          onRemove={(item) => deletePerdida(item)}
                          modalId={"modalPerdidas"}
                          filtroCampos={["fechaPerdida"]}
                          filtro={filtro}
                          onUpdate={(payload) => openModal(2, payload)}
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

      <div id="modalPerdidas" className="modal fade" aria-hidden="true">
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
              <input type="hidden" id="idPerdida"></input>
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
                  value={estado}
                  onChange={(e) => setEstado(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-calendar"></i>
                </span>
                <input
                  type="date"
                  id="fechaPerdida"
                  className="form-control"
                  placeholder="Fecha"
                  value={fechaPerdida}
                  onChange={(e) => setFecha(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-credit-card-alt"></i>
                </span>
                <input
                  type="number"
                  id="total"
                  className="form-control"
                  placeholder="Total"
                  value={total}
                  onChange={(e) => setTotal(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  <i className="fa fa-product-hunt"></i>
                </span>
                <select
                  id="categoria"
                  className="form-control"
                  value={idEmpleadoSeleccionado}
                  onChange={(e) => setIdEmpleadoSeleccionado(e.target.value)}
                >
                  <option value="" disabled>
                    Selecciona un empleado
                  </option>
                  {empleados.map((empleado) => (
                    <option
                      key={empleado.empleadoId}
                      value={empleado.empleadoId}
                    >
                      {empleado.nombres}
                    </option>
                  ))}
                </select>
              </div>
              <div className="d-grid col-6 mx-auto">
                <button
                  onClick={() => validar(idToEdit, fechaPerdida)}
                  className="btn btn-success"
                  id="Boton"
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

export default ShowLoses;
