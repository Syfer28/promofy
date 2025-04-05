import React from "react";
import { View, Text } from "react-native";
import { Ionicons } from "@expo/vector-icons";
import { useProductStore } from "../store/productStore";

const IconOrderScreen = ({ isFocused }) => {
  const products = useProductStore((state) => state.products);
  const badgeCount = Object.getOwnPropertyNames(products).length;

  return (
    <View>
      <Ionicons
        name={isFocused ? "cart" : "cart-outline"}
        size={25}
        color={"#F5D21F"}
      />
      {badgeCount > 0 && (
        <View
          style={{
            position: "absolute",
            top: -5,
            right: -10,
            width: 20,
            height: 20,
            backgroundColor: "red",
            borderRadius: "50%",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <Text style={{ color: "white" }}>{badgeCount}</Text>
        </View>
      )}
    </View>
  );
};

export default IconOrderScreen;
