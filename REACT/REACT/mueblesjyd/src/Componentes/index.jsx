import React from "react";
import "../assets/css/Index.css";
import Navbar from "./Navbar";
import Footer from "./Footer";
import "../assets/css/styles.css";

const index = () => {
  return (
    <div className="App">
      <Navbar />
      <body style={{ background: "#f9f5eb" }}>
        <div
          className="container py-4 py-xl-5"
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
              >
                Productos destacados
              </h2>
            </div>
          </div>
          <div className="row gy-4 row-cols-1 row-cols-md-2">
            <div className="col">
              <div className="d-flex flex-column flex-lg-row">
                <div className="w-100">
                  <img
                    className="rounded img-fluid d-block w-100 fit-cover"
                    style={{ height: "200px" }}
                    src="https://cdn.bootstrapstudio.io/placeholders/1400x800.png"
                    alt="Producto destacado 1"
                  />
                </div>
                <div className="py-4 py-lg-0 px-lg-4">
                  <h4
                    style={{
                      fontFamily: "ABeeZee, sans-serif",
                      fontWeight: "bold",
                    }}
                  >
                    Nombre producto destacado
                  </h4>
                  <p style={{ fontFamily: "ABeeZee, sans-serif" }}>
                    Descripción producto
                  </p>
                </div>
              </div>
            </div>
            <div className="col">
              <div className="d-flex flex-column flex-lg-row">
                <div className="w-100">
                  <img
                    className="rounded img-fluid d-block w-100 fit-cover"
                    style={{ height: "200px" }}
                    src="https://cdn.bootstrapstudio.io/placeholders/1400x800.png"
                    alt="Producto destacado 1"
                  />
                </div>
                <div className="py-4 py-lg-0 px-lg-4">
                  <h4
                    style={{
                      fontFamily: "ABeeZee, sans-serif",
                      fontWeight: "bold",
                    }}
                  >
                    Nombre producto destacado
                  </h4>
                  <p style={{ fontFamily: "ABeeZee, sans-serif" }}>
                    Descripción producto
                  </p>
                </div>
              </div>
            </div>
            <div className="col">
              <div className="d-flex flex-column flex-lg-row">
                <div className="w-100">
                  <img
                    className="rounded img-fluid d-block w-100 fit-cover"
                    style={{ height: "200px" }}
                    src="https://cdn.bootstrapstudio.io/placeholders/1400x800.png"
                    alt="Producto destacado 1"
                  />
                </div>
                <div className="py-4 py-lg-0 px-lg-4">
                  <h4
                    style={{
                      fontFamily: "ABeeZee, sans-serif",
                      fontWeight: "bold",
                    }}
                  >
                    Nombre producto destacado
                  </h4>
                  <p style={{ fontFamily: "ABeeZee, sans-serif" }}>
                    Descripción producto
                  </p>
                </div>
              </div>
            </div>
            <div className="col">
              <div className="d-flex flex-column flex-lg-row">
                <div className="w-100">
                  <img
                    className="rounded img-fluid d-block w-100 fit-cover"
                    style={{ height: "200px" }}
                    src="https://cdn.bootstrapstudio.io/placeholders/1400x800.png"
                    alt="Producto destacado 1"
                  />
                </div>
                <div className="py-4 py-lg-0 px-lg-4">
                  <h4
                    style={{
                      fontFamily: "ABeeZee, sans-serif",
                      fontWeight: "bold",
                    }}
                  >
                    Nombre producto destacado
                  </h4>
                  <p style={{ fontFamily: "ABeeZee, sans-serif" }}>
                    Descripción producto
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
        <Footer />
      </body>
    </div>
  );
};

export default index;
