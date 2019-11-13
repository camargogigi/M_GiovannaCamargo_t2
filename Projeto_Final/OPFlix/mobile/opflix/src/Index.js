import {createAppContainer, createSwitchNavigator} from 'react-navigation';
import{createStackNavigator} from 'react-navigation-stack'
import {createBottomTabNavigator} from 'react-navigation-tabs';

import LoginScreen from './pages/Login';
import LancamentosScreen from './pages/Lancamentos';
import BuscarCategoriaScreen from './pages/Categorias';
import BuscarDataScreen from './pages/Data';

const AuthStack = createStackNavigator({
    Sign: {screen: LoginScreen},
});


const MainNavigator = createBottomTabNavigator({
  Lancamentos: {
    screen: LancamentosScreen,
  },
  BuscarCategoria: {
    screen: BuscarCategoriaScreen,
  },
  BuscarData: {
    screen: BuscarDataScreen,
  },
});

export default createAppContainer(createSwitchNavigator(
    {
        MainNavigator,
        AuthStack
    },
    {
        initialRouteName: 'AuthStack',
    },
));
