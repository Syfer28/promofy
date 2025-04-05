import { useState, useEffect } from "react";
import { View, Text, Image, StyleSheet, ActivityIndicator } from "react-native";
import { getCompany } from "../../api/API";
import Shop from "./Shop";

const Company = ({ idCompany, idShop }) => {
  const [companyData, setCompanyData] = useState(null);
  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getCompany(idCompany);
        setCompanyData(data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    fetchData();
  }, [idCompany]);

  return companyData ? (
    <View style={styles.container}>
      <Image source={{ uri: companyData.photo }} style={styles.img} />
      <View style={styles.textBlock}>
        <Text style={styles.companyName}>{companyData.name}</Text>
        <Shop idShop={idShop} />
      </View>
    </View>
  ) : null;
};

const styles = StyleSheet.create({
  container: {
    height: 50,
    marginBottom: 10,
    flexDirection: "row",
    alignItems: "center",
  },
  textBlock: {
    height: "100%",
    flexDirection: "column",
    justifyContent: "space-around",
  },
  img: {
    height: 50,
    width: 50,
    resizeMode: "stretch",
    borderRadius: 5,
    marginRight: 10,
  },
  companyName: {
    fontFamily: "Roboto-Medium",
    fontSize: 16,
  },
  // name: {
  //   fontFamily: "Roboto-Medium",
  // },
  // text: {
  //   flexDirection: "column",
  // },
  // adress: {
  //   flexDirection: "row",
  //   alignItems: "center",
  // },
  // adressText: {
  //   fontFamily: "Roboto-Light",
  //   color: "#808089",
  // },
});

export default Company;
