
import React, { useState, useCallback } from "react";
import { Redirect } from "react-router-dom";


const User = () =>
{
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [redirect, setRedirect] = useState(false);

    const handleChangeName = useCallback(e => {
        setName(e.target.value);
    }, [setName]);
    const handleChangeEmail = useCallback(e => {
        setEmail(e.target.value);
    }, [setEmail]);
    const handleChangePassword = useCallback(e => {
        setPassword(e.target.value);
    }, [setPassword]);
    const submit = async (e) => {
        e.preventDefault();
        await fetch('https://localhost:5001/api/auth/register', {
            method: "POST",
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify({
                name,
                email,
                password
            })

        });
        setRedirect(true);
    }
    if (redirect) {
        return <Redirect to="/Login" />
    }


    return (
        <form onSubmit={submit}>
            <h1>Registration</h1>
            <h4>Name</h4>
            <input value={name} placeholder="Name" type="text"
                onChange={handleChangeName} required
            />
            <h4>Email</h4>
            <input value={email} placeholder="Email" type="email"
                onChange={handleChangeEmail} required
            />
            <h4>Password</h4>
            <input value={password} placeholder="Password" type="password"
                onChange={handleChangePassword} required
            />

            <button onSubmit={submit}>submit</button>
        </form>
    );

}
export default User;