import React from 'react';
import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <div className="App">
      <h1 className="conteudoPrincipal-cadastro-titulo">Eventos</h1>
      <div className="container" id="conteudoPrincipal-lista">

        <table id="tabela-lista">
          <thead>
            <tr>
              <th>#</th>
              <th>CEP</th>
              <th>Logradouro</th>
              <th>Complemento</th>
              <th>Bairro</th>
              <th>UF</th>
            </tr>
          </thead>

          <tbody id="tabela-lista-corpo"></tbody>
        </table>

      </div>

          <input type="text" id="CEP" placeholder="CEP"/>
          <input type="text" id="Logradouro" placeholder="Logradouro"/>
          <input type="text" id="Complemento" placeholder="Complemento"/>
          <input type="text" id="Bairro" placeholder="Bairro"/>
          <select id="option_uf">
            <option value="ac">AC</option>
            <option value="al">AL</option>
            <option value="am">AM</option>
            <option value="ap">AP</option>
            <option value="ba">BA</option>
            <option value="ce">CE</option>
            <option value="df">DF</option>
            <option value="es">ES</option>
            <option value="go">GO</option>
            <option value="ma">MA</option>
            <option value="mg">MG</option>
            <option value="ms">MS</option>
            <option value="mt">MT</option>
            <option value="pa">PA</option>
            <option value="pb">PB</option>
            <option value="pe">PE</option>
            <option value="pi">PI</option>
            <option value="pr">PR</option>
            <option value="rj">RJ</option>
            <option value="rn">RN</option>
            <option value="ro">RO</option>
            <option value="rr">RR</option>
            <option value="rs">RS</option>
            <option value="sc">SC</option>
            <option value="se">SE</option>
            <option value="sp">SP</option>
            <option value="to">TO</option>
          </select>
        <div>
        <button className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro">Buscar endereço</button>
        </div>
  <footer className="rodapePrincipal">
    <section className="rodapePrincipal-patrocinadores">
      <div className="container">
        <p>Via CEP®️</p>
      </div>
    </section>
  </footer>
    </div>
  );
}

export default App;
