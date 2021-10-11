import React, { useEffect } from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import { useDispatch, useSelector } from 'react-redux';
import userActions from '../actions/user.actions';

const Layout = (props) => {
    const dispatch = useDispatch();
    useEffect(() => {
        const token = localStorage.getItem("token")
        if (token)
            dispatch(userActions.getCurrentUser())
        else
            dispatch(userActions.getCurrentUserFailure())
    }, []);


    return (
        <div>
            <NavMenu />
            <Container>
                {props.children}
            </Container>
        </div>
    );
}
export default Layout;