import React from "react";
import ReCaptcha from "../assets/img/no-soy-un-robot-captcha.gif";
import "../assets/css/Index.css";
import "../assets/css/Sign-Up-Form---Gabriela-Carvalho.css";
import Navbar from "./Navbar";
import Footer from "./Footer";

const Registrarse = () => {
  return (
    <div className="App">
      <body style={{ background: "#f9f5eb" }}>
        <Navbar/>
        <form
          action="/action_page.php"
          style={{
            width: "95%",
            margin: "0px",
            marginLeft: "40px",
            borderWidth: "0px",
            background: "rgba(46,77,113,0.17)",
            marginTop: "22px",
            marginBottom: "22px",
          }}
        >
          <div
            className="gc004-container"
            style={{
              borderStyle: "none",
              borderColor: "rgba(33,37,41,0)",
              background: "#e4dccf",
            }}
          >
            <h1
              style={{ fontFamily: "ABeeZee, sans-serif", fontWeight: "bold" }}
            >
              Registrarse
            </h1>
            <p style={{ fontFamily: "ABeeZee, sans-serif" }}>
              Por favor, llena estos campos para llevar a cabo el proceso de
              registro
            </p>
            <hr />
            <div className="container">
              <div className="row">
                <div className="col-md-6">
                  <label
                    className="form-label fw-bold"
                    htmlFor="email"
                    style={{ fontFamily: "ABeeZee, sans-serif" }}
                  >
                    Usuario
                  </label>
                  <input
                    type="text"
                    placeholder="Introduce tu usuario"
                    name="usuario"
                    required=""
                  />
                </div>
                <div className="col-md-6">
                  <button
                    className="btn btn-danger"
                    type="button"
                    style={{
                      width: "40%",
                      marginTop: "40px",
                      marginLeft: "160px",
                      fontFamily: "ABeeZee, sans-serif",
                    }}
                  >
                    Verificar
                  </button>
                </div>
              </div>
            </div>
            <div className="container">
              <div className="row">
                <div className="col-md-6 justify-content-center align-items-center align-content-center align-self-center">
                  <form>
                    <label
                      className="form-label mb-0"
                      htmlFor="float-input"
                      style={{ fontFamily: "ABeeZee, sans-serif" }}
                    >
                      Tipo de documento
                    </label>
                    <select className="form-select">
                      <option value="0" selected="">
                        Selecciona una opción
                      </option>
                      <option value="1">Tarjeta de identidad</option>
                      <option value="2">Cédula de ciudadanía</option>
                      <option value="3">Cédula de extranjería</option>
                      <option value="4">Permiso único de permanencia</option>
                    </select>
                  </form>
                </div>
                <div className="col-md-6">
                  <label
                    className="form-label fw-bold"
                    htmlFor="documentoCliente"
                    style={{ fontFamily: "ABeeZee, sans-serif" }}
                  >
                    Documento
                  </label>
                  <input
                    type="text"
                    placeholder="Introduce tu documento"
                    name="documentoUsuario"
                    required=""
                  />
                </div>
              </div>
              <div className="row">
                <div className="col-md-6 justify-content-center align-items-center align-content-center align-self-center">
                  <label
                    className="form-label fw-bold"
                    htmlFor="documentoCliente"
                    style={{ fontFamily: "ABeeZee, sans-serif" }}
                  >
                    Nombre
                  </label>
                  <input
                    type="text"
                    placeholder="Introduce tu nombre"
                    name="nombreUsuario"
                    required=""
                  />
                </div>
                <div className="col-md-6">
                  <label
                    className="form-label fw-bold"
                    htmlFor="direccionCliente"
                    style={{ fontFamily: "ABeeZee, sans-serif" }}
                  >
                    Dirección
                  </label>
                  <input
                    type="text"
                    placeholder="Introduce tu dirección"
                    name="direccionUsuario"
                    required=""
                  />
                </div>
              </div>
              <div className="row">
                <div className="col-md-6 justify-content-center align-items-center align-content-center align-self-center">
                  <label
                    className="form-label fw-bold"
                    htmlFor="documentoCliente"
                    style={{ fontFamily: "ABeeZee, sans-serif" }}
                  >
                    Teléfono
                  </label>
                  <input
                    type="text"
                    placeholder="Introduce tu teléfono"
                    name="nombreUsuario"
                    required=""
                  />
                </div>
                <div className="col-md-6"></div>
              </div>
              <div className="row">
                <div className="col-md-6">
                  <label
                    className="form-label fw-bold"
                    htmlFor="email"
                    style={{ fontFamily: "ABeeZee, sans-serif" }}
                  >
                    Correo
                  </label>
                  <input
                    type="text"
                    placeholder="Introduce tu correo"
                    name="email"
                    required=""
                  />
                </div>
                <div className="col-md-6">
                  <button
                    className="btn btn-danger"
                    type="button"
                    style={{
                      width: "40%",
                      marginTop: "40px",
                      marginLeft: "160px",
                      fontFamily: "ABeeZee, sans-serif",
                    }}
                  >
                    Verificar
                  </button>
                </div>
              </div>
              <div className="row">
                <div className="col-md-6 justify-content-center align-items-center align-content-center align-self-center">
                  <label
                    className="form-label fw-bold"
                    htmlFor="documentoCliente"
                    style={{ fontFamily: "ABeeZee, sans-serif" }}
                  >
                    Contraseña
                  </label>
                  <input
                    type="text"
                    placeholder="Introduce tu contraseña"
                    name="contraseñaUsuario"
                    required=""
                  />
                </div>
                <div className="col-md-6">
                  <label
                    className="form-label fw-bold"
                    htmlFor="documentoCliente"
                    style={{ fontFamily: "ABeeZee, sans-serif" }}
                  >
                    Confirmar contraseña
                  </label>
                  <input
                    type="text"
                    placeholder="Introduce tu contraseña de nuevo"
                    name="contraseñaUsuario"
                    required=""
                  />
                </div>
              </div>
            </div>
            <div className="col">
              <div className="container">
                <div className="row">
                  <div className="col-md-6">
                    <img alt="Captcha" src={ReCaptcha} width="230" height="115" />
                  </div>
                  <div className="col-md-6"></div>
                </div>
                <div className="row">
                  <div className="col-md-6">
                    <div className="form-check">
                      <input
                        className="form-check-input"
                        type="checkbox"
                        id="formCheck-1"
                        checked="checked"
                        name="remember"
                        style={{ marginBottom: "15px" }}
                      />
                      <label
                        className="form-check-label"
                        htmlFor="formCheck-1"
                        style={{ fontFamily: "ABeeZee, sans-serif" }}
                      >
                        Recuérdame
                      </label>
                    </div>
                    <p style={{ fontFamily: "ABeeZee, sans-serif" }}>
                      Al crear una cuenta, aceptas nuestros{" "}
                      <a className="gc004-dodgerblue" href="/">
                        Términos y privacidad
                      </a>
                      .
                    </p>
                  </div>
                  <div className="col-md-6"></div>
                </div>
              </div>
            </div>
            <div className="gc-clearfix">
              <button
                className="gc-cancelbtn"
                type="button"
                style={{ fontFamily: "ABeeZee, sans-serif" }}
              >
                Cancelar
              </button>
              <a
                role="button"
                className="gc-signupbtn"
                style={{
                  fontFamily: "ABeeZee, sans-serif",
                  textAlign: "center",
                }}
                href="./LogIn.js"
              >
                Registrarse
              </a>
            </div>
          </div>
        </form>
        <Footer/>
      </body>
    </div>
  );
};

export default Registrarse;
