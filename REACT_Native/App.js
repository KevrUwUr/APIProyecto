import React from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import Login from "./Componentes/login";
import Menu from "./Componentes/menu";
import NavBar from "./Componentes/Navbar/index";
import "react-native-gesture-handler";
import ShowCategories from "./Componentes/ShowCategories";

const Stack = createNativeStackNavigator();

function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="Login">
        <Stack.Screen
          name="Login"
          component={Login}
          options={{ headerShown: false, title: "Login" }}
        />
        <Stack.Screen
          name="Menu"
          component={Menu}
          options={{ headerShown: false, title: "Menu" }}
        />
        <Stack.Screen
          name="Barra"
          component={NavBar}
          options={{ headerShown: false, title: "Navbar" }}
        />
        <Stack.Screen
          name="ShowCategories"
          component={ShowCategories}
          options={{ headerShown: false, title: "Navbar" }}
        />
      </Stack.Navigator>
    </NavigationContainer>
  );
}

export default App;