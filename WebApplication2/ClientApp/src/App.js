import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Home from './components/Home';
import { FetchData } from './components/FetchData';
import Counter from './components/Counter';
import Login from './components/Login';
import Register  from './components/Register'

import './custom.css'



export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout className='app-wp'>
                <Route exact path='/' component={Home} />
                <Route path='/counter' component={Counter} />
                <Route path='/fetch-data' component={FetchData} />
                <Route path='/Login' component={Login} />
                <Route path='/Register' component={Register} />
            </Layout>
            );
    }
}
