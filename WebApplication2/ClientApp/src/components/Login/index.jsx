import React, { useState, useCallback } from 'react';
import { useDispatch } from 'react-redux'
import { useHistory } from "react-router-dom";
import './Login.module.css';
import userActions from '../../actions/user.actions'
import MyInput from '../../utils/TextInput';




const Login = () => {
    const history = useHistory();
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const dispatch = useDispatch()
    const handleChangeUserName = useCallback(e => {
        e.preventDefault()
        setUserName(e.target.value);
    }, [setUserName]);
    const handleChangePassword = useCallback(e => {
        e.preventDefault()
        setPassword(e.target.value);
    }, [setPassword]);
    const handleRedirect = () => {
        history.push('/Register/');
    }
    const submit = async (e) => {
        e.preventDefault()
        dispatch(userActions.login(userName, password))
    }

    return (

        <form onSubmit={submit}>
            <h1>Login</h1>
            <MyInput placeholder={"Username"} value={userName} onChange={handleChangeUserName} type={"text"} name={"UserName"} required={true} />
            <MyInput placeholder={"Password"} value={password} onChange={handleChangePassword} type={"password"} name={"Password"} required={true} />
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