import React, {Component} from 'react';
import ReactDOM from 'react-dom';
import {Link} from "react-router-dom"
import Logo from "../assets/img/logo.png"
import LinhaDivisao from "../assets/img/linhaCinzaDivisao.png"
import TvWillSmith from "../assets/img/tvwithfreshprinceofbelair.png"
import CellPhoneST from "../assets/img/cellphonewithopflix.png"
import DeviceOITNB from "../assets/img/devicewithseries.png"


class Principal extends Component{
    render(){
        return(
            <body>
            <nav className= "barraNavegacao">
                <p>Um pouco sobre nós</p>
                <Link to="/login" className='irLogin'>Entrar</Link>
            </nav>
            <div className="banner">
                <div>
                <p>Tudo da Opflix.</p>
                <p>Grátis por 30 dias.</p>
                </div>
                <img src={Logo}/>
                <p>Enviaremos um lembrete por email 3 dias antes de seu </p>
                <p>grátis terminar. Cancele a qualquer momento antes da data</p>
                <p>de expiração e você não será cobrado.</p>
                <button><Link to="/criarconta">EXPERIMENTE GRÁTIS POR 30 DIAS ></Link></button>
            </div>
            <div className="informativo">
                <img src={LinhaDivisao}/>
                <h3>Aproveite na TV.</h3>
                <p>Assista em Smart TVs, PlayStation, Xbox,</p>
                <p>Chromecast, Apple TV, aparelhos de Blu-ray e</p>
                <p>outros aparelhos.</p>
                <img src={TvWillSmith}/>
            </div>
            <div className="informativo">
                <img src={LinhaDivisao}/>
                <img src={CellPhoneST}/>
                <h3>Baixe séries e assista</h3> 
                <h3>em qualquer lugar.</h3>
                <p>Baixe suas séries e filmes favoritos e</p>
                <p>assista offline.</p>
            </div>
            <div className="informativo">
                <img src={LinhaDivisao}/>
                <h3>Assista quando quiser.</h3>
                <p>Assista no celular, tablet, smart TV</p>
                <p>ou notebook sem pagar a mais por isso.</p>
                <img src={DeviceOITNB}/>
            </div>
            <footer>
                <img src={LinhaDivisao}/>
                <p>OpFlix Brasil 2.019 ®️</p>
            </footer>
            </body>

        )
    }
}

export default Principal
