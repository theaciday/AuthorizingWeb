﻿import { Redirect } from "react-router-dom";
import React from 'react';

const Logout = () => {

    const logout= localStorage.clear("token");
        return <Redirect to="/" />
    
}
export default Logout;