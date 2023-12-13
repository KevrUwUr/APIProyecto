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

const ShowProducts = () => {
  const url = "http://localhost:5089/api/productos/";
  const urlc = "http://localhost:5089/api/categorias";

  const [productos, setProductos] = useState([]);
  const [categorias, setCategorias] = useState([]);
  const [idCategoriaSeleccionada, setIdCategoriaSeleccionada] = useState("");
  const [nombre, setNombre] = useState("");
  const [precio, setPrecio] = useState();
  const [stock, setStock] = useState();
  const [descripcion, setDescripcion] = useState();
  const [estado, setEstado] = useState();
  const [color, setColor] = useState();
  const [tipo, setTipo] = useState();
  const [origenMateriaPrima, setOMP] = useState();
  const [idCategoria, setCategoriaId] = useState([1]);
  const [operation, setOperation] = useState([1]);
  const [title, setTitle] = useState();
  const URL = `http://localhost:5089/api/categorias/${idCategoriaSeleccionada}/productos/`;
  const [idToEdit, SetidToEdit] = useState(null);
  const [filtro, setFiltro] = useState("");

  useEffect(() => {
    getProducts();
    getCategories();
  }, []);

  const getProducts = async () => {
    const respuesta = await axios.get(url);
    setProductos(respuesta.data);
  };

  const getCategories = async () => {
    const respuestaC = await axios.get(urlc);
    setCategorias(respuestaC.data);
  };

  const openModal = (op, producto) => {
    const nombre = producto?.nombre;
    const precio = producto?.precio;
    const stock = producto?.stock;
    const descripcion = producto?.descripcion;
    const estado = producto?.estado;
    const color = producto?.color;
    const tipo = producto?.tipo;
    const origenMateriaPrima = producto?.origenMateriaPrima;
    const id = producto?.productoId;
    setEstado("");
    setOperation(op);
    if (op === 1) {
      setTitle("Registrar producto");
      setNombre("");
      setPrecio("");
      setStock("");
      setDescripcion("");
      setEstado("");
      setColor("");
      setTipo("");
      setOMP("");
      setCategoriaId("");
    } else if (op === 2) {
      setTitle("Editar producto");
      setNombre(nombre);
      setPrecio(precio);
      setStock(stock);
      setDescripcion(descripcion);
      setEstado(estado);
      setColor(color);
      setTipo(tipo);
      setOMP(origenMateriaPrima);
      SetidToEdit(id);
      setCategoriaId(idCategoria);
    }
    window.setTimeout(function () {
      document.getElementById("nombre").focus();
    }, 500);
  };

  const validar = (id) => {
    var parametros;
    var metodo;

    if (nombre.trim() === "") {
      show_alert("error", "Escribe el nombre del producto");
    } else if (precio === "") {
      show_alert("error", "Escribe el precio del producto");
    } else if (stock === "") {
      show_alert("error", "Escribe el stock del producto");
    } else if (descripcion === "") {
      show_alert("error", "Escribe la descripcion del producto");
    } else if (estado === "") {
      show_alert("error", "Escribe el estado del producto");
    } else if (color === "") {
      show_alert("error", "Escribe el color del producto");
    } else if (tipo === "") {
      show_alert("error", "Escribe el tipo del producto");
    } else {
      if (operation === 1) {
        parametros = {
          nombre: nombre,
          precio: precio,
          stock: stock,
          descripcion: descripcion,
          estado: estado,
          color: color,
          tipo: tipo,
          origenMateriaPrima: origenMateriaPrima,
          idCategoria: idCategoriaSeleccionada,
        };

        metodo = "POST";
      } else {
        parametros = {
          nombre: nombre,
          precio: precio,
          stock: stock,
          descripcion: descripcion,
          estado: estado,
          color: color,
          tipo: tipo,
          origenMateriaPrima: origenMateriaPrima,
          idCategoria: idCategoriaSeleccionada,
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
        .post(`${URL}`, parametros)
        .then(function (respuesta) {
          show_alert("success", "Producto creado");
          document.getElementById("btnCerrar").click();
          getProducts();
        })
        .catch(function (error) {
          show_alert("error", "Error de solucitud");
          console.log(error);
        });
    } else if (metodo === "PUT") {
      axios
        .put(`${URL}${id}`, parametros)
        .then(function (respuesta) {
          console.log("Solicitud PUT exitosa:", respuesta.data);
          show_alert("success", "Producto editado con exito");
          document.getElementById("btnCerrar").click();
          getProducts();
        })
        .catch(function (error) {
          show_alert("error", "El producto no se edito");
          console.log(error);
        });
    }
  };

  const deleteProducto = (producto) => {
    const id = producto.productoId;
    const name = producto.nombre;
    const MySwal = withReactContent(Swal);
    MySwal.fire({
      title: "¿Seguro quieres eliminar el producto " + name + "?",
      icon: "question",
      text: "No se podra dar marcha atras",
      showCancelButton: true,
      confirmButtonText: "Si, eliminar",
      cancelButtonText: "Cancelar",
    }).then(async (result) => {
      console.log(id);
      if (result.isConfirmed) {
        try {
          console.log(`${URL}/${id}`);
          await axios.delete(`${URL}${id}`);
          show_alert("success", "Producto eliminado exitosamente");
          getProducts();
        } catch (error) {
          console.log(`${URL}/${id}`);
          show_alert("error", "Error al eliminar el producto");
          console.error(error);
        }
      } else {
        show_alert("info", "El producto no fue eliminado");
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
                      Productos
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
                          placeholder="Filtrar por nombre de producto"
                          value={filtro}
                          onChange={(e) => setFiltro(e.target.value)}
                          className="form-control"
                        />
                        <button
                          onClick={() => openModal(1)}
                          className="btn btn-primary"
                          data-bs-toggle="modal"
                          data-bs-target="#modalProducto"
                        >
                          <i className="fa-solid fa-circle-plus"></i> Añadir
                          producto
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
                      {productos.length > 0 && (
                        <Table
                          header={[...Object.keys(productos[0]), "Acciones"]}
                          data={productos}
                          onRemove={(item) => deleteProducto(item)}
                          modalId={"modalProducto"}
                          filtroCampos={["nombre"]}
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

      <div id="modalProducto" className="modal fade" aria-hidden="true">
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
                  id="nombre"
                  className="form-control"
                  placeholder="Nombre"
                  value={nombre}
                  onChange={(e) => setNombre(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-credit-card-alt"></i>
                </span>
                <input
                  type="number"
                  id="precio"
                  className="form-control"
                  placeholder="Precio"
                  value={precio}
                  onChange={(e) => setPrecio(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-truck"></i>
                </span>
                <input
                  type="number"
                  id="stock"
                  className="form-control"
                  placeholder="stock"
                  value={stock}
                  onChange={(e) => setStock(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-file-text"></i>
                </span>
                <input
                  type="text"
                  id="descripcion"
                  className="form-control"
                  placeholder="descripcion"
                  value={descripcion}
                  onChange={(e) => setDescripcion(e.target.value)}
                ></input>
              </div>
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
                  <i className="fa fa-paint-brush"></i>
                </span>
                <input
                  type="text"
                  id="color"
                  className="form-control"
                  placeholder="Color"
                  value={color}
                  onChange={(e) => setColor(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  {" "}
                  <i className="fa fa-compress"></i>
                </span>
                <input
                  type="number"
                  id="tipo"
                  className="form-control"
                  placeholder="Tipo"
                  value={tipo}
                  onChange={(e) => setTipo(e.target.value)}
                ></input>
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">
                  <i className="fa fa-product-hunt"></i>
                </span>
                <select
                  id="categoria"
                  className="form-control"
                  value={idCategoriaSeleccionada}
                  onChange={(e) => setIdCategoriaSeleccionada(e.target.value)}
                >
                  <option value="" disabled>
                    Selecciona una categoría
                  </option>
                  {categorias.map((categoria) => (
                    <option key={categoria.id} value={categoria.id}>
                      {categoria.nombre}
                    </option>
                  ))}
                </select>
              </div>

              <div className="d-grid col-6 mx-auto">
                <button
                  onClick={() =>
                    validar(idToEdit, nombre, idCategoriaSeleccionada)
                  }
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

export default ShowProducts;
