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
       fetch("http://192.168.4.229:5000/api/login", {
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
            <View style={{backgroundColor: '#160234', width: '100%', height: '100%', justifyContent: 'center', alignItems:'center'}}>
                <View style={styles.campoLogin}>
                <Image style={styles.logo} source={require('../assets/img/logo.png')}/>
                  <TextInput placeholder= 'Email' placeholderTextColor='white' style={styles.input} onChangeText={email => this.setState({email})}></TextInput>
                  <TextInput placeholder= 'Senha' placeholderTextColor='white' style={styles.input} onChangeText={senha => this.setState({senha})}></TextInput>
                  <TouchableOpacity style={styles.botton} onPress={this._efetuarLogin}>
                    <Text style={styles.text}>Entrar</Text>
                  </TouchableOpacity>
                </View>
            </View>
        );
    }
}

const styles = StyleSheet.create({

    campoLogin: {
        backgroundColor: 'rgba(0, 0, 0, 0.685)', 
        width:300, 
        height: 450, 
        alignItems: 'center'
    },
    input:{
        color: 'white',
        fontSize: 12,
        width: 217,
        height: 35,
        backgroundColor: '#4D4949',
        borderRadius: 6,
        justifyContent: 'center',
        margin: 7
        
    },
    text:{
        color: 'white',
        fontSize: 12,
    },
    botton:{
        backgroundColor:'#672B3F',
        borderRadius: 6,
        width: 217,
        height: 35,
        alignItems: 'center',
        justifyContent: 'center',
        margin: 20
    },
    logo:{
        width: 219,
        height: 70,
        margin: 35
    }
})

export default Login
