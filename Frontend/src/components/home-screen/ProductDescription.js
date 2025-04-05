import { useState } from "react";
import {
  Text,
  View,
  SafeAreaView,
  Pressable,
  StyleSheet,
  Image,
} from "react-native";
import { Ionicons } from "@expo/vector-icons";
import { useProductStore } from "../store/productStore";

const ProductDescription = ({ onModalVisible, product }) => {
  let count = useProductStore(
    (state) => state.products[product.idProduct]?.count || 0
  );
  const { increaseCount, decreaseCount } = useProductStore((state) => ({
    increaseCount: state.increaseCount,
    decreaseCount: state.decreaseCount,
  }));

  const handlePlus = () => {
    increaseCount(product, product.idProduct);
  };

  const handleMinus = () => {
    if (count > 0) {
      decreaseCount(product.idProduct);
    }
  };

  return (
    <View style={styles.modalContainer}>
      <View style={styles.modalContent}>
        <Pressable style={styles.closeBtn} onPress={onModalVisible}>
          <Ionicons name="close" size={36} color={"black"} />
        </Pressable>
        <Image source={{ uri: product.photo }} style={styles.img} />
        <View style={styles.contentBlock}>
          <View style={styles.textBlock}>
            <Text style={styles.name}>{product.name}</Text>
            <View style={styles.priceBlock}>
              <Text style={styles.price}>
                {(
                  product.price -
                  (product.price / 100) * product.discount
                ).toFixed(2)}
                €
              </Text>
              <Text style={styles.prevPrice}>{product.price}€</Text>
            </View>
            <Text>
              Lorem Ipsum is simply dummy text of the printing and typesetting
              industry. Lorem Ipsum has been the industry's{" "}
            </Text>
          </View>
          <View style={styles.btnBlock}>
            <View style={styles.countBtnBlock}>
              <Pressable
                style={styles.countOpBtn}
                onPress={handleMinus}
                disabled={count <= 0}
              >
                <Text style={styles.countOpText}>−</Text>
              </Pressable>
              <Text style={styles.countText}>{count}</Text>
              <Pressable style={styles.countOpBtn} onPress={handlePlus}>
                <Text style={styles.countOpText}>+</Text>
              </Pressable>
            </View>
            <Pressable style={styles.toListBtn}>
              <Text style={styles.toListText}>Add to list +</Text>
            </Pressable>
          </View>
        </View>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  modalContainer: {
    flex: 1,
    justifyContent: "flex-end",
  },
  modalContent: {
    paddingTop: 20,
    height: "60%",
    backgroundColor: "white",
    borderRadius: 8,
  },
  closeBtn: {
    position: "absolute",
    height: 45,
    width: 45,
    backgroundColor: "#F2F2F2",
    borderRadius: 13,
    right: 15,
    top: 15,
    justifyContent: "center",
    alignItems: "center",
    zIndex: 10,
  },
  img: {
    height: "40%",
    width: "100%",
    borderRadius: 8,
    resizeMode: "contain",
  },
  contentBlock: {
    paddingHorizontal: 35,
    alignItems: "center",
  },
  textBlock: { alignItems: "center" },
  name: {
    fontSize: 35,
    fontFamily: "Roboto-Medium",
    marginBottom: 15,
  },
  priceBlock: {
    flexDirection: "row",
    paddingLeft: 91 - 91 / 2,
  },
  price: {
    color: "#F5D21F",
    fontFamily: "Montserrat-Medium",
    fontSize: 25,
    marginRight: 5,
  },
  prevPrice: {
    textDecorationLine: "line-through",
    color: "grey",
    fontSize: 18,
    fontFamily: "Montserrat-Regular",
  },
  btnBlock: {
    width: "100%",
    height: 55,
    flexDirection: "row",
    marginTop: 40,
    justifyContent: "space-between",
  },
  countBtnBlock: {
    flexDirection: "row",
    backgroundColor: "#FCF3C7",
    width: "45%",
    justifyContent: "center",
    alignItems: "center",
    borderRadius: 7,
  },
  countOpBtn: {
    height: "100%",
    flex: 3,
    alignItems: "center",
    justifyContent: "center",
  },
  countOpText: {
    fontFamily: "Roboto-Medium",
    fontSize: 20,
  },
  countText: {
    flex: 4,
    textAlign: "center",
    fontFamily: "Roboto-Medium",
    fontSize: 20,
  },
  toListBtn: {
    height: "100%",
    width: "45%",
    alignItems: "center",
    justifyContent: "center",
    backgroundColor: "#F5D21F",
    color: "white",
    paddingVertical: 18,
    borderRadius: 7,

    shadowColor: "#F5D21F", // Optional: shadow color (default is black)
    shadowOffset: { width: 3, height: 3 }, // Shadow offset
    shadowOpacity: 0.3, // Shadow opacity (0 - 1)
    shadowRadius: 4, // Shadow blur radius
    elevation: 4,
  },
  toListText: {
    color: "white",
    fontFamily: "Roboto-Medium",
  },
});

export default ProductDescription;
