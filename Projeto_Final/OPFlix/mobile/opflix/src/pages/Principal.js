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
                <Image style={{height:320, width:'100%'}} source={require('../assets/img/banner.png')}/>
                <Text style={{fontSize: 10, color: '#ffff'}}>Teen ▪️ Musical ▪️ Realidade ▪️ Vida Real ▪️ Favela ▪️ Drogas</Text>
                <Text style={{color: '#fff'}}>Lançamentos</Text>
                <Image source={require('../assets/img/lancamentoscirculo.png')}/>
                <View style={{flexDirection: 'row', justifyContent: 'space-around'}}>
                <Image style={{height:115, width:84}} source={require('../assets/img/desencanto.jpg')}/>
                <Image style={{height:115, width:84}} source={require('../assets/img/cinquenta-cartaz-2.jpg')}/>
                <Image style={{height:115, width:84}} source={require('../assets/img/fJXzwxCVr2TEkhhKRKcih9o5DYK.jpg')}/>
                </View>
                <Image style={{height:285, width:'100%'}} source={require('../assets/img/TheGoodPlace-S2-ShowImage-1920x1080-KO.jpg')}/>
                </View>
            </View>
            </ScrollView>
        )
    }
}

export default Principal
