import React from "react";
import Logo from "../../assets/img/Logo.png";

const Navbar = () => {
  
  return (
    <div className="App">
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
                <li className="nav-item" data-bss-hover-animate="flash" style={{ color: 'var(--bs-white)', fontWeight: 'bold' }}><a className="nav-link" data-bss-hover-animate="flash" href="./ListaProductos" style={{ color: 'var(--bs-white)', fontWeight: 'bold', fontFamily: 'ABeeZee, sans-serif' }}>Productos</a></li>
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

    </div>
  );
};

export default Navbar;