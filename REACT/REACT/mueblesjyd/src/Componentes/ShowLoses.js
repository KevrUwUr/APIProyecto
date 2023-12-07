import React, { useEffect, useState } from "react";
import axios from "axios";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { show_alert } from "../Functions";
import "../assets/css/styles.css";
import Logo from "../assets/img/Logo.png";

const ShowLoses = () => {
  const url = "https://localhost:7284/api/perdidas/";
  const [perdidas, SetPerdidas] = useState([]);
  const [fechaPerdida, setFecha] = useState("");
  const [estado, setEstado] = useState("");
  const [total, setTotal] = useState("");
  const [operation, setOperation] = useState(1);
  const [title, setTitle] = useState("");
  const [idToEdit, setidToEdit] = useState(null);

  useEffect(() => {
    getLoses();
  }, []);

  const getLoses = async () => {
    try {
      const respuesta = await axios.get(url);
      SetPerdidas(respuesta.data);
    } catch (error) {
      console.error("Error al obtener las pérdidas: ", error);
    }
  };

  const openModal = (op, nombreCargo, estado, total, idPerdida) => {
    setOperation(op);
    if (op === 1) {
      setTitle("Registrar pérdida");
      setFecha("");
      setEstado("");
      setTotal("");
    } else if (op === 2) {
      setTitle("Editar pérdida");
      setFecha(nombreCargo);
      setEstado(estado);
      setTotal(total);
      setidToEdit(idPerdida);
    }
    window.setTimeout(function () {
      document.getElementById("estado").focus();
    }, 500);
  };

  const validar = () => {
    if (fechaPerdida === "") {
      show_alert("error", "Escribe la fecha de la pérdida");
    } else if (estado === "") {
      show_alert("error", "Escribe el estado de la pérdida");
    } else if (total === "") {
      show_alert("error", "Escribe el total de la pérdida");
    } else {
      const parametros = { fechaPerdida, estado, total };
      const metodo = operation === 1 ? "POST" : "PUT";
      enviarSolicitud(metodo, parametros, idToEdit);
    }
  };

  const enviarSolicitud = async (metodo, parametros, idPerdida) => {
    try {
      const response =
        metodo === "POST"
          ? await axios.post(url, parametros)
          : await axios.put(`${url}${idPerdida}`, parametros);

      show_alert("success", response.data.message);
      document.getElementById("btnCerrar").click();
      getLoses();
    } catch (error) {
      show_alert("error", "Error de solicitud");
      console.error("Error al enviar la solicitud: ", error);
    }
  };

  const deletePerdida = (idPerdida, name) => {
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
      <div idPerdida="custom-container" className="d-flex">
      <nav className="navbar navbar-light navbar-expand-md py-3" style={{ width: '100%', background: '#002b5b' }}>
          <div className="container">
            <img src={Logo} alt="Logo" />
            <button className="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navcol-2">
              <span className="visually-hidden">Toggle navigation</span>
              <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" idPerdida="navcol-2" style={{ color: 'var(--bs-black)', fontSize: '20px' }}>
              <ul className="navbar-nav ms-auto">
                <li className="nav-item"><a className="nav-link active" data-bss-hover-animate="flash" href="/" style={{ color: 'var(--bs-white)', fontWeight: 'bold', fontFamily: 'ABeeZee, sans-serif' }}>Inicio</a></li>
                <li className="nav-item" data-bss-hover-animate="flash" style={{ color: 'var(--bs-white)', fontWeight: 'bold' }}><a className="nav-link" data-bss-hover-animate="flash" href="./Productos" style={{ color: 'var(--bs-white)', fontWeight: 'bold', fontFamily: 'ABeeZee, sans-serif' }}>Productos</a></li>
                <li className="nav-item" data-bss-hover-animate="flash" style={{ color: 'var(--bs-white)', fontWeight: 'bold' }}><a className="nav-link" data-bss-hover-animate="flash" href="./QuienesSomos" style={{ color: 'var(--bs-white)', fontWeight: 'bold', fontFamily: 'ABeeZee, sans-serif' }}>¿Quiénes somos?</a></li>
              </ul>
              <ul className="navbar-nav" data-bss-hover-animate="flash" style={{ color: 'var(--bs-white)', fontWeight: 'bold' }}>
                <li className="nav-item" data-bss-hover-animate="flash" style={{ color: 'var(--bs-white)', fontWeight: 'bold' }}></li>
                <li className="nav-item" data-bss-hover-animate="flash" style={{ color: 'var(--bs-white)', fontWeight: 'bold' }}><a className="nav-link" data-bss-hover-animate="flash" href="./Registrarse" style={{ color: 'var(--bs-white)', fontWeight: 'bold', fontFamily: 'ABeeZee, sans-serif' }}>Registrarse</a></li>
                <li className="nav-item" data-bss-hover-animate="flash" style={{ color: 'var(--bs-white)', fontWeight: 'bold' }}><a className="nav-link" data-bss-hover-animate="flash" href="./LogIn" style={{ color: 'var(--bs-white)', fontWeight: 'bold', fontFamily: 'ABeeZee, sans-serif' }}>Iniciar sesión</a></li>
              </ul>
            </div>
          </div>
        </nav>
      </div>

      <div className="container-fluid">
        <div className="row mt-3">
          <div className="col-md-4 offset-md-4">
            <div className="d-grid mx-auto"></div>
          </div>
        </div>

        <div className="container-fluid custom-container">
          <div className="card" idPerdida="TableSorterCard-1">
            <div className="card-header py-3 custom-card-header">
              <div className="row table-topper align-items-center">
                <div className="col-12 col-sm-5 col-md-6 text-start custom-title">
                  <h1 className="custom-title">Perdidas</h1>
                </div>
                <div className="col-12 col-sm-7 col-md-6 text-end custom-button">
                  <button
                    onClick={() => openModal(1)}
                    className="btn btn-primary"
                    data-bs-toggle="modal"
                    data-bs-target="#modalPerdidas"
                  >
                    <i className="fa-solid fa-circle-plus"></i> Añadir perdida
                  </button>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col-12">
                <div className="table-responsive custom-table-responsive">
                  <table
                    className="table table-striped table tablesorter custom-table"
                    idPerdida="ipi-table"
                  >
                    <thead>
                      <tr>
                        <th>#</th>
                        <th>Fecha</th>
                        <th>Estado</th>
                        <th>Total</th>
                        <th>Botones</th>
                      </tr>
                    </thead>
                    <tbody className="text-center">
                      {perdidas.map((perdida, i) => (
                        <tr key={perdida.idPerdida}>
                          <td>{i + 1}</td>
                          <td>{perdida.fechaPerdida.split('T')[0]}</td> {/* Convierte y formatea la fecha */}
                          <td>{perdida.estado}</td>
                          <td>{perdida.total}</td>
                          <td>
                            <button
                              className="btn btnMaterial btn-flat success semicircle"
                              data-bs-toggle="modal"
                              data-bs-target="#modalPerdidas"
                              onClick={() =>
                                openModal(
                                  2,
                                  perdida.fechaPerdida,
                                  perdida.estado,
                                  perdida.total,
                                  perdida.idPerdida
                                )
                              }
                            >
                              <i className="fa-solid fa-edit btn-editar"></i>
                            </button>
                            <button
                              onClick={() =>
                                deletePerdida(perdida.idPerdida, perdida.fechaPerdida)
                              }
                              className="btn btnMaterial btn-flat accent btnNoBorders checkboxHover"
                            >
                              <i className="fa-solid fa-trash btn-eliminar"></i>
                            </button>
                          </td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="text-center py-4 custom-background">
        <div className="container">
          <div className="row row-cols-1 row-cols-lg-3">
            <div className="col custom-color">
              <p className="my-2 custom-p">Copyright © 2023 Brand</p>
            </div>
            <div className="col custom-color">
              <ul className="list-inline my-2 custom-list">
                <li className="list-inline-item me-4 custom-list-item">
                  <div className="bs-icon-circle bs-icon-primary bs-icon">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="1em"
                      height="1em"
                      fill="currentColor"
                      viewBox="0 0 16 16"
                      className="bi bi-facebook custom-icon"
                    >
                      <path d="M16 8.049c0-4.446-3.582-8.05-8-8.05C3.58 0-.002 3.603-.002 8.05c0 4.017 2.926 7.347 6.75 7.951v-5.625h-2.03V8.05H6.75V6.275c0-2.017 1.195-3.131 3.022-3.131.876 0 1.791.157 1.791.157v1.98h-1.009c-.993 0-1.303.621-1.303 1.258v1.51h2.218l-.354 2.326H9.25V16c3.824-.604 6.75-3.934 6.75-7.951z"></path>
                    </svg>
                  </div>
                </li>
                <li className="list-inline-item me-4 custom-list-item">
                  <div className="bs-icon-circle bs-icon-primary bs-icon">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="1em"
                      height="1em"
                      fill="currentColor"
                      viewBox="0 0 16 16"
                      className="bi bi-twitter custom-icon"
                    >
                      <path d="M5.026 15c6.038 0 9.341-5.003 9.341-9.334 0-.14 0-.282-.006-.422A6.685 6.685 0 0 0 16 3.542a6.658 6.658 0 0 1-1.889.518 3.301 3.301 0 0 0 1.447-1.817 6.533 6.533 0 0 1-2.087.793A3.286 3.286 0 0 0 7.875 6.03a9.325 9.325 0 0 1-6.767-3.429 3.289 3.289 0 0 0 1.018 4.382A3.323 3.323 0 0 1 .64 6.575v.045a3.288 3.288 0 0 0 2.632 3.218 3.203 3.203 0 0 1-.865.115 3.23 3.23 0 0 1-.614-.057 3.283 3.283 0 0 0 3.067 2.277A6.588 6.588 0 0 1 .78 13.58a6.32 6.32 0 0 1-.78-.045A9.344 9.344 0 0 0 5.026 15z"></path>
                    </svg>
                  </div>
                </li>
                <li className="list-inline-item custom-list-item">
                  <div className="bs-icon-circle bs-icon-primary bs-icon">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="1em"
                      height="1em"
                      fill="currentColor"
                      viewBox="0 0 16 16"
                      className="bi bi-instagram custom-icon"
                    >
                      <path d="M8 0C5.829 0 5.556.01 4.703.048 3.85.088 3.269.222 2.76.42a3.917 3.917 0 0 0-1.417.923A3.927 3.927 0 0 0 .42 2.76C.222 3.268.087 3.85.048 4.7.01 5.555 0 5.827 0 8.001c0 2.172.01 2.444.048 3.297.04.852.174 1.433.372 1.942.205.526.478.972.923 1.417.444.445.89.719 1.416.923.51.198 1.09.333 1.942.372C5.555 15.99 5.827 16 8 16s-.01-2.445-.048-3.299c-.04-.851-.175-1.433-.372-1.941a2.47 2.47 0 0 1-.599-.919c-.28-.28-.546-.453-.92-.598-.28-.11-.704.24-1.485.276-.843.038-1.096.047-3.232.047s-2.39-.009-3.233-.047c-.78-.036-1.203-.166-1.485-.276a2.478 2.478 0 0 1-.92-.598 2.48 2.48 0 0 1-.6-.92c-.109-.281-.24-.705-.275-1.485-.038-.843-.046-1.096-.046-3.233 0-2.136.008-2.388.046-3.231.036-.78.166-1.204.276-1.486.145-.373.319-.64.599-.92.28-.28.546-.453.92-.598.282-.11.705-.24 1.485-.276.738-.034 1.024-.044 2.515-.045v.002zm4.988 1.328a.96.96 0 1 0 0 1.92.96.96 0 0 0 0-1.92zm-4.27 1.122a4.109 4.109 0 1 0 0 8.217 4.109 4.109 0 0 0 0-8.217zm0 1.441a2.667 2.667 0 1 1 0 5.334 2.667 2.667 0 0 1 0-5.334z"></path>
                    </svg>
                  </div>
                </li>
              </ul>
            </div>
            <div className="col custom-color">
              <ul className="list-inline my-2 custom-list">
                <li className="list-inline-item">
                  <p className="custom-link">Privacy Policy</p>
                </li>
                <li className="list-inline-item">
                  <p className="custom-link">Terms of Use</p>
                </li>
              </ul>
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
              <input type="hidden" idPerdida="idPerdida"></input>
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
                  id="estado"
                  className="form-control"
                  placeholder="Total"
                  value={total}
                  onChange={(e) => setTotal(e.target.value)}
                ></input>
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
                idPerdida="btnCerrar"
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
