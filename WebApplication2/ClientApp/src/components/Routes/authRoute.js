import React, { useEffect } from "react";
import { useState } from "react";
import { useSelector } from "react-redux";
import { Route, useHistory } from "react-router-dom";


const  AuthRouteComponent = (props) => {
    const history = useHistory();
    const { component: Component } = props
    const loggingIn = useSelector((state) => {
        return state.authentication.loggingIn
    });
    const [disableRender, setDisableRender] = useState(loggingIn);
    useEffect(() => {
        if (loggingIn) {
            setDisableRender(true)
            history.push("/")
        }
    }, [history.push, loggingIn]);
    return disableRender ? null : <Component{...props} />
}

const AuthRoute = ({ component, ...rest }) => (
    <Route{...rest} render={() => <AuthRouteComponent component={component} />}/>
)
export default AuthRoute