import React, {Component} from 'react';
import {SafeAreaView, StyleSheet, ScrollView, View, Text, StatusBar, AsyncStorage, ImageBackground, TextInput, Image, Picker} from 'react-native';
import { TouchableOpacity, FlatList } from 'react-native-gesture-handler';

class Mais extends Component{

    static navigationOptions = {
        tabBarIcon: () => (
          <Image 
            source = {require('../assets/img/plus-math.png')}
            style={{width: 25, height: 25, tintColor: 'white'}}
          />
        )
      }

    _Logout = async (event) => {
        await AsyncStorage.removeItem("@opflix:token");
        this.props.navigation.navigate('AuthStack')
    }

    render(){
        return(
        <ScrollView style={{backgroundColor: '#000'}}>
            <View>
            <TouchableOpacity><Text style={{color: 'white'}} onPress={this._Logout}>Sair</Text></TouchableOpacity>
            </View>
        </ScrollView>
        )
    }
}
export default Mais