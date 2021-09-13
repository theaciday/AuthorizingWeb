import React, { useState } from 'react';
import { useHistory } from "react-router-dom";
import { Redirect } from "react-router-dom";
import './Login.module.css';
import { createStore } from "redux";
import { useDispatch, useSelector } from "react-redux";
import request from '../../Utils/Request';

const defaultState =
{
    userName: "",
    password: "",
    id: "",
    firstName: "",
    lastName: "",
    Role: "",
}

const reducer = (state = defaultState, action) => {
    switch (action.type) {
        case "get_userName":
            return { ...state, userName: state.userName = action.userName }
        case "get_password":
            return { ...state, userName: state.password = action.password }
        default:
            return state
    }
}
const store = createStore(reducer);


const Login = () => {
    const dispatch = useDispatch();
    const userName = useSelector(state => state.userName);
    const password = useSelector(state => state.password);
    const [redirect, setRedirect] = useState(false);
    const addUserName = (userName) => {
        dispatch({ type: "get_userName", payload: userName })
    }
    const addPassword = (password) => {
        dispatch({ type: "get_password", payload: password })
    }
    const url = "auth/login";
    const handleRedirect = () => {
        history.push('/Register/');
    }
    const history = useHistory();
    const submit = async (e) => {
        e.preventDefault()
        const result = await request(url, { method: 'Post' }, { userName, password });
        const { token } = await result.json()
        localStorage.setItem('token', token)
        setRedirect(true);
    }

    if (redirect) {
        return <Redirect to="/" />
    }

    return (
        <Provider store={store}>
            <form onSubmit={submit}>
                <h1>Login</h1>
                <input placeholder="Username" value={userName} onChange={() => addUserName} type="username" name="User Name" required />
                <input placeholder="Password" value={password} onChange={() => addPassword} type="password" name="Password" required />
                <button name="button" type="submit">Submit</button>
                <div>________</div>
                <div>______</div>
                <div>____</div>
                <div>__</div>
                <h5>First time here?</h5>
                <button onClick={handleRedirect} name="submit">
                    Create account
                </button>
            </form>
        </Provider>
    );
}
export default Login;