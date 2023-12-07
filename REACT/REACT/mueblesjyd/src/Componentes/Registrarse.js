import React, { useEffect, useState } from "react";
import axios from "axios";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { show_alert } from "../Functions";
import Logo from "../assets/img/Logo.png";
import ReCaptcha from "../assets/img/no-soy-un-robot-captcha.gif";
import "../assets/css/Index.css";
import "../assets/css/Sign-Up-Form---Gabriela-Carvalho.css";

const Registrarse = () => {
  return (
    <div className="App">
      <body style={{ background: '#f9f5eb' }}>
      <header className="d-flex" style={{ background: 'rgba(67,64,64,0.54)' }}>
      <nav className="navbar navbar-light navbar-expand-md py-3" style={{ width: '100%', background: '#002b5b' }}>
          <div className="container">
            <img src={Logo} alt="Logo" />
            <button className="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navcol-2">
              <span className="visually-hidden">Toggle navigation</span>
              <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" id="navcol-2" style={{ color: 'var(--bs-black)', fontSize: '20px' }}>
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
      </header>
      <form action="/action_page.php" style={{ width: '95%', margin: '0px', marginLeft: '40px', borderWidth: '0px', background: 'rgba(46,77,113,0.17)', marginTop: '22px', marginBottom: '22px' }}>
        <div className="gc004-container" style={{ borderStyle: 'none', borderColor: 'rgba(33,37,41,0)', background: '#e4dccf' }}>
          <h1 style={{ fontFamily: 'ABeeZee, sans-serif', fontWeight: 'bold' }}>Registrarse</h1>
          <p style={{ fontFamily: 'ABeeZee, sans-serif' }}>Por favor, llena estos campos para llevar a cabo el proceso de registro</p>
          <hr />
          <div className="container">
            <div className="row">
              <div className="col-md-6"><label className="form-label fw-bold" htmlFor="email" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Usuario</label><input type="text" placeholder="Introduce tu usuario" name="usuario" required="" /></div>
              <div className="col-md-6"><button className="btn btn-danger" type="button" style={{ width: '40%', marginTop: '40px', marginLeft: '160px', fontFamily: 'ABeeZee, sans-serif' }}>Verificar</button></div>
            </div>
          </div>
          <div className="container">
            <div className="row">
              <div className="col-md-6 justify-content-center align-items-center align-content-center align-self-center">
                <form><label className="form-label mb-0" htmlFor="float-input" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Tipo de documento</label><select className="form-select">
                  <option value="0" selected="">Selecciona una opción</option>
                  <option value="1">Tarjeta de identidad</option>
                  <option value="2">Cédula de ciudadanía</option>
                  <option value="3">Cédula de extranjería</option>
                  <option value="4">Permiso único de permanencia</option>
                </select></form>
              </div>
              <div className="col-md-6"><label className="form-label fw-bold" htmlFor="documentoCliente" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Documento</label><input type="text" placeholder="Introduce tu documento" name="documentoUsuario" required="" /></div>
            </div>
            <div className="row">
              <div className="col-md-6 justify-content-center align-items-center align-content-center align-self-center"><label className="form-label fw-bold" htmlFor="documentoCliente" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Nombre</label><input type="text" placeholder="Introduce tu nombre" name="nombreUsuario" required="" /></div>
              <div className="col-md-6"><label className="form-label fw-bold" htmlFor="direccionCliente" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Dirección</label><input type="text" placeholder="Introduce tu dirección" name="direccionUsuario" required="" /></div>
            </div>
            <div className="row">
              <div className="col-md-6 justify-content-center align-items-center align-content-center align-self-center"><label className="form-label fw-bold" htmlFor="documentoCliente" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Teléfono</label><input type="text" placeholder="Introduce tu teléfono" name="nombreUsuario" required="" /></div>
              <div className="col-md-6"></div>
            </div>
            <div className="row">
              <div className="col-md-6"><label className="form-label fw-bold" htmlFor="email" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Correo</label><input type="text" placeholder="Introduce tu correo" name="email" required="" /></div>
              <div className="col-md-6"><button className="btn btn-danger" type="button" style={{ width: '40%', marginTop: '40px', marginLeft: '160px', fontFamily: 'ABeeZee, sans-serif' }}>Verificar</button></div>
            </div>
            <div className="row">
              <div className="col-md-6 justify-content-center align-items-center align-content-center align-self-center"><label className="form-label fw-bold" htmlFor="documentoCliente" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Contraseña</label><input type="text" placeholder="Introduce tu contraseña" name="contraseñaUsuario" required="" /></div>
              <div className="col-md-6"><label className="form-label fw-bold" htmlFor="documentoCliente" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Confirmar contraseña</label><input type="text" placeholder="Introduce tu contraseña de nuevo" name="contraseñaUsuario" required="" /></div>
            </div>
          </div>
          <div className="col">
            <div className="container">
              <div className="row">
                <div className="col-md-6"><img src={ReCaptcha} width="230" height="115" /></div>
                <div className="col-md-6"></div>
              </div>
              <div className="row">
                <div className="col-md-6">
                  <div className="form-check"><input className="form-check-input" type="checkbox" id="formCheck-1" checked="checked" name="remember" style={{ marginBottom: '15px' }} /><label className="form-check-label" htmlFor="formCheck-1" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Recuérdame</label></div>
                  <p style={{ fontFamily: 'ABeeZee, sans-serif' }}>Al crear una cuenta, aceptas nuestros <a className="gc004-dodgerblue" href="#">Términos y privacidad</a>.</p>
                </div>
                <div className="col-md-6"></div>
              </div>
            </div>
          </div>
          <div className="gc-clearfix"><button className="gc-cancelbtn" type="button" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Cancelar</button><a role="button" className="gc-signupbtn" style={{ fontFamily: 'ABeeZee, sans-serif', textAlign: 'center' }} href="./LogIn.js">Registrarse</a></div>
        </div>
      </form>
      <footer className="text-center py-4" style={{ background: '#ea5455' }}>
        <div className="container">
          <div className="row row-cols-1 row-cols-lg-3">
            <div className="col" style={{ color: '#000000' }}>
              <p className="my-2" style={{ color: '#000000', fontFamily: 'ABeeZee, sans-serif', filter: 'brightness(200%) contrast(200%) grayscale(100%) hue-rotate(0deg) saturate(68%) sepia(100%)' }}>Copyright © 2023 Brand</p>
            </div>
            <div className="col" style={{ color: '#000000' }}>
              <ul className="list-inline my-2" style={{ color: '#000000' }}>
                <li className="list-inline-item me-4" style={{ color: '#000000' }}>
                  <div className="bs-icon-circle bs-icon-primary bs-icon" style={{ color: '#000000' }}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" fill="currentColor" viewBox="0 0 16 16" className="bi bi-facebook" style={{ color: '#000000' }}>
                      <path d="M16 8.049c0-4.446-3.582-8.05-8-8.05C3.58 0-.002 3.603-.002 8.05c0 4.017 2.926 7.347 6.75 7.951v-5.625h-2.03V8.05H6.75V6.275c0-2.017 1.195-3.131 3.022-3.131.876 0 1.791.157 1.791.157v1.98h-1.009c-.993 0-1.303.621-1.303 1.258v1.51h2.218l-.354 2.326H9.25V16c3.824-.604 6.75-3.934 6.75-7.951z" />
                    </svg>
                  </div>
                </li>
                <li className="list-inline-item me-4" style={{ color: '#000000' }}>
                  <div className="bs-icon-circle bs-icon-primary bs-icon" style={{ color: '#000000' }}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" fill="currentColor" viewBox="0 0 16 16" className="bi bi-twitter" style={{ color: '#000000' }}>
                      <path d="M5.026 15c6.038 0 9.341-5.003 9.341-9.334 0-.14 0-.282-.006-.422A6.685 6.685 0 0 0 16 3.542a6.658 6.658 0 0 1-1.889.518 3.301 3.301 0 0 0 1.447-1.817 6.533 6.533 0 0 1-2.087.793A3.286 3.286 0 0 0 7.875 6.03a9.325 9.325 0 0 1-6.767-3.429 3.289 3.289 0 0 0 1.018 4.382A3.323 3.323 0 0 1 .64 6.575v.045a3.288 3.288 0 0 0 2.632 3.218 3.203 3.203 0 0 1-.865.115 3.23 3.23 0 0 1-.614-.057 3.283 3.283 0 0 0 3.067 2.277A6.588 6.588 0 0 1 .78 13.58a6.32 6.32 0 0 1-.78-.045A9.344 9.344 0 0 0 5.026 15z" />
                    </svg>
                  </div>
                </li>
                <li className="list-inline-item" style={{ color: '#000000' }}>
                  <div className="bs-icon-circle bs-icon-primary bs-icon" style={{ color: '#000000' }}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" fill="currentColor" viewBox="0 0 16 16" className="bi bi-instagram" style={{ color: '#000000' }}>
                      <path d="M8 0C5.829 0 5.556.01 4.703.048 3.85.088 3.269.222 2.76.42a3.917 3.917 0 0 0-1.417.923A3.927 3.927 0 0 0 .42 2.76C.222 3.268.087 3.85.048 4.7.01 5.555 0 5.827 0 8.001c0 2.172.01 2.444.048 3.297.04.852.174 1.433.372 1.942.205.526.478.972.923 1.417.444.445.89.719 1.416.923.51.198 1.09.333 1.942.372C5.555 15.99 5.827 16 8 16s2.444-.01 3.298-.048c.851-.04 1.434-.174 1.943-.372a3.916 3.916 0 0 0 1.416-.923c.445-.445.718-.891.923-1.417.197-.509.332-1.09.372-1.942C15.99 10.445 16 10.173 16 8s-.01-2.445-.048-3.299c-.04-.851-.175-1.433-.372-1.941a3.926 3.926 0 0 0-.923-1.417A3.911 3.911 0 0 0 13.24.42c-.51-.198-1.092-.333-1.943-.372C10.443.01 10.172 0 7.998 0h.003zm-.717 1.442h.718c2.136 0 2.389.007 3.232.046.78.035 1.204.166 1.486.275.373.145.64.319.92.599.28.28.453.546.598.92.11.281.24.705.275 1.485.039.843.047 1.096.047 3.231s-.008 2.389-.047 3.232c-.035.78-.166 1.203-.275 1.485a2.47 2.47 0 0 1-.599.919c-.28.28-.546.453-.92.598-.28.11-.704.24-1.485.276-.843.038-1.096.047-3.232.047s-2.39-.009-3.233-.047c-.78-.036-1.203-.166-1.485-.276a2.478 2.478 0 0 1-.92-.598 2.48 2.48 0 0 1-.6-.92c-.109-.281-.24-.705-.275-1.485-.038-.843-.046-1.096-.046-3.233 0-2.136.008-2.388.046-3.231.036-.78.166-1.204.276-1.486.145-.373.319-.64.599-.92.28-.28.546-.453.92-.598.282-.11.705-.24 1.485-.276.738-.034 1.024-.044 2.515-.045v.002zm4.988 1.328a.96.96 0 1 0 0 1.92.96.96 0 0 0 0-1.92zm-4.27 1.122a4.109 4.109 0 1 0 0 8.217 4.109 4.109 0 0 0 0-8.217zm0 1.441a2.667 2.667 0 1 1 0 5.334 2.667 2.667 0 0 1 0-5.334zm3.707-.477a1 1 0 1 0 0 2 1 1 0 0 0 0-2z" />
                    </svg>
                  </div>
                </li>
              </ul>
            </div>
            <div className="col-3"></div>
          </div>
        </div>
      </footer>
    </body>
    </div>
  );
};

export default Registrarse;
