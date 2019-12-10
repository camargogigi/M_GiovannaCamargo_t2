import React from 'react';
import ReactDOM from 'react-dom';
import Principal from './Pages/Principal';
import Login from './Pages/Login';
import listarLancamentos from './Pages/listarLancamentos';
import cadastrarCategorias from './Pages/cadastrarCategorias';
import cadastrarLancamentos from './Pages/cadastrarLancamentos';
import cadastrarUsuarioComum from './Pages/cadastrarUsuarioComum';
import cadastrarUsuario from './Pages/cadastrarUsuario';
import * as serviceWorker from './serviceWorker';
import {Route, Link, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';
import { parseJwt } from '../src/services/auth';

const RotaPrivada = () => (
    <Route 
        render={
            props =>
                parseJwt().Permissao === '2' ? (
                    <listarLancamentos {...props} />
                ) : (
                    <cadastrarLancamentos {...props} />
                )
        }
    />
);

const PermissaoADM = ({ component: Component }) => (
    <Route
        render={
            props =>
            localStorage.getItem("usuario-opflix") !== null ? (
                parseJwt().Permissao === "1" ? (
                    <Component {...props} />
                ) : (
                        <Redirect 
                        to={{ pathname: "/login", state: {from: props.location}}}
                    />
                    )
            )
                    : (
                        <Redirect 
                            to={{ pathname: "/login", state: {from: props.location}}}
                        />
                    )
        }
    />
);

const routing = (
    <Router>
        <div>
            <Switch>
            <Route exact path='/' component={Principal}/>
            <Route path='/login' component={Login}/>
            <Route path='/criarconta' component={cadastrarUsuarioComum}/>
            <RotaPrivada path='/lancamentos' component={listarLancamentos}/>
            <PermissaoADM  path='/categorias' component={cadastrarCategorias}/>
            <PermissaoADM  path='/cadastrolancamentos' component={cadastrarLancamentos}/>
            <PermissaoADM  path='/criarcontaadm' component={cadastrarUsuario}/>
            </Switch>
        </div>
    </Router>

)
ReactDOM.render(routing, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
