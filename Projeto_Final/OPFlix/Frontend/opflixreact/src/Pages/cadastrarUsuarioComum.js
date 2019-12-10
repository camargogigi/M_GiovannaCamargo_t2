import React, {Component} from "react";
import Axios from "axios"
import Logo from "../assets/img/logo.png"
import {Route, Link, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';

class cadastrarUsuarioComum extends Component{
    constructor(){
        super();
        this.state = {
            lista: [],
            nome: "",
            email: "",
            telefone: "",
            cpf: "",
            senha: "",
            idTipoUser: 2,
        };
    }
    atualizarNome = (event) => {
        this.setState({nome: event.target.value})
        console.log(this.state);
    }
    atualizarEmail = (event) => {
        this.setState({email: event.target.value})
        console.log(this.state);
    }
    atualizarTelefone = (event) => {
        this.setState({telefone: event.target.value})
        console.log(this.state);
    }
    atualizarCpf = (event) => {
        this.setState({cpf: event.target.value})
        console.log(this.state);
    }
    atualizarSenha = (event) => {
        this.setState({senha: event.target.value})
        console.log(this.state);
    }

    adicionaItem = (event) => {
        event.preventDefault();

        Axios.post('http://192.168.4.229:5000/api/usuarios', {
            nome: this.state.nome,
            email: this.state.email,
            telefone: this.state.telefone,
            cpf: this.state.cpf,
            senha: this.state.senha,
            idTipoUsuario: this.state.idTipoUser
        }, {
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json',
                    Authorization: 'Bearer ' + localStorage.getItem('usuario-opflix')
                }
            }
        )
            .then(response => {
                console.log(response)
                this.props.history.push('/lancamentos')
            })
            .catch(erro => {
                this.setState({ erro: "Não foi possível cadastrar usuário" });
                console.log(erro);
            });
    }

    render(){
        return(
        <div>
            <img src={Logo}/>
            <h1>Cadastre-se aqui!</h1>
            <form>
                <input placeholder="Nome" onInput={this.atualizarNome} type="text" name="nome" />
                <input placeholder="Email" onInput={this.atualizarEmail} type="text" name="email" />
                <input placeholder="Telefone" onInput={this.atualizarTelefone} type="text" name="telefone" />
                <input placeholder="CPF" onInput={this.atualizarCpf} type="text" name="cpf" />
                <input placeholder="Senha" onInput={this.atualizarSenha} type="password" name="senha" />
                <button onClick={this.adicionaItem}>Cadastrar</button>     
            </form>
        </div>
    )
    }

}

export default cadastrarUsuarioComum
      