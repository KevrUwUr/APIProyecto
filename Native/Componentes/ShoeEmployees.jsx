import React, { useEffect, useState } from "react";
import { ScrollView, View, StyleSheet, Modal, Text, TouchableOpacity } from "react-native";
import { DataTable } from "react-native-paper";
import Navbar from "./Navbar";
import axios from "axios";

const ShoeEmployees = () => {
  const [items, setItems] = useState([]);
  const [selectedItem, setSelectedItem] = useState(null);
  const [modalVisible, setModalVisible] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get("http://localhost:7284/api/empleados");
        setItems(response.data);
      } catch (error) {
        console.error("Error al obtener datos de la API:", error);
        setError("Error al cargar datos. Inténtalo de nuevo más tarde.");
      }
    };

    fetchData();
  }, []);

  const handleItemPress = (item) => {
    setSelectedItem(item);
    setModalVisible(true);
  
  };

  return (
    <View style={styles.container}>
      <Navbar />
      <ScrollView style={styles.scrollContainer}>
        {error ? (
          <Text style={{ color: 'red', textAlign: 'center' }}>{error}</Text>
        ) : (
          <DataTable style={styles.dataTable}>
            <DataTable.Header>

            </DataTable.Header>

          {items.map((item) => (
            <TouchableOpacity key={item.key} onPress={() => handleItemPress(item)}>
              <DataTable.Row>
                <DataTable.Cell>{item.name}</DataTable.Cell>
                <DataTable.Cell>{item.lastName}</DataTable.Cell>
                <DataTable.Cell>{item.sex}</DataTable.Cell>
                <DataTable.Cell date>{item.birthdate}</DataTable.Cell>
                <DataTable.Cell numeric>{item.state}</DataTable.Cell>
              </DataTable.Row>
            </TouchableOpacity>
          ))}
        </DataTable>
        )}
      </ScrollView>

      <Modal
        animationType="slide"
        transparent={true}
        visible={modalVisible}
        onRequestClose={() => setModalVisible(false)}
      >
        <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
          <View style={{ backgroundColor: 'white', padding: 20, borderRadius: 10 }}>
            {selectedItem && (
              <>
                <Text>Name: {selectedItem.name}</Text>
                <Text>LastName: {selectedItem.lastName}</Text>
                <Text>Sex: {selectedItem.sex}</Text>
                <Text>Birthdate: {selectedItem.birthdate}</Text>
                <Text>State: {selectedItem.state}</Text>
              </>
            )}
            <TouchableOpacity onPress={() => setModalVisible(false)}>
              <Text style={{ color: 'blue', marginTop: 10 }}>Close</Text>
            </TouchableOpacity>
          </View>
        </View>
      </Modal>
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

export default ShoeEmployees;
