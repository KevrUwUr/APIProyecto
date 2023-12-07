import React, { useEffect, useState } from "react";
import axios from "axios";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { show_alert } from "../Functions";
import Logo from "../assets/img/Logo.png";
import "../assets/css/Index.css";
import "../assets/css/Google-Style-Login-.css";


const LogIn = () => {
  return (
    <div className="App">
      <body style={{ background: "#f9f5eb", marginTop: 0, paddingTop: 0 }}>
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
        <div className="login-card" style={{ borderColor: 'var(--bs-black)', border: '3px solid var(--bs-black)', height: '100%', background: '#e4dccf', marginTop: '30px' }}>
      <i className="far fa-user d-xl-flex justify-content-center align-items-center align-content-center mx-auto justify-content-xl-center align-items-xl-center" style={{ width: '29px', fontSize: '70px', marginLeft: '0px', marginTop: '0px' }}></i>
      <form className="form-signin" style={{ marginTop: '18px', borderTopWidth: 0, borderRightWidth: 0, borderBottomWidth: 0, borderLeftWidth: 0 }}>
        <span className="reauth-email"> </span>
        <input className="form-control" type="email" id="inputEmail" required="" placeholder="Correo electrónico" autoFocus />
        <input className="form-control" type="password" id="inputPassword" required="" placeholder="Contraseña" />
        <div className="checkbox">
          <div className="form-check">
            <input className="form-check-input" type="checkbox" id="formCheck-1" />
            <label className="form-check-label" htmlFor="formCheck-1" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Recuérdame</label>
          </div>
        </div>
        <a className="btn btn-primary btn-lg d-block btn-signin w-100" role="button" href="./Admin" style={{ fontFamily: 'ABeeZee, sans-serif' }}>Ingresar</a>
      </form>
      <a className="forgot-password" href="#" style={{ fontFamily: 'ABeeZee, sans-serif' }}>¿Olvidaste tu contraseña?</a>
    </div>
    <footer className="text-center py-4" style={{ background: '#ea5455' }}>
        <div className="container">
          <div className="row row-cols-1 row-cols-lg-3">
            <div className="col" style={{ color: '#000000' }}>
              <p className="my-2" style={{ color: '#000000', fontFamily: 'ABeeZee, sans-serif' }}>Copyright&nbsp;© 2023 Brand</p>
            </div>
            <div className="col" style={{ color: '#000000' }}>
              <ul className="list-inline my-2" style={{ color: '#000000' }}>
                <li className="list-inline-item me-4" style={{ color: '#000000' }}>
                  <div className="bs-icon-circle bs-icon-primary bs-icon" style={{ color: '#000000' }}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" fill="currentColor" viewBox="0 0 16 16" className="bi bi-facebook" style={{ color: '#000000' }}>
                      <path d="M16 8.049c0-4.446-3.582-8.05-8-8.05C3.58 0-.002 3.603-.002 8.05c0 4.017 2.926 7.347 6.75 7.951v-5.625h-2.03V8.05H6.75V6.275c0-2.017 1.195-3.131 3.022-3.131.876 0 1.791.157 1.791.157v1.98h-1.009c-.993 0-1.303.621-1.303 1.258v1.51h2.218l-.354 2.326H9.25V16c3.824-.604 6.75-3.934 6.75-7.951z"></path>
                    </svg>
                  </div>
                </li>
                <li className="list-inline-item me-4" style={{ color: '#000000' }}>
                  <div className="bs-icon-circle bs-icon-primary bs-icon" style={{ color: '#000000' }}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" fill="currentColor" viewBox="0 0 16 16" className="bi bi-twitter" style={{ color: '#000000' }}>
                      <path d="M5.026 15c6.038 0 9.341-5.003 9.341-9.334 0-.14 0-.282-.006-.422A6.685 6.685 0 0 0 16 3.542a6.658 6.658 0 0 1-1.889.518 3.301 3.301 0 0 0 1.447-1.817 6.533 6.533 0 0 1-2.087.793A3.286 3.286 0 0 0 7.875 6.03a9.325 9.325 0 0 1-6.767-3.429 3.289 3.289 0 0 0 1.018 4.382A3.323 3.323 0 0 1 .64 6.575v.045a3.288 3.288 0 0 0 2.632 3.218 3.203 3.203 0 0 1-.865.115 3.23 3.23 0 0 1-.614-.057 3.283 3.283 0 0 0 3.067 2.277A6.588 6.588 0 0 1 .78 13.58a6.32 6.32 0 0 1-.78-.045A9.344 9.344 0 0 0 5.026 15z"></path>
                    </svg>
                  </div>
                </li>
                <li className="list-inline-item" style={{ color: '#000000' }}>
                  <div className="bs-icon-circle bs-icon-primary bs-icon" style={{ color: '#000000' }}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" fill="currentColor" viewBox="0 0 16 16" className="bi bi-instagram" style={{ color: '#000000' }}>
                      <path d="M8 0C5.829 0 5.556.01 4.703.048 3.85.088 3.269.222 2.76.42a3.917 3.917 0 0 0-1.417.923A3.927 3.927 0 0 0 .42 2.76C.222 3.268.087 3.85.048 4.7.01 5.555 0 5.827 0 8.001c0 2.172.01 2.444.048 3.297.04.852.174 1.433.372 1.942.205.526.478.972.923 1.417.444.445.889.719 1.416.923.51.198 1.09.333 1.942.372C5.555 15.99 5.827 16 8 16s-.01-2.445-.048-3.299c-.04-.851-.175-1.433-.372-1.941a3.926 3.926 0 0 0-.923-1.417A3.911 3.911 0 0 0 13.24.42c-.51-.198-1.092-.333-1.943-.372C10.443.01 10.172 0 7.998 0h.003zm-.717 1.442h.718c2.136 0 2.389.007 3.232.046.78.035 1.204.166 1.486.275.373.145.64.319.92.599.28.28.453.546.598.92.11.281.24.705.275 1.485.039.843.047 1.096.047 3.231s-.008 2.389-.047 3.232c-.035.78-.166 1.203-.275 1.485a2.47 2.47 0 0 1-.599.919c-.28.28-.546.453-.92.598-.28.11-.704.24-1.485.276-.843.038-1.096.047-3.232.047s-2.39-.009-3.233-.047c-.78-.036-1.203-.166-1.485-.276a2.478 2.478 0 0 1-.92-.598 2.48 2.48 0 0 1-.6-.92c-.109-.281-.24-.705-.275-1.485-.038-.843-.046-1.096-.046-3.233 0-2.136.008-2.388.046-3.231.036-.78.166-1.204.276-1.486.145-.373.319-.64.599-.92.28-.28.546-.453.92-.598.282-.11.705-.24 1.485-.276.738-.034 1.024-.044 2.515-.045v.002zm4.988 1.328a.96.96 0 1 0 0 1.92.96.96 0 0 0 0-1.92zm-4.27 1.122a4.109 4.109 0 1 0 0 8.217 4.109 4.109 0 0 0 0-8.217zm0 1.441a2.667 2.667 0 1 1 0 5.334 2.667 2.667 0 0 1 0-5.334z"></path>
                    </svg>
                  </div>
                </li>
              </ul>
            </div>
            <div className="col" style={{ color: '#000000' }}>
              <ul className="list-inline my-2" style={{ color: '#000000' }}>
                <li className="list-inline-item"><a style={{ color: '#000000', fontFamily: 'ABeeZee, sans-serif' }}>Privacy Policy</a></li>
                <li className="list-inline-item" style={{ color: '#000000' }}><a style={{ color: '#000000', fontFamily: 'ABeeZee, sans-serif' }}>Terms of Use</a></li>
              </ul>
            </div>
          </div>
        </div>
      </footer>
      </body>
    </div>
  );
};

export default LogIn;
