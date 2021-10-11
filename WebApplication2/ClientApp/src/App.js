import React, { Component, useCallback } from 'react';
import { Router, Route, Switch, Redirect } from 'react-router-dom';
import { Provider, connect } from "react-redux";
import Layout from './components/Layout';
import { history } from './helpers/history';
import { store } from './helpers/store';
import './custom.css'
import AlertWrapper from './wrappers/AlertWrapper';
import Routes from './Config/Routes';
import './styles/StyleSheet.scss'
import PrivateRoute from './components/Routes/privateRoute';
import AuthRoute from './components/Routes/authRoute';

const App = (props) => {

    return (
        <Provider store={store}>
            <AlertWrapper />
            <Router history={history}>
                <Switch>
                    <Layout>
                        {
                            Routes.map(routeConfig => {
                                if (routeConfig.isAuth) {
                                    return <AuthRoute key={routeConfig.path} {...routeConfig} />
                                }
                                if (routeConfig.roles) {
                                    return <PrivateRoute key={routeConfig.path}  {...routeConfig} />
                                }
                                return <Route key={routeConfig.path} {...routeConfig} />
                            }
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

