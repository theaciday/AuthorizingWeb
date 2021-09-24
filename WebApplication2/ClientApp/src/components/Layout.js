import React, { useEffect } from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import { useDispatch } from 'react-redux';
import userActions from '../actions/user.actions';

const Layout = (props) => {
    const dispatch = useDispatch();
    useEffect(() => {
        const token = localStorage.getItem("token")
        if (token)
            dispatch(userActions.getCurrentUser())
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