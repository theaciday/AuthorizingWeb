import React, { Component } from 'react';
import { Router, Route, Switch, Redirect } from 'react-router-dom';
import { Provider, connect } from "react-redux";
import { Layout } from './components/Layout';
import Home from './components/Home';
import Login from './components/Login';
import Register from './components/Register';
import User from './components/User';
import { history } from './helpers/history';
import { store } from './helpers/store';
import './custom.css'
import AlertWrapper from './wrappers/AlertWrapper';




export default class App extends Component {
    constructor(props) {
        super(props);
    }
      
    render() {  
        return (
            <Provider store={store}>
                <AlertWrapper />
                <Router history={history}>
                    <Switch>
                        <Layout className='app-wp'>
                            <Route exact path='/' component={Home} />
                            <Route path='/login' component={Login} />
                            <Route path='/register' component={Register} />
                            <Route path='/user' component={User} />
                        </Layout>
                        <Redirect from="*" to="/" />
                    </Switch>
                </Router>
            </Provider>
        );
    }
}


