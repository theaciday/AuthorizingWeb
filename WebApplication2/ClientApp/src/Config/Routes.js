import Roles from './Roles';
import Home  from '../components/Home';
import  Login  from '../components/Login';
import  Register  from '../components/Register';
import User from '../components/User';
import Admin from '../components/Admin';

export default [
    {
        component: Home,
        path: '/',
        exact: true,
    },
    {
        component: Login,
        path: '/login',
        exact: true,
    },
    {
        component: Register,
        path: '/register',
    },
    {
        component: User,
        path: '/user',
        roles: [
            Roles.ADMIN
        ], 
    },
    {
        component: Admin,
        path: '/Admin',
        roles: [
            Roles.ADMIN
        ],
    },
]