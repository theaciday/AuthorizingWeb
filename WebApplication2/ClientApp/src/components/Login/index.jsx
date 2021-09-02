import React, { useState, useCallback } from 'react';
import { useHistory } from "react-router-dom";
import { Redirect } from "react-router-dom";
import './Login.module.css';



const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [redirect, setRedirect] = useState(false);

    const handleChangeEmail = useCallback(e => {
        setEmail(e.target.value);
    }, [setEmail]);
    const handleChangePassword = useCallback(e => {
        setPassword(e.target.value);
    }, [setPassword]);
    const handleRedirect = () => {
        history.push('/Register/');
    }
    const history = useHistory();
    const submit = async (e) => {
        e.preventDefault();
        await fetch('https://localhost:5001/api/user/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            credentials: 'include',
            body: JSON.stringify({
                email,
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
            <input placeholder="E-mail" value={email} onChange={handleChangeEmail} type="email" name="email" required />
            <input placeholder="Password" value={password} onChange={handleChangePassword} type="password" name="password" required />
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