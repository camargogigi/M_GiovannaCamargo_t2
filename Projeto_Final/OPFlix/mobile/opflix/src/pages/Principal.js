import React, {Component} from 'react';
import {SafeAreaView, StyleSheet,FlatList, ScrollView, View, Text, StatusBar, AsyncStorage, ImageBackground, TextInput, Image} from 'react-native';
import { TouchableOpacity } from 'react-native-gesture-handler';
import { Colors } from 'react-native/Libraries/NewAppScreen';

class Principal extends Component{
    static navigationOptions = {
        tabBarIcon: () => (
          <Image 
            source = {require('../assets/img/whitehome.png')}
            style={{width: 25, height: 25, tintColor: 'white'}}
          />
        )
      }
    render(){
        return(
            <ScrollView>
            <View style={{backgroundColor: 'black'}}>
                <View>
                <View style={{alignItems: 'center'}}>
                <Image style={{height:320, width:'100%'}} source={require('../assets/img/banner.png')}/>
                <Text style={{fontSize: 13, color: '#ffff', margin: 25}}>Teen ▪️ Musical ▪️ Realidade ▪️ Favela ▪️ Drogas</Text>
                </View>
                <Text style={styles.titulos}>Lançamentos</Text>
                <View style={{alignItems: 'center'}}>
                <Image style={{margin: 25}} source={require('../assets/img/lancamentoscirculo.png')}/>
                </View>
                <View style={{flexDirection: 'row', justifyContent: 'space-around'}}>
                <Image style={styles.lancamentosRetangulos} source={require('../assets/img/desencanto.jpg')}/>
                <Image style={styles.lancamentosRetangulos} source={require('../assets/img/cinquenta-cartaz-2.jpg')}/>
                <Image style={styles.lancamentosRetangulos} source={require('../assets/img/fJXzwxCVr2TEkhhKRKcih9o5DYK.jpg')}/>
                <Image style={styles.lancamentosRetangulos} source={require('../assets/img/how-to-get-away-with-murder-first-season.jpg')}/>
                </View>
                <Text style={{color: '#fff', fontSize: 14, marginTop:15, fontWeight: "bold"}}>Já disponível: 4 temporadas</Text>
                <Image style={{height:250, width:'100%', marginVertical:15}} source={require('../assets/img/TheGoodPlace-S2-ShowImage-1920x1080-KO.jpg')}/>
                </View>
                <Text style={{color: '#fff', fontSize: 16, marginLeft:10, fontWeight: "bold"}}>Aclamados pela crítica</Text>
                <View style={{flexDirection: 'row', justifyContent: 'space-around'}}>
                <Image style={styles.lancamentosRetangulos} source={require('../assets/img/Brooklyn.jpg')}/>
                <Image style={styles.lancamentosRetangulos} source={require('../assets/img/sherlock.jpg')}/>
                <Image style={styles.lancamentosRetangulos} source={require('../assets/img/lacasadepapel.jpg')}/>
                <Image style={styles.lancamentosRetangulos} source={require('../assets/img/Breaking-Bad.jpg')}/>
                </View>
            </View>
            </ScrollView>
        )
    }
}

const styles = StyleSheet.create({
  titulos:{
    color: '#fff', 
    fontSize: 16, 
    marginLeft: 25,
    fontWeight: "bold"
  },
  lancamentosRetangulos:{
    height:115, 
    width:84
  }
})

export default Principal
