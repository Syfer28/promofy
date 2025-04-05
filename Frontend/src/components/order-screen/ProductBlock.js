import { View, ScrollView, StyleSheet, Pressable, Text } from "react-native";
import Company from "./Company";
import Product from "./Product";

const ProductBlock = ({ products, onMapPress, onCoordinates }) => {
  const totalPrice = parseFloat(
    products
      .reduce((sum, product) => sum + product.price * product.count, 0)
      .toFixed(2)
  );

  return (
    <View style={styles.container}>
      <View style={styles.companyBlock}>
        <Company
          idCompany={products[0].idCompany}
          idShop={products[0].idShop}
          onCoordinates={onCoordinates}
        />
      </View>

      <ScrollView style={styles.productBlock}>
        {products.map((product) => (
          <Product key={product.idProduct} product={product} />
        ))}
      </ScrollView>

      {/* Bottom Section */}
      <View style={styles.bottomSection}>
        <Pressable style={styles.mapButton} onPress={onMapPress}>
          <Text style={styles.mapButtonText}>Open in maps</Text>
        </Pressable>
        <Text style={styles.totalPrice}>{totalPrice}€</Text>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    marginBottom: 30,
    backgroundColor: "white",
    paddingHorizontal: 20,
    paddingVertical: 16,
    borderRadius: 16, // Закруглённые углы
    shadowColor: "#000",
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.1,
    shadowRadius: 4,
    elevation: 2, // Тень для Android
  },
  companyBlock: {
    flexDirection: "row",
    alignItems: "center",
    marginBottom: 16,
  },
  productBlock: {
    flexGrow: 0,
    flexDirection: "column",
    marginBottom: 16,
  },
  bottomSection: {
    flexDirection: "row",
    justifyContent: "space-between",
    alignItems: "center",
    marginTop: 16,
    borderTopWidth: 1,
    borderTopColor: "#E0E0E0",
    paddingTop: 16,
  },
  mapButton: {
    backgroundColor: "#F5D21F",
    paddingVertical: 8,
    paddingHorizontal: 12,
    borderRadius: 8,
  },
  mapButtonText: {
    color: "#fff",
    fontSize: 14,
    fontWeight: "bold",
  },
  totalPrice: {
    fontSize: 16,
    fontWeight: "bold",
    color: "#000",
  },
});

export default ProductBlock;
