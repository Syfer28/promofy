import * as React from "react";
import { StyleSheet, View, Text } from "react-native";
import { Ionicons } from "@expo/vector-icons";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import HomeScreen from "./HomeScreen";
import OrderScreen from "./OrderScreen";
import IconOrderScreen from "../components/other/iconOrderScreen";

const Tab = createBottomTabNavigator();

// --- Main screens ---

const AccountScreen = () => (
  <View style={styles.layout}>
    <Text style={styles.title}>AccountScreen</Text>
  </View>
);

const MainNavigator = () => (
  <Tab.Navigator
    screenOptions={{
      tabBarStyle: {
        // position: "absolute",
        // bottom: 20,
        // left: 10,
        // right: 10,
        borderRadius: 15,
        shadowColor: "#000",
        shadowOffset: {
          width: 0,
          height: 3,
        },
        shadowOpacity: 0.2,
        shadowRadius: 5,
        paddingBottom: -30,
      },
      tabBarShowLabel: false,
    }}
    style={{ backgroundColor: "white" }}
  >
    <Tab.Screen
      name="HomeScreen"
      component={HomeScreen}
      options={{
        headerShown: false,
        tabBarIcon: ({ focused }) => (
          <Ionicons
            name={focused ? "home" : "home-outline"}
            size={25}
            color={"#F5D21F"}
          />
        ),
      }}
    />
    <Tab.Screen
      name="Catalog"
      component={AccountScreen}
      options={{
        headerShown: false,
        tabBarIcon: ({ focused }) => (
          <Ionicons
            name={focused ? "person" : "person-outline"}
            size={25}
            color={"#F5D21F"}
          />
        ),
      }}
    />
    <Tab.Screen
      name="OrderScreen"
      component={OrderScreen}
      options={{
        headerShown: false,
        tabBarIcon: ({ focused }) => <IconOrderScreen isFocused={focused} />,
      }}
    />
  </Tab.Navigator>
);

export default MainNavigator;

const styles = StyleSheet.create({
  layout: {
    flex: 1,
    justifyContent: "center",
    padding: 8,
  },
  title: {
    margin: 24,
    fontSize: 18,
    fontWeight: "bold",
    textAlign: "center",
  },
});
