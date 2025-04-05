import React, { useState } from "react";
import { View, TextInput, StyleSheet, Pressable } from "react-native";
import { Ionicons } from "@expo/vector-icons";

const SearchBar = ({ onSearch }) => {
  const [query, setQuery] = useState("");
  const [focused, setFocused] = useState(false);
  const [isSubmited, setIsSubmited] = useState(false);

  const handleSubmit = async () => {
    onSearch(query.trim());
    {
      query && setIsSubmited(true);
    }
  };

  const handleCancel = () => {
    setQuery("");

    onSearch("");
    setIsSubmited(false);
  };

  return (
    <View style={styles.container} id="cont">
      {isSubmited && (
        <Pressable
          style={[styles.cancelBtn, styles.shadow]}
          onPress={handleCancel}
        >
          <Ionicons name="chevron-back" size={25} color={"#2E2D2D"} />
        </Pressable>
      )}

      <View style={[styles.inputBlock, { width: !isSubmited ? "85%" : "70%" }]}>
        <Ionicons
          name="search"
          size={25}
          color={"#F5D21F"}
          style={styles.searchIcon}
        />
        <TextInput
          style={[styles.input, styles.shadow, focused && styles.inputFocused]}
          value={query}
          onChangeText={setQuery}
          onSubmitEditing={handleSubmit}
          onFocus={() => setFocused(true)}
          onBlur={() => setFocused(false)}
          placeholder="Enter product"
        />
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    width: "100%",
    flexDirection: "row",
    justifyContent: "center",
  },
  cancelBtn: {
    position: "absolute",
    paddingVertical: 6.5,
    paddingHorizontal: 6.5,
    backgroundColor: "white",
    borderRadius: 8,
    top: 10,
    left: 10,
  },
  inputBlock: {
    marginVertical: 10,
  },
  input: {
    width: "100%",
    opacity: 70,
    marginLeft: "auto",
    marginRight: "auto",
    paddingVertical: 10,
    paddingStart: 34,
    backgroundColor: "white",
    borderRadius: 8,
    fontFamily: "EuclidCircularB-Regular",
    borderColor: "transparent",
  },
  inputFocused: {
    opacity: 100,
  },
  searchIcon: {
    position: "absolute",
    top: 6,
    left: 5,
    zIndex: 1,
  },
  shadow: {
    shadowColor: "#ccc", // Optional: shadow color (default is black)
    shadowOffset: { width: 3, height: 3 }, // Shadow offset
    shadowOpacity: 0.3, // Shadow opacity (0 - 1)
    shadowRadius: 4, // Shadow blur radius
    elevation: 4,
  },
});

export default SearchBar;
