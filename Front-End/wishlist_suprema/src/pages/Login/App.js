import React, { Component } from 'react';
// import logo from '../../../logo.svg';
import '../Login/App.css';
import Axios from 'axios';

class App extends Component {

  constructor(props){
    super(props);

    this.state = {
      email: ""
      ,senha: ""
    }
  }

  AtualizarEstadoEmail(event){
    this.setState({ email: event.target.value})
  }

  AtualizarEstadoSenha(event){
    this.setState({ senha: event.target.value})
  }

  efetuaLogin(event){
    event.preventDefault();

    Axios.post('http://192.168.3.110:5000/api/Login', {
      email : this.state.email, senha : this.state.senha
    })
        .then(data => {
          localStorage.setItem("usuario-wishlist", data.data.token);
          this.props.history.push("/Wishlist")
          console.log(data);
        })
        .catch(erro => {console.log(erro)});

    // alert("ta funfando");
  }

  render() {
    return (
    <main className="geral">
        
        <div className="conteudo">

            <h1>WishList Suprema</h1>

            <div className="formulario">

            <form onSubmit={this.efetuaLogin.bind(this)}>

                <div className="blc bloco_email">
                    <p>E-mail</p>
                    <input
                    id="email"
                    value={this.state.email}
                    onChange={this.AtualizarEstadoEmail.bind(this)}
                    placeholder="Digite o e-mail"
                    type="email" />
                </div>

                <div className="blc bloco_senha">
                    <p>Senha</p>
                    <input 
                    id="senha"
                    value={this.state.senha}
                    onChange={this.AtualizarEstadoSenha.bind(this)}
                    placeholder="Digite a senha"
                    type="password" />
                </div>

                <button
                id="btn_entrar"
                className="btn_entrada">
                Entrar</button>

            </form>
            </div>

        </div>
    </main>
    );
  }
}

export default App;