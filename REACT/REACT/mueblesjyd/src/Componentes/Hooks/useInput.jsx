import { useState } from "react";

const useInput = ({ defaultValue, validate = null }) => {
  const [input, setInput] = useState(defaultValue);
  const [error, setError] = useState("");

  const handleChange = (value) => {
    if (validate) {
      if (!validate.test(value)) {
        setError("Campo invalido");
      } else {
        setError("");
      }
    }
    setInput(value);
  };

  return {
    input,
    handleChange,
    error,
  };
};

export default useInput;
