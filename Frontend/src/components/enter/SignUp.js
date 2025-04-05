import React, { useState } from 'react';
import { View, Text, TextInput, ScrollView } from 'react-native';

const App = () => {
  const [ email, setEmail ] = useState('');
  const [ password, setPassword ] = useState('');
  const [ passwordsMatch, setPasswordsMatch ] = useState('')
  const [ name, setName ] = useState('');
  const [ date, setDate ] = useState('');
  const [ breed, setBreed ] = useState('');
  const [ toy, setToy ] = useState('');

  const confirmPasswordsMatch = () => {
    if (passwordsMatch !== password) {
      alert('Passwords do not match, please try again.');
    }
  }

  return (
      <ScrollView style={{ flex: 1, justifyContent: 'center', backgroundColor: '#ecf0f1', padding: 16}}>
        <Input 
          label='Email' 
          value={email} 
          placeholder='Type your email' 
          onChangeText={(text) => setEmail(text)}
        />
        <Input 
          label='Password' 
          value={password} 
          placeholder='Type your password' 
          onChangeText={(text) => setPassword(text)} 
          secureTextEntry 
        />
        <Input
          label="Confirm password"
          placeholder="Re-type your password here"
          onSubmitEditing={(text) => confirmPasswordsMatch(text)}
          secureTextEntry
        />
        <Input 
          label='Name' 
          value={name} 
          placeholder="Your pet's name" 
          onChangeText={(text) => setName(text)}
        />
        <Input 
          label='Date' 
          value={date} 
          placeholder="Your pet's date of birth" 
          onChangeText={(text) => setDate(text)}
        />
        <Input 
          label='Breed' 
          value={breed} 
          placeholder='Breed of your pet' 
          onChangeText={(text) => setBreed(text)}
        />
        <Input 
          label='Toy' 
          value={toy} 
          placeholder='Its favorite toy' 
          onChangeText={(text) => setToy(text)}
        />
      </ScrollView>
  )
};

export const Input = props => {
  const { label, placeholder, value, onChangeText, secureTextEntry, onSubmitEditing } = props;
  return (
    <View>
      <Text style={{ padding: 8, fontSize: 18 }}>{label}</Text>
      <TextInput 
        value={value}
        placeholder={placeholder}
        onChangeText={onChangeText} 
        style={{ padding: 8, fontSize: 18, borderWidth: 1}} 
        onSubmitEditing={onSubmitEditing}
        secureTextEntry={secureTextEntry}
      />
    </View>
  )
}

export default App;
