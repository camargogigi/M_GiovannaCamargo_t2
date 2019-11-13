import React, {Component} from 'react';
import {SafeAreaView, StyleSheet, ScrollView, TouchableOpacity, View, Text, StatusBar, AsyncStorage, ImageBackground, TextInput, Image} from 'react-native';

class Login extends Component{

    static navigationOptions ={
        header: null,
    };

    constructor(){
        super();
        this.state={
            email: "h@.com",
            senha: "123659g8"
        };
    }

    _efetuarLogin = async() =>{
       fetch("http://192.168.3.204:5000/api/login", {
         method: 'POST',
         headers: {
             'Accept': 'application/json',
             'Content-Type':'application/json',
         },
         body: JSON.stringify({
             email: this.state.email,
             senha: this.state.senha
         }),  
    })
    .then(resposta => resposta.json())
    .then(data => this._irMainPage(data.token))
    .catch(erro => console.warn('iiii deu erro' + erro));

};

_irMainPage = async(tokenRecebido) => {
    console.warn(tokenRecebido)
        if(tokenRecebido != null){
            try{
                await AsyncStorage.setItem('@opflix:token', tokenRecebido);
                this.props.navigation.navigate('MainNavigator');
            }catch(error){

            }
        }
    };
    render(){
        return(
            <ImageBackground style={{width: '100%', height: '100%'}} source={require('../assets/img/background.jpg')}>
                <View>
                  <Image style={{width: '25%', height: '25%'}} source={require('../assets/img/logo.png')}/>
                  <TextInput placeholder= 'Email' onChangeText={email => this.setState({email})}></TextInput>
                  <TextInput placeholder= 'Senha' onChangeText={senha => this.setState({senha})}></TextInput>
                  <TouchableOpacity onPress={this._efetuarLogin}>
                    <Text>Login</Text>
                  </TouchableOpacity>
                </View>
            </ImageBackground>
        );
    }
}

export default Login
