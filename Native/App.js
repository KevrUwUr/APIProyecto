import React from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import axios from "axios";

import Login from "./Componentes/Login";
import Menu from "./Componentes/Menu";
import NavBar from "./Componentes/Navbar/index";
import ShowCategories from "./Componentes/ShowCategories";
import ShowProducts from "./Componentes/ShowProducts";
import ShowCargos from "./Componentes/ShowCargos";
import ShoeEmployees from "./Componentes/ShoeEmployees";
import ShowBuyInvoice from "./Componentes/ShowBuyInvoice";
import ShowSellInvoice from "./Componentes/ShowSellInvoice";
import ShowLosses from "./Componentes/ShowLosses";
import ShowSuppliers from "./Componentes/ShowSuppliers";
import ShowUsers from "./Componentes/ShowUsers";

const Stack = createNativeStackNavigator();

// Reemplaza "URL_DE_TU_API" con la URL real de tu API
const api = axios.create({
  baseURL: "URL_DE_TU_API",
  timeout: 10000,
});

const App = () => {
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
          name="ShowCargos"
          component={() => <ShowCargos api={api} />}
          options={{ headerShown: false, title: "Navbar" }}
        />
        <Stack.Screen
          name="ShowCategories"
          component={() => <ShowCategories api={api} />}
          options={{ headerShown: false, title: "Navbar" }}
        />
        <Stack.Screen
          name="ShowProducts"
          component={() => <ShowProducts api={api} />}
          options={{ headerShown: false, title: "Navbar" }}
        />
        <Stack.Screen
          name="ShoeEmployees"
          component={() => <ShoeEmployees api={api} />}
          options={{ headerShown: false, title: "Navbar" }}
        />
        <Stack.Screen
          name="ShowBuyInvoice"
          component={() => <ShowBuyInvoice api={api} />}
          options={{ headerShown: false, title: "Navbar" }}
        />
        <Stack.Screen
          name="ShowSellInvoice"
          component={() => <ShowSellInvoice api={api} />}
          options={{ headerShown: false, title: "Navbar" }}
        />
        <Stack.Screen
          name="ShowLosses"
          component={() => <ShowLosses api={api} />}
          options={{ headerShown: false, title: "Navbar" }}
        />
        <Stack.Screen
          name="ShowSuppliers"
          component={() => <ShowSuppliers api={api} />}
          options={{ headerShown: false, title: "Navbar" }}
        />
        <Stack.Screen
          name="ShowUsers"
          component={() => <ShowUsers api={api} />}
          options={{ headerShown: false, title: "Navbar" }}
        />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;



// import React from "react";
// import { NavigationContainer } from "@react-navigation/native";
// import { createNativeStackNavigator } from "@react-navigation/native-stack";
// import axios from "axios";

// import Login from "./Componentes/Login";
// import Menu from "./Componentes/Menu";
// import NavBar from "./Componentes/Navbar/index";
// import ShowCategories from "./Componentes/ShowCategories";
// import ShowProducts from "./Componentes/ShowProducts";
// import ShowCargos from "./Componentes/ShowCargos";
// import ShoeEmployees from "./Componentes/ShoeEmployees";
// import ShowBuyInvoice from "./Componentes/ShowBuyInvoice";
// import ShowSellInvoice from "./Componentes/ShowSellInvoice";
// import ShowLosses from "./Componentes/ShowLosses";
// import ShowSuppliers from "./Componentes/ShowSuppliers";
// import ShowUsers from "./Componentes/ShowUsers";

// const Stack = createNativeStackNavigator();


// const api = axios.create({
//   baseURL: "URL_DE_TU_API", // Reemplaza con la URL de tu API
//   timeout: 10000,
// });

// function App() {
//   return (
//     <NavigationContainer>
//       <Stack.Navigator initialRouteName="Login">
//         <Stack.Screen
//           name="Login"
//           component={Login}
//           options={{ headerShown: false, title: "Login" }}
//         />
//         <Stack.Screen
//           name="Menu"
//           component={Menu}
//           options={{ headerShown: false, title: "Menu" }}
//         />
//         <Stack.Screen
//           name="Barra"
//           component={NavBar}
//           options={{ headerShown: false, title: "Navbar" }}
//         />
//         <Stack.Screen
//           name="ShowCargos"
//           component={ShowCargos}
//           options={{ headerShown: false, title: "Navbar" }}
//         />
//         <Stack.Screen
//           name="ShowCategories"
//           component={ShowCategories}
//           options={{ headerShown: false, title: "Navbar" }}
//         />
//         <Stack.Screen
//           name="ShowProducts"
//           component={ShowProducts}
//           options={{ headerShown: false, title: "Navbar" }}
//         />
//         <Stack.Screen
//           name="ShoeEmployees"
//           component={ShoeEmployees}
//           options={{ headerShown: false, title: "Navbar" }}
//         />
//         <Stack.Screen
//           name="ShowBuyInvoice"
//           component={ShowBuyInvoice}
//           options={{ headerShown: false, title: "Navbar" }}
//         />
//         <Stack.Screen
//           name="ShowSellInvoice"
//           component={ShowSellInvoice}
//           options={{ headerShown: false, title: "Navbar" }}
//         />
//         <Stack.Screen
//           name="ShowLosses"
//           component={ShowLosses}
//           options={{ headerShown: false, title: "Navbar" }}
//         />
//         <Stack.Screen
//           name="ShowSuppliers"
//           component={ShowSuppliers}
//           options={{ headerShown: false, title: "Navbar" }}
//         />
//         <Stack.Screen
//           name="ShowUsers"
//           component={ShowUsers}
//           options={{ headerShown: false, title: "Navbar" }}
//         />
        
//       </Stack.Navigator>
//     </NavigationContainer>
//   );
// }


// export default App;