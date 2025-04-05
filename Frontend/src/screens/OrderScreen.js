import React, { useState, useEffect } from "react";
import { View, SafeAreaView, Text, StyleSheet, Modal } from "react-native";
import { useProductStore } from "../components/store/productStore";
import { getProductList, postProduct } from "../api/API";
import OrderList from "../components/order-screen/OrderList";
import Map from "../components/order-screen/Map";

const OrderScreen = () => {
  const [modalVisible, setModalVisible] = useState(false);
  const [coordinates, setCoordinates] = useState({
    latitude: 0,
    longtitude: 0,
  });

  // const [productListData, setProductListData] = useState("");
  // useEffect(() => {
  //   const fetchData = async () => {
  //     try {
  //       const data = await getProductList();
  //       setProductListData(data);
  //     } catch (error) {
  //       console.error("Error fetching data:", error);
  //     }
  //   };
  //   fetchData();
  // }, []);
  // console.log(productListData);

  // useEffect(() => {
  //   const product = {
  //     quantity: 7,
  //     userId: 1,

  //     productId: 4,
  //   };
  //   const fetchData = async () => {
  //     try {
  //       const addedProduct = await postProduct(product);
  //       console.log("Product added:", addedProduct);
  //     } catch (error) {
  //       console.error(
  //         "Error in postProduct:",
  //         error.response ? error.response.data : error.message
  //       );
  //     }
  //   };
  //   fetchData();
  // }, []);

  const products = useProductStore((state) => state.products);
  const hasProducts = Object.values(products).some(
    (product) => product.count > 0
  );

  const handleCoordinates = (lat, lon) => {
    setCoordinates({ lat, lon });
  };

  return (
    <SafeAreaView>
      {modalVisible && <View style={styles.overlay} />}
      {hasProducts && (
        <OrderList
          productsData={products}
          onMapPress={() => setModalVisible(true)}
          onCoordinates={handleCoordinates}
        />
      )}
      <Modal animationType="slide" visible={modalVisible} transparent={true}>
        <Map
          onModalVisible={() => setModalVisible(!modalVisible)}
          coordinates={coordinates}
        />
      </Modal>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  overlay: {
    position: "absolute",
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    backgroundColor: "rgba(0, 0, 0, 0.5)",
    justifyContent: "center",
    alignItems: "center",
    zIndex: 100,
  },
});

export default OrderScreen;
