import React, { useState, useCallback } from "react";
import request from "../../utils/Request.js";



const User = () => {
    const [id, setId] = useState("");
    const [userName, setUserName] = useState("");
    const handleChangeName = useCallback(e => {
        setId(e.target.value);
    }, [setId]);
    const onSubmit = async (e) => {
        e.preventDefault()
        const token = localStorage.getItem('token');
        if (token) {
            const result = await request(`user/${id}`)
            setUserName(result.firstName)
        }
    };
    

    return (
        <div>
            <form onSubmit={onSubmit}>  
                <h1>Get User</h1>

                <input value={id} placeholder="Id" type="text"
                    onChange={handleChangeName} required
                />
                <button type="submit">submit</button>
            </form>
            {userName}
        </div>
    );

}
export default User;