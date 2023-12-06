import React, { useState } from "react";
import {
  View,
  Text,
  Image,
  StyleSheet,
  TouchableOpacity,
  Modal,
  StatusBar,
} from "react-native";
import Logo from "../../assets/img/Logo.png";

const Navbar = ({ navigation }) => {
  const [isMenuVisible, setMenuVisible] = useState(false);

  const toggleMenu = () => {
    setMenuVisible(!isMenuVisible);
  };

  return (
    <View style={styles.container}>
      <StatusBar barStyle="dark-content" backgroundColor="rgba(0, 0, 0, 0)" />
      <View style={styles.header}>
        <TouchableOpacity onPress={toggleMenu} style={styles.logoContainer}>
          <Image source={Logo} style={styles.logo} />
        </TouchableOpacity>

        <Text style={styles.textTitulo}>Prueba</Text>
      </View>

      <Modal transparent={true} visible={isMenuVisible} animationType="slide">
        <View style={styles.menuModal}>
          <View style={styles.imagenContainer}>
            <TouchableOpacity
              style={styles.touchImage}
              onPress={() => navigation.navigate('Login')}
            >
              <Image source={Logo} style={styles.imagen} resizeMode="contain" />
            </TouchableOpacity>
          </View>
          <TouchableOpacity onPress={toggleMenu}>
            <Text style={styles.menuItem}>Cargos</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={toggleMenu}>
            <Text style={styles.menuItem}>Categorias</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={toggleMenu}>
            <Text style={styles.menuItem}>Empleados</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={toggleMenu}>
            <Text style={styles.menuItem}>Facturas de compra</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={toggleMenu}>
            <Text style={styles.menuItem}>Facturas de venta</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={toggleMenu}>
            <Text style={styles.menuItem}>Perdidas</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={toggleMenu}>
            <Text style={styles.menuItem}>Productos</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={toggleMenu}>
            <Text style={styles.menuItem}>Proveedores</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={toggleMenu}>
            <Text style={styles.menuItem}>Usuarios</Text>
          </TouchableOpacity>
        </View>
      </Modal>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    backgroundColor: "#F5F5DC",
    justifyContent: "flex-start",
    alignItems: "center",
    height: "10%",
  },
  header: {
    backgroundColor: "#002b5b",
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
    padding: 16,
    width: "100%",
  },
  logoContainer: {
    width: "30%",
  },
  logo: {
    width: "90%",
    height: 50,
  },
  textTitulo: {
    fontSize: 40,
    fontWeight: "bold",
    fontStyle: "italic",
    color: "#FFF",
    textAlign: "center",
    flex: 1,
  },
  menuModal: {
    backgroundColor: "#002B5B",
    flex: 1,
    width: "50%",
    padding: 10,
    height: "90%",
  },
  menuItem: {
    fontSize: 18,
    color: "#FFF",
    marginBottom: 20,
    paddingLeft: 5,
    fontStyle: "italic",
  },
  touchImage: {
    height: "60%",
    width: "100%",
    justifyContent: "center",
    alignItems: "center",
  },
  imagen: {
    height: "80%",
  },
  imagenContainer: {
    height: "20%",
    width: "100%",
    justifyContent: "center",
    alignItems: "center",
  },
});

export default Navbar;
