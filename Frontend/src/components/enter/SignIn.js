import React, { useState } from "react";
import {
  View,
  Text,
  TextInput,
  ScrollView,
  Pressable,
  StyleSheet,
} from "react-native";
import { useNavigation } from "@react-navigation/native";

const SignIn = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigation = useNavigation();

  const validateEmail = (email) => {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  };

  const validatePassword = (password) => {
    return password.length >= 6;
  };

  const handleSignIn = () => {
    if (!email.trim()) {
      alert("Email field cannot be empty");
      return;
    }
    if (!password.trim()) {
      alert("Password field cannot be empty");
      return;
    }
    if (!validateEmail(email)) {
      alert("Invalid email format");
      return;
    }
    if (!validatePassword(password)) {
      alert("Password must be at least 6 characters long");
      return;
    }
    if (email === "gmail@gmail.com" && password === "123") {
      navigation.navigate("Main");
    } else {
      alert("Wrong email or password");
    }
  };

  const handleGuest = () => {
    navigation.navigate("Main");
  };

  return (
    <ScrollView contentContainerStyle={styles.form}>
      <Text style={styles.header}>PROMOFY</Text>
      <Input
        label="Email address"
        value={email}
        placeholder="Email address"
        onChangeText={(text) => setEmail(text)}
      />
      <Input
        label="Password"
        value={password}
        placeholder="Password"
        onChangeText={(text) => setPassword(text)}
        secureTextEntry
      />
      <Pressable onPress={() => alert("Forgot Password?")} style={styles.link}>
        <Text style={styles.linkText}>Forgot Password?</Text>
      </Pressable>
      <Pressable onPress={handleSignIn} style={styles.btn}>
        <Text style={styles.btnText}>Log In</Text>
      </Pressable>
      <Pressable onPress={handleGuest} style={styles.guestBtn}>
        <Text style={styles.guestBtnText}>Continue as Guest</Text>
      </Pressable>
      <View style={styles.footer}>
        <Text style={styles.footerText}>Don't have an account? </Text>
        <Pressable onPress={() => alert("Sign Up")}>
          <Text style={styles.signUpText}>Sign Up</Text>
        </Pressable>
      </View>
    </ScrollView>
  );
};

export const Input = (props) => {
  const { placeholder, value, onChangeText, secureTextEntry } = props;
  return (
    <View style={styles.inputContainer}>
      <TextInput
        value={value}
        placeholder={placeholder}
        onChangeText={onChangeText}
        style={styles.input}
        secureTextEntry={secureTextEntry}
        autoCapitalize="none"
      />
    </View>
  );
};

const styles = StyleSheet.create({
  form: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    backgroundColor: "#fff",
    padding: 16,
  },
  header: {
    marginBottom: 80,
    color: "#F5D21F",
    fontSize: 50,
    fontFamily: "Quicksand-SemiBold",
  },
  inputContainer: {
    width: "100%",
    marginBottom: 16,
  },
  input: {
    borderRadius: 8,
    padding: 12,
    fontSize: 16,
    borderWidth: 1,
    borderColor: "#ccc",
    width: "100%",
    backgroundColor: "#f9f9f9",
  },
  link: {
    alignSelf: "flex-end",
    marginBottom: 20,
  },
  linkText: {
    color: "#007BFF",
    fontSize: 14,
  },
  btn: {
    borderRadius: 8,
    backgroundColor: "#FFD01B",
    width: "100%",
    padding: 12,
    alignItems: "center",
    marginBottom: 16,
  },
  btnText: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold",
  },
  guestBtn: {
    borderRadius: 8,
    backgroundColor: "#f0f0f0",
    width: "100%",
    padding: 12,
    alignItems: "center",
    marginBottom: 16,
  },
  guestBtnText: {
    color: "#000",
    fontSize: 16,
  },
  footer: {
    flexDirection: "row",
    marginTop: 20,
  },
  footerText: {
    fontSize: 14,
    color: "#000",
  },
  signUpText: {
    fontSize: 14,
    color: "#007BFF",
    fontWeight: "bold",
  },
});

export default SignIn;
