import React, { Component } from 'react';

class App extends Component {

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

// export default App;