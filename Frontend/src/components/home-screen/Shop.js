import { useState, useEffect } from "react";
import { View, Text, Image, StyleSheet, ActivityIndicator } from "react-native";
import { Ionicons } from "@expo/vector-icons";
import { getShop } from "../../api/API";

const Shop = ({ idShop }) => {
  const [shopData, setShopData] = useState(null);
  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getShop(idShop);
        setShopData(data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    fetchData();
  }, [idShop]);

  return shopData ? (
    <View style={styles.container}>
      <Ionicons name="location-sharp" size={14} color={"#808089"} />
      <Text style={styles.adressText}>{shopData.addressString}</Text>
    </View>
  ) : null;
};

const styles = StyleSheet.create({
  container: {
    flexDirection: "row",
    alignItems: "flex-start",
  },
  adressText: {
    fontFamily: "Roboto-Light",
    color: "#808089",
    fontSize: 15,
    marginLeft: 2,
  },
});

export default Shop;
