import React, {Component} from 'react';
import {SafeAreaView, StyleSheet,FlatList, ScrollView, View, Text, StatusBar, AsyncStorage, ImageBackground, TextInput, Image} from 'react-native';
import { TouchableOpacity } from 'react-native-gesture-handler';

class Lancamentos extends Component{

    constructor(){
        super();
        this.state={
            lancamentos:[],
        };
    }

    componentDidMount () {
        this._listarLancamentos();
    }

    _listarLancamentos = async() =>{
        try {
            let token = await AsyncStorage.getItem('@opflix:token')
            
            await fetch("http://192.168.3.204:5000/api/lancamento", {
                headers: {
                        'Accept':'application/json',
                        'Authorization': 'Bearer ' + token
                },
            })
            .then(resposta => resposta.json())
            .then(data => this.setState({lancamentos: data}))
        } catch (error) {
        }
            
        };

    render(){
        return(
            <View >
                <Image style={{height: "10%", width:"10%"}} source={require('../assets/img/logo.png')} />
                        <Text>lançamentos</Text>
                        <FlatList
                            data={this.state.lancamentos}
                            keyExtractor={item => item.idLancamento}
                            renderItem={({ item }) => (
                                <View >
                                    <Text>Nome:{item.nome}</Text>
                                    <Text>Data de estreia:{item.dataEstreia}</Text>
                                    <Text>{item.idTipoNavigation.nome}</Text>
                                    <Text>{item.descricao}</Text>
                                    <Text>{item.sinopse}</Text>
                                    <Text>{item.idCategoriaNavigation.nome}</Text>
                                    <Text>{item.tempoDuracao}</Text>
                                    <Text>{item.idPlataformaNavigation.nome}</Text>
                                </View>
                            )}
                        />
                    </View>
        );
    }
}

export default Lancamentos
