import React, { useState, useCallback } from "react";
import request from "../../Utils/Request";
import { createStore } from "redux";

const defaultState = {

}

/*action = { type:"",payload:"" }*/
const reducer = (state,action) =>
{
    switch (action.type) {

        default:
            return state
    }

}


const User = () => {
    const [id, setId] = useState("");
    const [userName, setUserName] = useState("");
    const handleChangeName = useCallback(e => {
        setId(e.target.value);
    }, [setId]);

    const onSubmit = async (e) => {
        e.preventDefault()
        const result = await request(`user/user/${id}`)
        setUserName(result.firstName)

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