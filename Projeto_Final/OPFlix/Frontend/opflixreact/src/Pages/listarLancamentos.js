import React, {Component} from "react";
import Axios from "axios"
import Logo from "../assets/img/logo.png"
import {Route, Link, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';

class listarLancamentos extends Component{
    constructor(){
        super();
        this.state={
            lista: [],
            nome:"",
            dataEstreia:"",
            tipo:"",
            descricao: "",
            sinopse:"",
            categoria:"",
            plataforma: "", 
            tempoDuracao: ""
        };
    }
}

export default listarLancamentos