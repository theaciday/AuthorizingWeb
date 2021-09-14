import React, { useEffect, useState } from 'react';
import { Redirect } from 'react-router-dom';
import userActions from '../../actions/user.actions';
import request from '../../Utils/Request';
//import cookies from 'browser-cookies';
//cookies.get('firstName');

const Home = () => {
    useEffect(() => {
        localStorage.getItem("token")
        if ("token")
            dispatch(userActions)

            
    }, []);

    return (
        <div>
            {userName ? 'Welcome' + userName : 'Hello,stranger!'}
            Please,login or register 
           {/* {'Welcome' + userName}*/}
        </div>
    );
};
export default Home;