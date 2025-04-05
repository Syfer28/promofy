import { View, StyleSheet, Pressable } from "react-native";
import MapView, { Marker } from "react-native-maps";
import { Ionicons } from "@expo/vector-icons";

const Map = ({ onModalVisible, coordinates }) => {
  console.log(coordinates);
  return (
    <View style={styles.modalContainer}>
      <View style={styles.modalContent}>
        <Pressable style={styles.closeBtn} onPress={onModalVisible}>
          <Ionicons name="close" size={36} color={"black"} />
        </Pressable>
        <MapView style={styles.map}>
          <Marker
            coordinate={{
              latitude: 56.95034789764196,
              longitude: 24.12492303364472,
            }}
          />
        </MapView>
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
    height: "80%",
    backgroundColor: "white",
    borderTopLeftRadius: 20,
    borderTopRightRadius: 20,
    overflow: "hidden",
  },
  map: {
    flex: 1,
    borderTopLeftRadius: 20,
    borderTopRightRadius: 20,
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
});

export default Map;
