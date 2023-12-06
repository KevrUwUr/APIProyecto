import React from "react";
import {
  View,
  Text,
  Image,
  ScrollView,
  StyleSheet,
  TouchableOpacity,
  StatusBar,
} from "react-native";
import Logo from "../assets/img/Logo.png";

const Cargos = () => {
  console.log("Presiono Cargos");
};
const Categorias = () => {
  console.log("Presiono Categorias");
};
const Empleados = () => {
  console.log("Presiono Empleados");
};
const FCompras = () => {
  console.log("Presiono Facturas de compra");
};
const FVentas = () => {
  console.log("Presiono Facturas de venta");
};
const Perdidas = () => {
  console.log("Presiono Perdidas");
};
const Productos = () => {
  console.log("Presiono Productos");
};
const Proveedores = () => {
  console.log("Presiono Proveedores");
};
const Usuarios = () => {
  console.log("Presiono Usuarios");
};

const Menu = ({ navigation }) => {
  return (
    <ScrollView contentContainerStyle={styles.container}>
      <StatusBar barStyle="dark-content" backgroundColor="#00000050" />
      <View style={styles.imagenContainer}>
        <TouchableOpacity style={styles.touchImage} activeOpacity={1}>
          <Image source={Logo} style={styles.imagen} resizeMode="contain" />
        </TouchableOpacity>
        <Text style={styles.text}> {"\n"} Elige una opción</Text>
      </View>
      <View style={styles.botonesContainer}>
        <TouchableOpacity style={styles.botones} onPress={Cargos}>
          <Text style={styles.botonesText}>Cargos</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.botones} onPress={() => navigation.navigate('ShowCategories')}>
          <Text style={styles.botonesText}>Categorias</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.botones} onPress={Empleados}>
          <Text style={styles.botonesText}>Empleados</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.botones} onPress={FCompras}>
          <Text style={styles.botonesText}>Facturas de compra</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.botones} onPress={FVentas}>
          <Text style={styles.botonesText}>Facturas de venta</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.botones} onPress={Perdidas}>
          <Text style={styles.botonesText}>Perdidas</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.botones} onPress={Productos}>
          <Text style={styles.botonesText}>Productos</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.botones} onPress={Proveedores}>
          <Text style={styles.botonesText}>Proveedores</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.botones} onPress={Usuarios}>
          <Text style={styles.botonesText}>Usuarios</Text>
        </TouchableOpacity>
      </View>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#F5F5DC",
    justifyContent: "flex-start",
    alignItems: "center",
    paddingTop: "5%",
  },
  botonesContainer: {
    height: "70%",
    width: "100%",
    justifyContent: "center",
    alignItems: "center",
    margin: "10%",
  },
  imagenContainer: {
    height: "20%",
    width: "100%",
    justifyContent: "center",
    alignItems: "center",
  },
  botones: {
    padding: 5,
    backgroundColor: "#002B5B",
    borderColor: "#000000",
    borderWidth: 3,
    borderRadius: 10,
    fontSize: 25,
    width: "80%",
    margin: 5,
    shadowColor: "#000000",
    shadowOpacity: 0,
  },
  botonesText: {
    textAlign: "center",
    fontSize: 25,
    color: "#fff",
  },
  text: {
    textAlign: "center",
    fontSize: 25,
    color: "#000000",
  },
  touchImage: {
    height: "60%",
    width: "100%",
    justifyContent: "center",
    alignItems: "center",
  },
  imagen: {
    width: "100%",
    height: "100%",
  },
});
export default Menu;
