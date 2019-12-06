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
          <Image style={{height: 32, width:100, margin: 15}} source={require('../assets/img/logo.png')} />
          <View style={{alignItems: 'center'}}>
              <Text style={{color: '#fff', fontSize: 20, marginTop: 15 }}>Mais</Text>
              <Text style={{backgroundColor: '#C75E17', width: 60, height:5, borderRadius: 10}}></Text>
          </View>
          </View>
            <View>
            <TouchableOpacity><Text style={{color: 'white', fontSize: 14, margin: 30 }} onPress={this._Logout}>Sair</Text></TouchableOpacity>
            </View>

        </ScrollView>
        )
    }
}
export default Mais