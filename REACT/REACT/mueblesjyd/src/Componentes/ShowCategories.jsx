import React, { useEffect, useState } from "react";
import axios from "axios";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { show_alert } from "../Functions";
import "../assets/css/styles.css";
import Table from "./Table/index";
import Sidebar from "./Navbar/sidebar";

const ShowCategories = () => {
  const url = "http://localhost:5089/api/categorias/";
  const [categorias, setCategorias] = useState([]);
  const [nombre, setNombre] = useState("");
  const [estado, setEstado] = useState();
  const [operation, setOperation] = useState([1]);
  const [title, setTitle] = useState();
  const [idToEdit, setidToEdit] = useState(null);
  const [filtro, setFiltro] = useState("");

  useEffect(() => {
    getCategories();
  }, []);

  const getCategories = async () => {
    const respuesta = await axios.get(url);
    setCategorias(respuesta.data);
  };

  const openModal = (op, categoria) => {
    const nombre = categoria?.nombre;
    const estado = categoria?.estado;
    const id = categoria?.id;
    console.log({ nombre, estado, id, op });

    setEstado("");
    setOperation(op);
    if (op === 1) {
      setTitle("Registrar categoria");
      setNombre("");
      setEstado("");
    } else if (op === 2) {
      setTitle("Editar categoria");
      setNombre(nombre);
      setEstado(estado);
      setidToEdit(id);
    }
    window.setTimeout(function () {
      document.getElementById("nombreCategoria").focus();
    }, 500);
  };

  const validar = (id) => {
    var parametros;
    var metodo;

    if (nombre.trim() === "") {
      show_alert("error", "Escribe el nombre del categoria");
    } else if (estado === "") {
      show_alert("error", "Escribe el estado del categoria");
    } else {
      if (operation === 1) {
        parametros = { nombre: nombre, estado: estado };
        metodo = "POST";
      } else {
        parametros = { nombre: nombre, estado: estado };
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
          show_alert("success", "Categoria creado");
          document.getElementById("btnCerrar").click();
          getCategories();
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

          show_alert("success", "Categoria editado con exito");
          document.getElementById("btnCerrar").click();
          getCategories();
        })
        .catch(function (error) {
          show_alert("Error de solucitud", "error");
          console.log(error);
        });
    }
  };

  const deleteCategoria = (categoria) => {
    const id = categoria.id;
    const name = categoria.nombre;
    const MySwal = withReactContent(Swal);
    MySwal.fire({
      title: "¿Seguro quieres eliminar la categoria " + name + "?",
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
          show_alert("success", "Categoria eliminada exitosamente");
          getCategories();
        } catch (error) {
          show_alert("error", "Error al eliminar la categoria");
          console.error(error);
        }
      } else {
        show_alert("info", "La categoria no fue eliminada");
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
                      Categorias
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
                          placeholder="Filtrar por nombre de categoria"
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
                          categoria
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
                      {categorias.length > 0 && (
                        <Table
                          header={[...Object.keys(categorias[0]), "Acciones"]}
                          data={categorias}
                          onRemove={(item) => deleteCategoria(item)}
                          modalId={"modalCategorias"}
                          filtroCampos={["nombre"]}
                          filtro={filtro} 
                          onUpdate={(payload) => openModal(2, payload)}
                        />
                      )}
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div
                    className="col-12 col-sm-6 col-md-6 text-end d-xl-flex justify-content-xl-center align-items-xl-center"
                    style={{ marginBottom: 30 }}
                  ></div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div id="modalCategorias" className="modal fade" aria-hidden="true">
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
                  id="nombreCategoria"
                  className="form-control"
                  placeholder="Nombre"
                  value={nombre}
                  onChange={(e) => setNombre(e.target.value)}
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
                  onClick={() => validar(idToEdit, nombre)}
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

export default ShowCategories;
