import React, { useState, useEffect } from "react";
import {
  View,
  Text,
  StyleSheet,
  Dimensions,
  Image,
  Button,
  Pressable,
  TouchableOpacity,
} from "react-native";
import Animated, {
  useAnimatedStyle,
  useSharedValue,
  withTiming,
} from "react-native-reanimated";
import { useProductStore } from "../store/productStore";
import discountImg from "../../img/discountImg.png";

const Product = ({ product, onTogle, marginRight, lastChild }) => {
  const screenWidth = Dimensions.get("window").width;
  let productWidth = (screenWidth - 50) / 2;

  const count = useProductStore(
    (state) => state.products[product.idProduct]?.count || 0
  );
  const { increaseCount, decreaseCount } = useProductStore((state) => ({
    increaseCount: state.increaseCount,
    decreaseCount: state.decreaseCount,
  }));

  const animationWidth = useSharedValue(count > 0 ? 100 : 0);
  const rotation = useSharedValue(count > 0 ? 180 : 0);

  useEffect(() => {
    rotation.value = withTiming(count > 0 ? 180 : 0, { duration: 400 });
    animationWidth.value = withTiming(count > 0 ? 100 : 0);
  }, [count]);

  const handlePlus = () => {
    increaseCount(product, product.idProduct);
  };

  const handleMinus = () => {
    decreaseCount(product.idProduct);
  };

  const rotateStyle = useAnimatedStyle(() => {
    return {
      transform: [
        {
          rotate: `${rotation.value}deg`,
        },
      ],
    };
  });

  const animatedStyle = useAnimatedStyle(() => ({
    width: animationWidth.value,
    flexDirection: "row",
    justifyContent: "flex-start",
    alignItems: "center",
  }));

  return (
    <View
      key={product.id}
      id="productsss"
      style={[
        styles.container,

        {
          width: productWidth,
          marginRight: lastChild ? productWidth + 30 : marginRight ? 30 : 0,
        },
      ]}
    >
      <Pressable onPress={onTogle} style={styles.pressableContainer}>
        <Image source={{ uri: product.photo }} style={styles.img} />
        <View style={styles.discountContainer}>
          <Image source={discountImg} style={styles.discountImg} />
          <Text style={styles.discount}>{product.discount}%</Text>
        </View>

        <View style={styles.textBlock}>
          <View style={styles.nameBlock}>
            <Text style={styles.name}>{product.name}</Text>
          </View>
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
        </View>
      </Pressable>
      <View style={styles.btnBlock}>
        <Animated.View style={animatedStyle}>
          <TouchableOpacity onPress={handleMinus} disabled={count === 0}>
            <Text style={styles.oppText}>−</Text>
          </TouchableOpacity>
          <View style={styles.countContainer}>
            <Text style={styles.countText}>{count}</Text>
          </View>
        </Animated.View>
        <Animated.View style={rotateStyle}>
          <TouchableOpacity onPress={handlePlus} style={styles.oppButton}>
            <Text style={styles.oppText}>+</Text>
          </TouchableOpacity>
        </Animated.View>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    height: 200,
    backgroundColor: "white",
    borderRadius: 8,
  },
  pressableContainer: {
    height: "81%",
  },
  img: {
    height: "65%",
    width: "100%",
    borderRadius: 8,
    resizeMode: "contain",
  },
  textBlock: {
    height: "35%",
    justifyContent: "center",
    alignItems: "center",
  },
  nameBlock: {
    marginBottom: 5,
  },
  discountContainer: {
    position: "absolute",
    top: 2,
    left: 3,
    width: 40,
    height: 40,
    justifyContent: "center",
  },
  discount: {
    color: "white",
    fontSize: 12,
    textAlign: "center",
    fontFamily: "Montserrat-Medium",
  },
  discountImg: {
    width: "100%",
    height: "100%",
    position: "absolute",
  },
  priceBlock: {
    flexDirection: "row",
    justifyContent: "center",
  },
  price: {
    color: "#F5D21F",
    fontFamily: "Montserrat-Medium",
    fontSize: 17,
  },
  prevPrice: {
    textDecorationLine: "line-through",
    color: "grey",
    fontSize: 13,
    fontFamily: "Montserrat-Medium",
  },
  name: {
    fontFamily: "EuclidCircularB-Regular",
    fontSize: 17,
  },
  btnBlock: {
    height: "19%",
    paddingHorizontal: 20,
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "center",
  },
  oppText: {
    fontSize: 35,
    color: "#F5D21F",
    lineHeight: 35,
    textAlign: "center",
  },
  oppButton: {
    alignItems: "center",
    justifyContent: "center",
  },
  countContainer: {
    marginLeft: "35%",
  },
  countText: {
    fontFamily: "Montserrat-Medium",
    fontSize: 20,
  },
});

export default Product;
