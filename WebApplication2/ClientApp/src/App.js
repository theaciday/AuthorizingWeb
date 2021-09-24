import React, { Component } from 'react';
import { Router, Route, Switch, Redirect } from 'react-router-dom';
import { Provider, connect } from "react-redux";
import  Layout  from './components/Layout';
import Home from './components/Home';
import Login from './components/Login';
import Register from './components/Register';
import User from './components/User';
import { history } from './helpers/history';
import { store } from './helpers/store';
import './custom.css'
import AlertWrapper from './wrappers/AlertWrapper';
import Routes from './Config/Routes';

const PrivateRoute = (props) => {
    
}

const App = (props) => {
      
        return (
            <Provider store={store}>
                <AlertWrapper />
                <Router history={history}>
                    <Switch>
                        <Layout className='app-wp'>
                            {
                                Routes.map(routeConfig => routeConfig.permissions
                                    ? <PrivateRoute key={routeConfig.path} />
                                    : <Route key={routeConfig.path} {...routeConfig} />
                                )
                            }
                        </Layout>
                        <Redirect from="*" to="/" />
                    </Switch>
                </Router>
            </Provider>
        );   
}
export default App;


