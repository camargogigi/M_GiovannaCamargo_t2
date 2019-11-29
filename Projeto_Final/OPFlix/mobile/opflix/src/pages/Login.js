import React, {Component} from 'react';
import {SafeAreaView, StyleSheet, ScrollView, TouchableOpacity, View, Text, StatusBar, AsyncStorage, ImageBackground, TextInput, Image} from 'react-native';

class Login extends Component{

    static navigationOptions ={
        header: null,
    };

    constructor(){
        super();
        this.state={
            email: "",
            senha: ""
        };
    }

    componentDidMount() {
        this._verificacao()
        console.disableYellowBox = true;
    }
    
    _verificacao = async () => {
        if(await AsyncStorage.getItem('@opflix:token') != null){
            this.props.navigation.navigate('MainNavigator')
        }
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
            <View style={{backgroundColor: 'black', width: '100%', height: '100%', justifyContent: 'center', alignItems:'center'}}>
                <Image style={styles.logo} source={require('../assets/img/logo.png')}/>
                  <TextInput placeholder= 'Email' placeholderTextColor='white' style={styles.input} onChangeText={email => this.setState({email})}></TextInput>
                  <TextInput placeholder= 'Senha' secureTextEntry={true} placeholderTextColor='white' style={styles.input} onChangeText={senha => this.setState({senha})}></TextInput>
                  <TouchableOpacity style={styles.botton} onPress={this._efetuarLogin}>
                    <Text style={styles.text}>Entrar</Text>
                  </TouchableOpacity>
            </View>
        );
    }
}

const styles = StyleSheet.create({


    input:{
        color: 'white',
        fontSize: 12,
        justifyContent: 'center',
        margin: 15,
        width: '60%',
        height: 50,
        borderBottomColor: "#ff0000"
        
    },
    text:{
        color: 'white',
        fontSize: 12,
    },
    botton:{
        backgroundColor:'#672B3F',
        borderRadius: 6,
        width: '60%',
        height: 35,
        alignItems: 'center',
        justifyContent: 'center',
        margin: 40
    },
    logo:{
        width: 219,
        height: 70,
        margin: 40
    }
})

export default Login
