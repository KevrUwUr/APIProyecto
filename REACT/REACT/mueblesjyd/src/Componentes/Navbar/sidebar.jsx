import React from "react";
import Logo from "../../assets/img/Logo.png";
import ImagenBarra from "../../assets/img/sidebar-2.jpg";

const Sidebar = () => {
  return (
    <div className="App">
      <div
        className="sidebar"
        data-color="blue"
        data-image
        style={{ backgroundImage: `url(${ImagenBarra})` }}
      >
        <div className="sidebar-wrapper">
          <div className="logo" style={{ width: "100%" }}>
            <a className="simple-text" href="/Admin">
              <img src={Logo} alt="Logo" width={93} height={49} />
            </a>
          </div>
          <ul className="nav">
            <li>
              <a
                href="/cargos"
                style={{ width: "100%", textDecoration: "none" }}
              >
                <i className="fas fa-briefcase" />
                <p>Cargos</p>
              </a>
            </li>
            <li>
              <a
                href="/categorias"
                style={{ width: "100%", textDecoration: "none" }}
              >
                <i className="fas fa-th-large" />
                <p>Categorías</p>
              </a>
            </li>
            <li>
              <a
                href="/empleados"
                style={{ width: "100%", textDecoration: "none" }}
              >
                <i className="fas fa-user-secret" />
                <p>Empleados</p>
              </a>
            </li>
            <li>
              <a
                href="/facturas/compras"
                style={{ width: "100%", textDecoration: "none" }}
              >
                <i className="fas fa-file-invoice-dollar" />
                <p>Facturas de compra</p>
              </a>
            </li>
            <li>
              <a
                href="/facturas/ventas"
                style={{ width: "100%", textDecoration: "none" }}
              >
                <i className="fas fa-file-invoice" />
                <p>Facturas de venta</p>
              </a>
            </li>
            <li>
              <a
                href="/perdidas"
                style={{ width: "100%", textDecoration: "none" }}
              >
                <i className="fas fa-sort-amount-desc" />
                <p>Pérdidas</p>
              </a>
            </li>
            <li>
              <a
                href="/productos"
                style={{ width: "100%", textDecoration: "none" }}
              >
                <i className="fas fa-shopping-basket" />
                <p>Productos</p>
              </a>
            </li>
            <li>
              <a
                href="/proveedores"
                style={{ width: "100%", textDecoration: "none" }}
              >
                <i className="fas fa-user" />
                <p>Proveedores</p>
              </a>
            </li>
            <li>
              <a
                href="/usuarios"
                style={{ width: "100%", textDecoration: "none" }}
              >
                <i className="fas fa-users" />
                <p>Usuarios</p>
              </a>
            </li>
          </ul>
        </div>
      </div>
    </div>
  );
};

export default Sidebar;
