import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";

export function show_alert(icono, mensaje, foco = "") {
  OnFocus(foco);

  const MySwal = withReactContent(Swal);

  MySwal.fire({
    title: mensaje,
    icon: icono,
  });
}

function OnFocus(foco) {
  if (foco !== "") {
    document.getElementById("foco").focus();
  }
}
