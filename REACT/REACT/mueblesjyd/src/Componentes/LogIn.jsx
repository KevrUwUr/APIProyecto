import React from "react";
import "../assets/css/Index.css";
import "../assets/css/Google-Style-Login-.css";
import Navbar from "./Navbar";
import Footer from "./Footer";

const LogIn = () => {

  return (
    <div className="App">
      <Navbar/>
      <body style={{ background: "#f9f5eb", marginTop: 0, paddingTop: 0 }}>
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
      <a className="forgot-password">¿Olvidaste tu contraseña?</a>
    </div>
    <Footer/>
      </body>
    </div>
  );
};

export default LogIn;
