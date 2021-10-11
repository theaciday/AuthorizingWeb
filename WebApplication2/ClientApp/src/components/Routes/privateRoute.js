import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux"
import { Route, useHistory, useRouteMatch } from "react-router-dom"
import Roles from '../../Config/Roles';

const PrivateRouteComponent = (props) => {
    const history = useHistory();
    const { component: Component, roles, } = props
    const [allowRender, setAllowRender] = useState(false);
    const currentUserRole = useSelector((state) => {
        return state.authentication.user.role
    });
    const loaded = useSelector((state) => {
        return state.authentication.loaded
    });
    useEffect(() => {
        if (loaded) {
            if (currentUserRole && roles.indexOf(currentUserRole) !== -1) {
                setAllowRender(true)
            } else {
                history.push("/")
            }
        }

    }, [loaded, currentUserRole, history.push, roles]);
    
    return allowRender ? < Component {...props} /> : null
}

const PrivateRoute = ({ component, roles, ...rest }) => (
    <Route {...rest} render={() => <PrivateRouteComponent component={component} roles={roles} />}/>
)
export default PrivateRoute