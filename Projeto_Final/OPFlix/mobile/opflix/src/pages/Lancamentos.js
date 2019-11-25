import React, {Component} from 'react';
import {SafeAreaView, StyleSheet,FlatList, ScrollView, View, Text, StatusBar, AsyncStorage, ImageBackground, TextInput, Image} from 'react-native';
import { TouchableOpacity } from 'react-native-gesture-handler';
import { Colors } from 'react-native/Libraries/NewAppScreen';

class Lancamentos extends Component{
    static navigationOptions = {
        tabBarIcon: () => (
          <Image 
            source = {require('../assets/img/whitelist.png')}
            style={{width: 25, height: 25, tintColor: 'white'}}
          />
        )
      }



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
            
            await fetch("http://192.168.4.229:5000/api/lancamento", {
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
            <ScrollView>
            <View style={{backgroundColor: 'black'} }>
                <Image style={{height: 32, width:100, margin: 15}} source={require('../assets/img/logo.png')} />
                    <View style={{alignItems: 'center'}}>
                        <Text style={{color: '#fff', fontSize: 20, marginTop: 15 }}>Lançamentos</Text>
                        <Text style={{backgroundColor: '#C75E17', width: 130, height:5, borderRadius: 10}}></Text>
                    </View>
                        <FlatList
                            data={this.state.lancamentos}
                            keyExtractor={item => item.idLancamento}
                            renderItem={({ item }) => (
                                <View style={{margin: 10}}>
                                    <Text style={styles.font}>Nome: {item.nome}</Text>
                                    <Text style={styles.font}>Data de estreia: {item.dataEstreia}</Text>
                                    <Text style={styles.font}>Tipo: {item.idTipoNavigation.nome}</Text>
                                    <Text style={styles.font}>Descrição: {item.descricao}</Text>
                                    <Text style={styles.font}>Sinopse: {item.sinopse}</Text>
                                    <Text style={styles.font}>Categoria: {item.idCategoriaNavigation.nome}</Text>
                                    <Text style={styles.font}>Tempo de duração:{item.tempoDuracao}</Text>
                                    <Text style={styles.font}>Plataforma disponível: {item.idPlataformaNavigation.nome}</Text>
                                    <View style={{alignItems: 'center'}}>
                                    <Image style={styles.linhaDivisao} source={require('../assets/img/linhaCinzaDivisao.png')}/>
                                    </View>  
                                </View>
                            )}
                        />
                </View>
            </ScrollView>
        );
    }
}

const styles = StyleSheet.create({
    font:{
        color: 'white',
        fontSize: 12,
        marginLeft: 21
    },
    linhaDivisao:{
        width: 400,
        height: 3,
        margin: 21
    },
})

export default Lancamentos
