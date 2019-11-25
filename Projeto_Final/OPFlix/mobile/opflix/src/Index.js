import {createAppContainer, createSwitchNavigator} from 'react-navigation';
import{createStackNavigator} from 'react-navigation-stack'
import {createBottomTabNavigator} from 'react-navigation-tabs';

import LoginScreen from './pages/Login';
import PrincipalScreen from './pages/Principal';
import LancamentosScreen from './pages/Lancamentos';
import BuscarCategoriaScreen from './pages/Categorias';
import BuscarDataScreen from './pages/Data';
import MaisScreen from './pages/Mais'

const AuthStack = createStackNavigator({
    Sign: {screen: LoginScreen},
});


const MainNavigator = createBottomTabNavigator(
  {
  
  Início: {
    screen: PrincipalScreen,
  },
  Lançamentos: {
    screen: LancamentosScreen,  
  },
  Categorias: {
    screen: BuscarCategoriaScreen,
  },
  Datas: {
    screen: BuscarDataScreen,
  },
  Mais: {
    screen: MaisScreen,
  },
},
{
    initialRouteName: 'Início',
    tabBarOptions: {
      showIcon: true,
      showLabel: true, 
      activeTintColor: 'white',
      inactiveBackgroundColor: '#131313',
      activeBackgroundColor: '#131313',
      style: {
        width: '100%',
        height: 50,
      },
      },
    },
  );

export default createAppContainer(createSwitchNavigator(
    {
        MainNavigator,
        AuthStack
    },
    {
        initialRouteName: 'AuthStack',
    },
));
