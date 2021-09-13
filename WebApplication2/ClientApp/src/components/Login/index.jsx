import React, { useState, useCallback } from 'react';
import { useHistory } from "react-router-dom";
import { Redirect } from "react-router-dom";
import './Login.module.css';
import request from '../../Utils/Request';




const Login = () => {
    const history = useHistory();
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [redirect, setRedirect] = useState(false);
    const handleChangeUserName = useCallback(e => {
        e.preventDefault()
        setUserName(e.target.value);
    }, [setUserName]);
    const handleChangePassword = useCallback(e => {
        e.preventDefault()
        setPassword(e.target.value);
    }, [setPassword]);
    const url = "auth/login";
    const handleRedirect = () => {
        history.push('/Register/');
    }
    const submit = async (e) => {
        e.preventDefault()
        const { token } = await request(url, { method: 'Post' }, { userName, password })
        localStorage.setItem('token', token)
        setRedirect(true);
    }

    if (redirect) {
        return <Redirect to="/" />
    }

    return (

        <form onSubmit={submit}>
            <h1>Login</h1>
            <input placeholder="Username" value={userName} onChange={handleChangeUserName} type="text" name="UserName" required />
            <input placeholder="Password" value={password} onChange={handleChangePassword} type="password" name="Password" required />
            <button name="button" type="submit">Submit</button>
            <div>________</div>
            <div>______</div>
            <div>____</div>
            <div>__</div>
            <h5>First time here?</h5>
            <button onClick={handleRedirect} name="submit" style={{marginTop:20}}>
                Create account
            </button>
        </form>

    );
}
export default Login;