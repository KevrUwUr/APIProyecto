import React, { useEffect, useState } from "react";
import { ScrollView, View, StyleSheet, Modal, Text, TouchableOpacity } from "react-native";
import { DataTable } from "react-native-paper";
import Navbar from "./Navbar";
import axios from "axios";

const ShowUsers = () => {
  const [items, setItems] = useState([]);
  const [selectedItem, setSelectedItem] = useState(null);
  const [modalVisible, setModalVisible] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        //const response = await axios.get("URL_DE_TU_API/showproducts");
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
                <DataTable.Cell>{item.lastNanme}</DataTable.Cell>
                <DataTable.Cell>{item.firstNanme}</DataTable.Cell>
                <DataTable.Cell>{item.sex}</DataTable.Cell>
                <DataTable.Cell>{item.documentTipe}</DataTable.Cell>
                <DataTable.Cell>{item.document}</DataTable.Cell>
                <DataTable.Cell numeric>{item.tipe}</DataTable.Cell>
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
                <Text>LastName: {selectedItem.lastNanme}</Text>
                <Text>FirstName: {selectedItem.firstNanme}</Text>
                <Text>Sex: {selectedItem.sex}</Text>
                <Text>DocumentType: {selectedItem.documentTipe}</Text>
                <Text>Document: {selectedItem.document}</Text>
                <Text>Type: {selectedItem.tipe}</Text>
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

export default ShowUsers;

