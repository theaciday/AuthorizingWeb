import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux"
import { Route, useRouteMatch } from "react-router-dom"

const PrivateRouteComponent = props => {
    const { component: Component, roles, } = props
    const allowRender = useState(false);
    const router = useRouteMatch()
    const currentUserRole = useSelector((state) => {
        return state.authentication.user.role
    });
    //TRUE || FALSE 
    const loaded = useSelector((state) => {
        return state.authentication.loaded
    });
    useEffect(() => {
        if (loaded) {
            if (currentUserRole == 2) {
                router.push("/home")
            }
            else if (currentUserRole && roles.indexOf(currentUserRole) !== -1) {
                allowRender = true;
            }
        }
    }, []);
    return allowRender ? < Component {...props} /> : null
}

const PrivateRoute = ({ component, roles, ...rest }) => (
    <Route {...rest} render={<PrivateRouteComponent component={component} roles={roles} />}/>
)
export default PrivateRoute