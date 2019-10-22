import React, { Component } from 'react';

class App extends Component {

  constructor() {
    super();
    this.state = {
      cep: "" ,
      logradouro: "" ,
      complemento: "" ,
      bairro: "" ,
      localidade: "" ,
      uf: "" ,
      unidade: "" ,
      ibge: "" ,
      gia: "" 
    }
  }

  mudaCEP = (event) => {
    this.setState({ cep: event.target.value })
    // console.log(this.state.CEP)
  }

  consultarCEP = () => {
    fetch('https://viacep.com.br/ws/' + this.state.cep + '/json/')
    .then(Response => Response.json())
    .then(data => {
      this.setState(data);
      console.log(this.state)
    })
    .catch(erro => console.log('catch', erro))
  }

  render() {
    return (
      <div className="App">
        <div>
          <input
            type="text"
            onChange={this.mudaCEP}
          />
          <button
            onClick={this.consultarCEP}
          >
            Consultar
          </button>
          <table>
            <thead>
              <tr>
                <th>CEP</th>
                <th>Logradouro</th>
                <th>Complemento</th>
                <th>Bairro</th>
                <th>Localidade</th>
                <th>Unidade</th>
                <th>IBGE</th>
                <th>GIA</th>
              </tr>
            </thead>
            <tbody>
              <tr>
              <td>{this.state.cep}</td>
              <td>{this.state.logradouro}</td>
              <td>{this.state.complemento}</td>
              <td>{this.state.bairro}</td>
              <td>{this.state.localidade}</td>
              <td>{this.state.unidade}</td>
              <td>{this.state.ibge}</td>
              <td>{this.state.gia}</td>
            </tr>
            </tbody>
          </table>
        </div>
      </div>
    );
  }
}

export default App;
