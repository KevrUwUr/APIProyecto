import React, { useState } from "react";
import "../assets/css/Index.css";
import Navbar from "./Navbar";
import Footer from "./Footer";

const generateProductos = (quantity) => {
  const productos = [];

  for (let i = 1; i <= quantity; i++) {
    productos.push({
      id: i,
      nombre: `Producto ${i}`,
      descripcion: `Descripción del Producto ${i}`,
      precio: parseFloat((Math.random() * 100).toFixed(2)),
      imagen: "https://cdn.bootstrapstudio.io/placeholders/1400x800.png",
    });
  }

  return productos;
};

const Carrito = () => {
  const productos = generateProductos(10);
  const [carrito, setCarrito] = useState([]);
  const [total, setTotal] = useState(0);

  const agregarAlCarrito = (producto) => {
    const nuevoCarrito = [...carrito, producto];
    setCarrito(nuevoCarrito);
    const nuevoTotal = total + producto.precio;
    setTotal(nuevoTotal);
  };

  // Tasa de cambio de USD a COP (ejemplo: 1 USD = 3800 COP)
  const tasaCambio = 3800;

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
                Productos en el carrito
              </h2>
            </div>
          </div>
          <div className="row">
            {productos.map((producto) => (
              <div key={producto.id} className="col-md-4">
                <div className="card">
                  <img
                    className="card-img-top"
                    src={producto.imagen}
                    alt={producto.nombre}
                  />
                  <div className="card-body">
                    <h5 className="card-title">{producto.nombre}</h5>
                    <p className="card-text">{producto.descripcion}</p>
                    <p className="card-text">
                      Precio:{" "}
                      {new Intl.NumberFormat("es-CO", {
                        style: "currency",
                        currency: "COP",
                      }).format(producto.precio * tasaCambio)}
                    </p>
                    <button
                      onClick={() => agregarAlCarrito(producto)}
                      className="btn btn-danger"
                    >
                      Eliminar del carrito
                    </button>
                  </div>
                </div>
              </div>
            ))}
          </div>
          <div className="row mt-4">
            <div className="col-md-12">
              <h3>
                Total de todos los productos:{" "}
                {new Intl.NumberFormat("es-CO", {
                  style: "currency",
                  currency: "COP",
                }).format(total * tasaCambio)}{" "}
                COP
              </h3>
            </div>
          </div>
        </div>
      </div>
      <Footer/>
    </div>
  );
};

export default Carrito;
