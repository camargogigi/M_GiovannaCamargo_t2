import React, {Component} from 'react';

class Titulo extends Component{
    render(){
        return(
            <h1 className="conteudoPrincipal-cadastro-titulo">{this.props.Titulo}</h1>
        );
    }
}

export default Titulo;