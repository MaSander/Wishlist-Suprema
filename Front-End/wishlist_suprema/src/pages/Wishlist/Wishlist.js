import React, { Component } from 'react';
import '../../assets/css/wishlist.css'

import Axios from 'axios'

class Wishlist extends Component {
    constructor(event) {
        super(event);
        this.state = {
            lista: [],
            desejo: ""
        }
    }

    cadastrarDesejo(event) {
        event.preventDefault();

        Axios.post('http://192.168.3.110:5000/api/Desejo', { desejo: this.state.desejo }, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-wishlist')
            }
        })
            .then(res => {
                this.buscarListaDesejos();
            })

    }

    buscarListaDesejos() {
        Axios.get('http://192.168.3.110:5000/api/Desejo',{
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-wishlist')
            }
        })
            .then(res => {
                const listadesejos = res.data;
                console.log(res);
                this.setState({ lista: listadesejos });         
            })
    }

    componentDidMount() {
        this.buscarListaDesejos();
    }
    
    atualizarStateDesejo(event) {
        event.preventDefault();
        this.setState({ desejo: event.target.value })
    }


    render() {
        return (

            <div className="background">
                <header>
                    <h1>Wishlist Suprema</h1>

                    <div className="desejar">
                        <form onSubmit={this.cadastrarDesejo.bind(this)}>
                            <input id="desejo" placeholder="Insira um desejo" type="text" value={this.state.desejo} onChange={this.atualizarStateDesejo.bind(this)} />
                            <button className="btn_desejo">Desejar</button>
                        </form>
                    </div>
                </header>

                <main>

                    <table id="tabela-lista">
                        <thead>
                            <tr>
                                <th>Desejos</th>
                            </tr>
                        </thead>

                        <tbody id="tabela-lista-corpo">
                            {
                                this.state.lista.reverse().map(function (listadesejos) {
                                    return (
                                        <tr key={listadesejos.id}>
                                            <td>{listadesejos.desejo}</td>
                                        </tr>
                                    )
                                })
                            }
                        </tbody>

                    </table>

                </main>
            </div>
        );
    }
}

export default Wishlist;