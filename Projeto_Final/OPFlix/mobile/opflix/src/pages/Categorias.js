import React, {Component} from 'react';
import {SafeAreaView, StyleSheet, ScrollView, View, Text, StatusBar, AsyncStorage, ImageBackground, TextInput, Image} from 'react-native';
import { TouchableOpacity } from 'react-native-gesture-handler';

class Categorias extends Component{

    constructor(){
        super();
        this.state={
            lancamentos: []
        };
    }


    efetuarLogin = async() =>{
       fetch("http://192.168.3.204:5000/api/login", {
         method: 'GET',
         headers: {
             Accept: 'application/json',
             'Content-Type':'application/json',
         },
         body: JSON.stringify({
             email: this.state.email,
             senha: this.state.email
         }),  
    })
    .then(resposta => resposta.json())
    .then(data => this.irMainPage(data.token))
    .catch(erro => console.warn('iiii deu erro' + erro));
};

    irMainPage = async(tokenRecebido) => {
        if(tokenRecebido != null){
            try{
                await AsyncStorage.SetItem('@opfli:token', tokenRecebido);
                this.props.navigation.navigate('MainNavigator');
            }catch(error){

            }
        }
    };
    render(){
        return(
            <ImageBackground style={{width: '100%', height: '100%'}} source={require('../assets/img/background.jpg')}>
                <View>
                  <Image source={require('../assets/img/logo.png')}/>
                  <TextInput placeholder= 'Email' onChangeText={email => this.setState({email})}></TextInput>
                  <TextInput placeholder= 'Senha' onChangeText={senha => this.setState({senha})}></TextInput>
                  <TouchableOpacity onPress={this.efetuarLogin}>
                    <Text>Login</Text>
                  </TouchableOpacity>
                </View>
            </ImageBackground>
        );
    }
}

export default Categorias
