import React, {Component} from 'react';
import ReactDOM from 'react-dom';


class Principal extends Component{
    render(){
        return(
            <body>
            <nav>
                <p>Um pouco sobre nós</p>
                <button>Entrar</button>
            </nav>
            <div>
                <div>
                <p>Tudo da Opflix.</p>
                <p>Grátis por 30 dias.</p>
                </div>
                <img src="../assets/img/logo.png"/>
                <pre>Enviaremos um lembrete por email 3 dias antes de seu mês
                grátis terminar. Cancele a qualquer momento antes da data
                de expiração e você não será cobrado.</pre>
            </div>
            </body>

        )
    }
}

export default Principal
