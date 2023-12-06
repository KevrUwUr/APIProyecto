import * as React from "react";
import { ScrollView, View, StyleSheet } from "react-native";
import { DataTable } from "react-native-paper";
import Navbar from "./Navbar";

const ShowCategories = () => {
  const [items] = React.useState([
    {
      key: 1,
      name: "Cupcake",
      calories: 356,
      fat: 16,
    },
    {
      key: 2,
      name: "Eclair",
      calories: 262,
      fat: 16,
    },
    {
      key: 3,
      name: "Frozen yogurt",
      calories: 159,
      fat: 6,
    },
    {
      key: 4,
      name: "Gingerbread",
      calories: 305,
      fat: 3.7,
    },
  ]);

  return (
    <View style={styles.container}>
      <Navbar />
      <ScrollView style={styles.scrollContainer}>
        <DataTable style={styles.dataTable}>
          <DataTable.Header>
            <DataTable.Title>Dessert</DataTable.Title>
            <DataTable.Title numeric>Calories</DataTable.Title>
            <DataTable.Title numeric>Fat</DataTable.Title>
          </DataTable.Header>

          {items.map((item) => (
            <DataTable.Row key={item.key}>
              <DataTable.Cell>{item.name}</DataTable.Cell>
              <DataTable.Cell numeric>{item.calories}</DataTable.Cell>
              <DataTable.Cell numeric>{item.fat}</DataTable.Cell>
            </DataTable.Row>
          ))}
        </DataTable>
      </ScrollView>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  scrollContainer: {
    paddingHorizontal: 16,
    paddingTop: 16,
  },
  dataTable: {
    marginTop: 16,
  },
});

export default ShowCategories;