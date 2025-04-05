import React, { useState } from "react";
import { View, Text, StyleSheet, Image } from "react-native";

const Product = ({ product }) => {
  return (
    <View key={product.id} id="productsss" style={[styles.container]}>
      <View style={styles.imgBlock}>
        <Image source={{ uri: product.photo }} style={styles.img} />
      </View>

      <View style={styles.textBlock}>
        <View style={styles.priceBlock}>
          <Text style={styles.price}>
            {(product.price - (product.price / 100) * product.discount).toFixed(
              2
            )}
            €
          </Text>
          <View style={styles.countBlock}>
            <Text style={styles.countText}>{product.count} pcs</Text>
          </View>
        </View>
        <View style={styles.nameBlock}>
          <Text style={styles.name}>{product.name}</Text>
        </View>
        <View style={styles.discountBlock}>
          <Text style={styles.prevPrice}>{product.price}€</Text>
        </View>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    backgroundColor: "white",
    borderRadius: 8,
    flexDirection: "row",
  },
  img: {
    width: 80,
    height: 80,
    resizeMode: "contain",
  },
  priceBlock: {
    flexDirection: "row",
  },
  price: {
    fontFamily: "EuclidCircularB-SemiBold",
  },
  countBlock: {
    marginLeft: 10,
    backgroundColor: "#F2F2F2",
    paddingHorizontal: 4,
    paddingVertical: 2,
    borderRadius: 5,
  },
});

export default Product;
