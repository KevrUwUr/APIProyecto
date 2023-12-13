// import React, { useState } from "react";
// import { ScrollView, View, StyleSheet, Text, TextInput, TouchableOpacity } from "react-native";
// import { Card } from "react-native-paper";
// import { useForm, Controller } from 'react-hook-form';
// import axios from "axios";

// const Login = ({ navigation }) => {
//   const { control, handleSubmit, formState: { errors } } = useForm();
//   const [loading, setLoading] = useState(false);
//   const [error, setError] = useState(null);

//   const onSubmit = async (data) => {
//     try {
//       setLoading(true);
//       setError(null);

//       //const response = await axios.post('URL_DE_TU_API/login', data);

//       console.log(response.data);
//       navigation.navigate('Menu');
//     } catch (error) {
//       console.error("Error al iniciar sesión:", error);
//       setError("Error al iniciar sesión. Verifica tus credenciales.");
//     } finally {
//       setLoading(false);
//     }
//   };

//   return (
//     <ScrollView contentContainerStyle={styles.container}>
//       <Card style={styles.card}>
//         <View style={styles.formContainer}>
//           <Controller
//             control={control}
//             render={({ field }) => (
//               <>
//                 <TextInput
//                   style={styles.input}
//                   placeholder="Nombre de usuario"
//                   value={field.value}
//                   onChangeText={(text) => field.onChange(text)}
//                 />
//                 {errors.username && <Text style={{ color: 'red' }}>{errors.username.message}</Text>}
//               </>
//             )}
//             name="username"
//             rules={{ required: 'Nombre de usuario requerido' }}
//             defaultValue=""
//           />

//           <Controller
//             control={control}
//             render={({ field }) => (
//               <>
//                 <TextInput
//                   style={styles.input}
//                   placeholder="Contraseña"
//                   secureTextEntry
//                   value={field.value}
//                   onChangeText={(text) => field.onChange(text)}
//                 />
//                 {errors.password && <Text style={{ color: 'red' }}>{errors.password.message}</Text>}
//               </>
//             )}
//             name="password"
//             rules={{ required: 'Contraseña requerida' }}
//             defaultValue=""
//           />

//           <TouchableOpacity
//             style={styles.submitButton}
//             onPress={handleSubmit(onSubmit)}
//             disabled={loading}
//           >
//             <Text style={styles.submitButtonText}>{loading ? 'Cargando...' : 'Iniciar sesión'}</Text>
//           </TouchableOpacity>

//           {error && <Text style={{ color: 'red', textAlign: 'center' }}>{error}</Text>}
//         </View>
//       </Card>
//     </ScrollView>
//   );
// };

// const styles = StyleSheet.create({
//   container: {
//     flex: 1,
//     backgroundColor: "#F5F5DC",
//     justifyContent: "center",
//     alignItems: "center",
//   },
//   card: {
//     backgroundColor: "#002b5b",
//     width: "80%",
//     height: "60%",
//     borderRadius: 15,
//     overflow: "hidden",
//     justifyContent: "center",
//   },
//   formContainer: {
//     height: "60%",
//     justifyContent: "center",
//     alignItems: "center",
//     margin: 10,
//   },
//   input: {
//     height: 50,
//     width: "80%",
//     borderColor: "#000000",
//     backgroundColor: "#F5F5DC",
//     borderWidth: 1,
//     borderRadius: 10,
//     marginBottom: 20,
//     paddingLeft: 15,
//     fontSize: 18,
//     color: "#000000",
//   },
//   submitButton: {
//     backgroundColor: "#F5F5DC",
//     padding: 15,
//     borderRadius: 10,
//     width: "80%",
//     marginBottom: 10,
//   },
//   submitButtonText: {
//     textAlign: "center",
//     fontSize: 20,
//     color: "#000000",
//   },
// });

// export default Login;



const Login = ({navigation}) => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  return (
    <ScrollView contentContainerStyle={styles.container}>
      <Card style={styles.card}>
        <View style={styles.imagenContainer}>
          <Image source={Logo} style={styles.imagen} resizeMode="contain" />
        </View>
        <View style={styles.formContainer}>
          <TextInput
            style={styles.input}
            placeholder="Nombre de usuario"
            value={username}
            onChangeText={(text) => setUsername(text)}
          />
          <TextInput
            style={styles.input}
            placeholder="Contraseña"
            secureTextEntry
            value={password}
            onChangeText={(text) => setPassword(text)}
          />
          <TouchableOpacity
            style={styles.submitButton}
            onPress={() => navigation.navigate('Menu')}
          >
            <Text style={styles.submitButtonText}>Iniciar sesión</Text>
          </TouchableOpacity>
        </View>
      </Card>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#F5F5DC",
    justifyContent: "center",
    alignItems: "center",
  },
  card: {
    backgroundColor: "#002b5b",
    width: "80%",
    height: "60%",
    borderRadius: 15,
    overflow: "hidden",
    justifyContent: "center",
  },
  formContainer: {
    height: "60%",
    justifyContent: "center",
    alignItems: "center",
    margin: 10,
  },
  imagenContainer: {
    height: "30%",
    width: "100%",
    justifyContent: "center",
    alignItems: "center",
  },
  imagen: {
    width: "50%",
    height: "50%",
  },
  input: {
    height: 50,
    width: "80%",
    borderColor: "#000000",
    backgroundColor: "#F5F5DC",
    borderWidth: 1,
    borderRadius: 10,
    marginBottom: 20,
    paddingLeft: 15,
    fontSize: 18,
    color: "#000000",
  },
  submitButton: {
    backgroundColor: "#F5F5DC",
    padding: 15,
    borderRadius: 10,
    width: "80%",
    marginBottom: 10,
  },
  submitButtonText: {
    textAlign: "center",
    fontSize: 20,
    color: "#000000",
  },
  text: {
    textAlign: "center",
    fontSize: 25,
    color: "#fff",
  },
});

export default Login;
