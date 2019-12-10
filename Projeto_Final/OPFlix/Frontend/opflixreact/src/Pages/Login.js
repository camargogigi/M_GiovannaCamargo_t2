import React, {Component} from "react";
import Axios from "axios"
import Logo from "../assets/img/logo.png"
import {Route, Link, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';

class Login extends Component{
    constructor(){
        super();
        this.state = {
            email: "" ,
            senha: "" ,
            erro: ""
        }
    }

    atualizaEstadoEmail = (event) => {
        this.setState({ email: event.target.value });
    }

    atualizaEstadoSenha = (event) => {
        this.setState({ senha: event.target.value });
    }
    efetuarLogin = (event) => {
        event.preventDefault();

        Axios.post("http://192.168.4.229:5000/api/login", {
            email: this.state.email,
            senha: this.state.senha
        })
            .then(response => {
                if (response.status === 200) {
                    console.log(response.data.token);
                    localStorage.setItem("usuario-opflix", response.data.token);
                    this.props.history.push('/lancamentos');
                } else {
                    console.log('eitaa');
                }
            })
            .catch(erro => {
                this.setState({ erro: "Usuário ou senha inválidos" });
                console.log(erro);
            });
    }

    render(){
        return(
            <div>
            <div>
                <img src={Logo}/>
            </div>
            <div>
                <h1>Entrar</h1>
                <form onSubmit={this.efetuarLogin}>
                    <input placeholder="Email" onInput={this.atualizaEstadoEmail} type="text" name="email" />
                    <input placeholder="Senha" onInput={this.atualizaEstadoSenha} type="password" name="senha" />
                    <button>Entrar</button>     
                </form>
                <div>
                    <p>Não possui conta?</p> <Link to="/criarconta">Cadastre-se</Link>
                </div>
            </div>
            <footer>
                <p>OpFlix Brasil 2.019 ®️</p>
            </footer>
            </div>
        )
    }
}
export default Login;