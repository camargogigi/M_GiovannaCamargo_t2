import React, {Component} from 'react';
import {SafeAreaView, StyleSheet, ScrollView, View, Text, StatusBar, AsyncStorage, ImageBackground, TextInput, Image, Picker} from 'react-native';
import { TouchableOpacity, FlatList } from 'react-native-gesture-handler';

class Data extends Component{

    static navigationOptions = {
        tabBarIcon: () => (
          <Image 
            source = {require('../assets/img/whitecalendar.png')}
            style={{width: 25, height: 25, tintColor: 'white'}}
          />
        )
      }

    constructor () {
        super ();
        this.state = {
            Lancamentos: [],
            MesEscolhido: "",
        }
    }
    
    _carregarLancamento = async (itemValue) => {
    await fetch('http://192.168.4.229:5000/api/lancamento/data/' + itemValue, {
        headers:{
            "Accept": "application/json",
            "Authorization": "Bearer " + await AsyncStorage.getItem("@opflix:token")
        },
    })
        .then(resposta => resposta.json())
        .then(data => this.setState({Lancamentos: data}))
        .catch(erro => console.warn(erro));
    };

    _listaVazia = () => { 
            return (
                <View>
                    <Text style={{ textAlign: 'center', color: "white" }}>Nenhum lançamento encontrado nesse mês.</Text>
                </View>
            );
    };

    _Logout = async (event) => {
        await AsyncStorage.removeItem("@opflix:token");
        this.props.navigation.navigate('AuthStack')
    }

    render () {
        return (
            <ScrollView style={{backgroundColor: 'black'}}>
                <View>
                <View>
                <Image style={{height: 32, width:100}} source={require('../assets/img/logo.png')} />
                <TouchableOpacity><Text style={styles.Sair} onPress={this._Logout}>Sair</Text></TouchableOpacity>
                    </View>
                    <Text style={styles.h1}>Busque os lançamentos de cada mês</Text>
                    <Picker 
                    style={styles.Picker} 
                    selectedValue={this.state.MesEscolhido} 
                    onValueChange={(itemValue, itemIndex) => { 
                        this.setState({ MesEscolhido: itemValue })
                        this._carregarLancamento(itemValue)}}>
                        <Picker.item label="Escolha o mês desejado" value="" selectedValue/>
                        <Picker.item label="Janeiro" value="1"/>
                        <Picker.item label="Fevereiro" value="2"/>
                        <Picker.item label="Março" value="3"/>
                        <Picker.item label="Abril" value="4"/>
                        <Picker.item label="Maio" value="5"/>
                        <Picker.item label="Junho" value="6"/>
                        <Picker.item label="Julho" value="7"/>
                        <Picker.item label="Agosto" value="8"/>
                        <Picker.item label="Setembro" value="9"/>
                        <Picker.item label="Outubro" value="10"/>
                        <Picker.item label="Novembro" value="11"/>
                        <Picker.item label="Dezembro" value="12"/>
                    </Picker>
                    <FlatList style={styles.FlatList} data={this.state.Lancamentos} keyExtractor={item => item.idLancamento} ListEmptyComponent={this._listaVazia} renderItem={({item}) => (
                        <View style={styles.div}>
                            <Text style={styles.font}>Nome: {item.nome}</Text>
                            <Text style={styles.font}>Data de estreia: {item.dataEstreia}</Text>
                            <Text style={styles.font}>Tipo: {item.idTipoNavigation.nome}</Text>
                            <Text style={styles.font}>Descrição: {item.descricao}</Text>
                            <Text style={styles.font}>Sinopse: {item.sinopse}</Text>
                            <Text style={styles.font}>Categoria: {item.idCategoriaNavigation.nome}</Text>
                            <Text style={styles.font}>Tempo de duração:{item.tempoDuracao}</Text>
                            <Text style={styles.font}>Plataforma disponível: {item.idPlataformaNavigation.nome}</Text>
                            <Image style={styles.linhaDivisao} source={require('../assets/img/linhaCinzaDivisao.png')}/>
                        </View>
                    )}
                    />
                </View>
            </ScrollView>
        )
    }
}

const styles = StyleSheet.create({
    font:{
        color: 'white',
        fontSize: 11,
        marginLeft: 21
    },
    linhaDivisao:{
        width: 305,
        height: 3,
        marginTop: 21,
        marginEnd: 21,
    },
})

export default Data
