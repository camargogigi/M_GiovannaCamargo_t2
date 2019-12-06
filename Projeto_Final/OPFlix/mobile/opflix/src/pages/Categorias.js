import React, {Component} from 'react';
import {SafeAreaView, StyleSheet, ScrollView, View, Text, StatusBar, AsyncStorage, ImageBackground, TextInput, Image, Picker} from 'react-native';
import { TouchableOpacity, FlatList } from 'react-native-gesture-handler';

class Categorias extends Component{

    static navigationOptions = {
        tabBarIcon: () => (
          <Image 
            source = {require('../assets/img/whitesearch.png')}
            style={{width: 25, height: 25, tintColor: 'white'}}
          />
        )
      }

    constructor() {
        super();
        this.state = {
            Lancamentos: [],
            categoriaEscolhida: "",
            Categorias: [],
        }
    }

    componentDidMount() {
        this._carregarCategorias();
    }

    _carregarCategorias = async () => {
        await fetch('http://192.168.4.229:5000/api/categoria', {
            headers: {
                "Accept": "application/json",
                "Authorization": "Bearer " + await AsyncStorage.getItem("@opflix:token")
            }
        })
            .then(resposta => resposta.json())
            .then(data => this.setState({ Categorias: data }))
            .catch(erro => console.warn(erro));
    };

    _carregarLancamento = async (itemValue) => {
        await fetch('http://192.168.4.229:5000/api/lancamento/categoria/' + itemValue, {
            headers: {
                "Accept": "application/json",
                "Authorization": "Bearer " + await AsyncStorage.getItem("@opflix:token")
            },
        })
            .then(resposta => resposta.json())
            .then(data => this.setState({ Lancamentos: data }))
            .catch(erro => console.warn(erro));
    };


    _listaVazia = () => { 
            return (
                <View>
                    <Text style={{ textAlign: 'center', color: "white" }}>Nenhum lançamento encontrado nessa categoria.</Text>
                </View>
            );
    };


    render() {
        return (
            <ScrollView style={{backgroundColor: 'black'}}>
                <View>
                    <View>
                    <Image style={{height: 32, width:100, margin: 15}} source={require('../assets/img/logo.png')} />
                    <View style={{alignItems: 'center'}}>
                        <Text style={{color: '#fff', fontSize: 20, marginTop: 15 }}>Buscar Lancamento</Text>
                        <Text style={{backgroundColor: '#C75E17', width: 190, height:5, borderRadius: 10}}></Text>
                    </View>
                    </View>
                    <View style={{flexDirection: 'row'}}>
                      <Picker style={{color:'#fff', fontSize:10 , backgroundColor:'#4D4949', width:155, height:30, borderRadius:30, margin:20 }}
                        selectedValue={this.state.categoriaEscolhida} 
                        onValueChange={(itemValue, itemIndex) => { 
                            this.setState({ categoriaEscolhida: itemValue })
                            this._carregarLancamento(itemValue)}}> 
                        <Picker.item label="Categoria" value="" selectedValue />
                        {this.state.Categorias.map(e => {
                            return (<Picker.item label={e.nome} value={e.idCategoria} />
                                )
                            })}
                      </Picker>
                      <Image style={{width: 25, height:25, marginTop: 23}} source={require('../assets/img/greysearch.png')}/>
                    </View>
                    <FlatList
                        data={this.state.Lancamentos}
                        ListEmptyComponent={this._listaVazia}
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
                        )} />
                </View>
            </ScrollView>
        )
    }
}

const styles = StyleSheet.create({
    font:{
        color: 'white',
        fontSize: 14,
        marginLeft: 21
    },
    linhaDivisao:{
        width: 400,
        height: 3,
        margin: 21
    },
})

export default Categorias
