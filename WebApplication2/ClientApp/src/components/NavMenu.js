import React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import userActions from '../actions/user.actions';
import { useSelector, useDispatch } from 'react-redux';

const NavMenu = () => {
    const dispatch = useDispatch();
    const logginIn = useSelector((state) => {
        return state.authentication.loggingIn
    })
    const handleLogout = () => {
        dispatch(userActions.logout());
    };
    const userRole = useSelector((state) => {
        return state.authentication.user.role
    })
    
    const isAdmin = userRole === 'Admin';
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                    <Container>
                        {logginIn &&
                            (<NavbarBrand tag={Link} to="/">Home</NavbarBrand>)}
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen navbar>
                            <ul className="navbar-nav flex-grow">
                                {!logginIn &&
                                    (<NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
                                    </NavItem>)}
                                {isAdmin &&
                                    (< NavItem >
                                    <NavLink tag={Link} className="text-dark" to="/user">User</NavLink>
                                    </NavItem>)}
                                {logginIn && 
                                (<NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                                    </NavItem>)}
                                {logginIn &&
                                    (<NavItem>
                                    <NavLink tag={Link} onClick={handleLogout} className="text-dark" to="/">Logout</NavLink>
                                    </NavItem>)}
                                {isAdmin &&
                                    (< NavItem >
                                        <NavLink tag={Link} className="text-dark" to="/admin">Admin</NavLink>
                                    </NavItem>)}

                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
}
export default NavMenu;