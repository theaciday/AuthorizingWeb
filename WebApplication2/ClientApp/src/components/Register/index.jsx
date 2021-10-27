import React, { useState, useCallback } from "react";
import { Redirect } from "react-router-dom";
import MyInput from "../../utils/TextInput";


const Register = () => {
    const [redirect, setRedirect] = useState(false);
    const [userName ,setUserName] = useState('');
    const [password ,setPassword] = useState('');
    const [email ,setEmail] = useState('');
    const [firstName ,setFirstName] = useState('');
    const [lastName, setLastName] = useState('');

    const handleChangeEmail =  useCallback(e => {
        setEmail(e.target.value);
    }, [setEmail]);
    const handleChangePassword = useCallback(e => {
        setPassword(e.target.value);
    }, [setPassword]);
    const handleChangeFirstName = useCallback(e => {
        setFirstName(e.target.value);
    }, [setFirstName]);
    const handleChangeLastName =  useCallback(e => {
        setLastName(e.target.value);
    }, [setLastName]);
    const handleChangeUserName = useCallback(e => {
        setUserName(e.target.value);
    }, [setUserName]);
    

    const submit = async (e) => {
        e.preventDefault();
        await fetch('https://localhost:5001/api/auth/register', {
            method: "POST",
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify({
                firstName,
                email,
                password,
                userName,
                lastName,  
            })
        });
      
        setRedirect(true);
    }
    if (redirect) {
        return <Redirect to="/" />
    }

    return (
        <form onSubmit={submit}>
            <h1>Registration</h1>
            <h4>Username</h4>
            <MyInput value={userName} placeholder={"Username"} type={"text"}
                onChange={handleChangeUserName} required={true}
            />
            <h4>Email</h4>
            <MyInput value={email} placeholder={"Email"} type={"email"}
                onChange={handleChangeEmail} required={true}
            />
            <h4>Password</h4>
            <MyInput value={password} placeholder={"Password"} type={"password"}
                onChange={handleChangePassword} required={true}
            />
            <h4>Fist Name</h4>
            <MyInput value={firstName} placeholder={"name"} type={"name"}
                onChange={handleChangeFirstName} required={true}
            />
            <h4>Last Name</h4>
            <MyInput value={lastName} placeholder="name" type="name"
                onChange={handleChangeLastName} 
            />

            <button style={{ fontSize: "3rem", color: "black", backgroundColor: "rosybrown" }} onSubmit={submit}>submit</button>
        </form>
    );

}
export default Register;