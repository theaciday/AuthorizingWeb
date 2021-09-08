import React, { useState, useCallback } from 'react';
import { useHistory } from "react-router-dom";
import { Redirect } from "react-router-dom";
import './Login.module.css';



const Login = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [redirect, setRedirect] = useState(false);

    const handleChangeEmail = useCallback(e => {
        setUserName(e.target.value);
    }, [setUserName]);
    const handleChangePassword = useCallback(e => {
        setPassword(e.target.value);
    }, [setPassword]);
    const handleRedirect = () => {
        history.push('/Register/');
    }
    const history = useHistory();
    const submit = async (e) => {
        e.preventDefault();
        await fetch('https://localhost:5001/api/auth/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            credentials: 'include',
            body: JSON.stringify({
                userName,
                password
            })
        });
        setRedirect (true);
    }
    if (redirect) {
        return <Redirect to="/" />
    }

    return (

        <form onSubmit={submit}>
            <h1>Login</h1>
            <input placeholder="Username" value={userName} onChange={handleChangeEmail} type="username" name="User Name" required />
            <input placeholder="Password" value={password} onChange={handleChangePassword} type="password" name="Password" required />
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

    );
}
export default Login;