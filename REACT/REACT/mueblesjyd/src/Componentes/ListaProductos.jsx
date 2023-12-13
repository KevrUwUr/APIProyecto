import React, { useState, useEffect } from "react";
import axios from "axios";
import "../assets/css/Index.css";
import Navbar from "./Navbar";
import Footer from "./Footer";
import "../assets/css/styles.css";

const ListaProductos = () => {
  const [productos, setProductos] = useState([]);
  const [loading, setLoading] = useState(true);

  const url = "http://localhost:5089/api/productos/";

  useEffect(() => {
    getProducts();
  }, []);

  const getProducts = async () => {
    try {
      const respuesta = await axios.get(url);
      setProductos(respuesta.data);
      setLoading(false);
    } catch (error) {
      console.error("Error al obtener datos:", error);
      setLoading(false);
    }
  };

  return (
    <div className="App">
      <Navbar />
      <div style={{ background: "#f9f5eb" }}>
        <div
          className="container"
          style={{
            background: "#e4dccf",
            marginTop: "20px",
            marginBottom: "20px",
          }}
        >
          <div className="row mb-5">
            <div className="col-md-8 col-xl-6 text-center mx-auto">
              <h2
                style={{
                  fontFamily: "ABeeZee, sans-serif",
                  fontWeight: "bold",
                }}
                className="d-flex align-items-center justify-content-center"
              >
                Catálogo
              </h2>
            </div>
          </div>
          <div className="row">
            {loading ? (
              <p>Cargando productos...</p>
            ) : (
              productos.map((producto) => (
                <div key={producto.id} className="col-md-4">
                  <div className="card">
                    <img
                      className="card-img-top"
                      src="https://cdn.bootstrapstudio.io/placeholders/1400x800.png"
                      alt={producto.nombre}
                    />
                    <div className="card-body">
                      <h5 className="card-title">{producto.nombre}</h5>
                      <p className="card-text">{producto.descripcion}</p>
                      <p className="card-text">{producto.precio} </p>
                      <a href="/Carrito" className="btn btn-primary">
                        Comprar
                      </a>
                    </div>
                  </div>
                </div>
              ))
            )}
          </div>
        </div>
        <Footer />
      </div>
    </div>
  );
};

export default ListaProductos;
