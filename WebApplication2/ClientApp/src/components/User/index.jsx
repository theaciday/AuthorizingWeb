import React, { useState, useCallback } from "react";

const User = () =>
{
    const [id, setId] = useState("");
    const [userName, setUserName] = useState("");
    const handleChangeName = useCallback(e => {
        setId(e.target.value);
    }, [setId]);

    const submit = async (e) => {
        e.preventDefault();
        const token = localStorage.getItem('token')
        await fetch('https://localhost:5001/api/user/user', {
            headers: { 'Content-type': 'application/json', 'Authorization': `Bearer ${token}` },
            
        });
       
    }
   


    return (
        <div>
        <form onSubmit={submit}>
            <h1>Get User</h1>

            <input value={id} placeholder="Id" type="text"
                onChange={handleChangeName} required
            />
            <button onSubmit={submit}>submit</button>
            </form>
            {userName}
        </div>
    );

}
export default User;