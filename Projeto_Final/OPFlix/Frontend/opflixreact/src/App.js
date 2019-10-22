import React from 'react';
import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <div>
      <header className="barraNavegacao">
        <div className="container">
          <nav className="barraNavegacao-nav">
            <a>Um pouco sobre nós</a>
            <a className="barraNavegacao-login" href="login.html">Entrar</a>
          </nav>
        </div>
      </header>
      <section className="conteudo-imagem">
        <h2>Tudo da OpFlix. Grátis por 30 dias.</h2>
        <img src="./img/logo.png" alt="logo" />
        <p>Enviaremos um lembrete por email 3 dias antes de seu mês
           grátis terminar.  Cancele a qualquer momento antes da data
           de expiração e você não será cobrado.</p>
        <form method="get" action="cadastrese.html"><button type="submit">EXPERIMENTE GRÁTIS POR 30 DIAS ></button></form>
      </section>
      <main className="conteudoPrincipal">
        <section id="conteudoPrincipal-SobreNos">
          <img className="linha" src="./img/linhaCinzaDivisao.png" alt="linhaDeDivisao" />
          <div className="informativo1">
            <div>
              <h2>Aproveite na TV.</h2>
              <p>Assista em Smart TVs, PlayStation, Xbox,
                Chromecast, Apple TV, aparelhos de Blu-ray e
                            outros aparelhos.</p>
            </div>
            <img src="./img/tvwithfreshprinceofbelair.png" alt="tv" />
          </div>
          <img className="linha" src="./img/linhaCinzaDivisao.png" alt="linhaDeDivisao" />
          <div className="informativo2">
            <div>
              <h2>Baixe séries e assista
                            em qualquer lugar.</h2>
              <p>Baixe suas séries e filmes favoritos e
                            assista offline</p>
            </div>
            <img src="./img/cellphonewithopflix.png" alt="celular" />
          </div>
          <img className="linha" src="./img/linhaCinzaDivisao.png" alt="linhaDeDivisao" />
          <div className="informativo3">
            <div>
              <h2>Assista quando quiser.</h2>
              <p>Assista no celular, tablet, smart TV
                           ou notebook sem pagar a mais por isso.</p>
            </div>
            <img src="./img/devicewithseries.png" alt="device" />
          </div>
          <img className="linha" src="./img/linhaCinzaDivisao.png" alt="linhaDeDivisao" />
        </section>
      </main>
      <footer className="rodapePrincipal">
        <section className="rodapePrincipal-opflix">
          <div className="container">
            <p>OpFlix Brasil 2.019®️</p>
          </div>
        </section>
      </footer>
      </div>
      );
    }
                                    
  export default App;
