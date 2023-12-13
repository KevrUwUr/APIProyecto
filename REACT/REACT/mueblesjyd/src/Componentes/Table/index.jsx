import React from "react";

const Table = ({
  header,
  data,
  onRemove,
  onUpdate,
  onView,
  modalId,
  modalId2,
  filtroCampos,
  filtro,
}) => {
  const dataFiltrada = data.filter((item) => {
    return filtroCampos.some((campo) => {
      return item[campo].toLowerCase().includes(filtro.toLowerCase());
    });
  });

  return (
    <div className="App">
      <table className="table table-dark custom-table" id="ipi-table">
        <thead className="thead-dark">
          <tr>
            {header.map((item, i) => (
              <th key={i}>{item}</th>
            ))}
          </tr>
        </thead>
        <tbody className="text-center">
          {dataFiltrada.map((item, idx) => (
            <tr key={idx}>
              {Object.keys(item).map((itemkey, i) => (
                <td key={i}>
                  {itemkey === "id" ||
                  itemkey === "empleadoId" ||
                  itemkey === "productoId" ||
                  itemkey === "idProveedor" ||
                  itemkey === "idPerdida" ||
                  itemkey === "idUsuario"
                    ? idx + 1
                    : item[itemkey]}
                </td>
              ))}
              <td>
                <button
                  data-bs-toggle="modal"
                  data-bs-target={`#${modalId}`}
                  onClick={() => onUpdate(item)}
                  className="btn btn-success btn-rect mr-2 w-100"
                  style={{ borderRadius: 0 }}
                >
                  <i className="fa-solid fa-edit"></i>
                </button>
                <button
                  onClick={() => onRemove(item)}
                  className="btn btn-danger btn-rect w-100"
                  style={{ borderRadius: 0 }}
                >
                  <i className="fa-solid fa-trash"></i>
                </button>
                <button
                  data-bs-toggle="modal"
                  data-bs-target={`#${modalId2}`}
                  className="btn btn-primary btn-rect mr-2 w-100"
                  style={{ borderRadius: 0 }}
                  onClick={() => {
                    onView(item);
                    console.log({ item });
                  }}
                >
                  <i className="fa-solid fa-phone"></i>
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Table;
