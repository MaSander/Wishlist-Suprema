import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './pages/Login/App';
import Wishlist from './pages/Wishlist/Wishlist';
import { usuarioAutenticado } from './services/auth';

import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';
import * as serviceWorker from './serviceWorker';

const Permissao = ({component : Component}) => (
    <Route 
        render = {props => usuarioAutenticado() ?
            (<Component {...props}/>) :
            (<Redirect to={{ pathname : '/Wishlist', state : {from: props.location}}} />)
        }
    />
);

const rotas = (
    <Router>
        <div>
            <Switch>
                <Route exact path='/' component={App} />
                <Permissao path='/Wishlist' component={Wishlist} />
            </Switch>
        </div>
    </Router>
);

ReactDOM.render(rotas, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
