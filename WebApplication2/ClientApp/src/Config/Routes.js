import { Roles } from 'config';
import { Home, Login, Logout, Register, User } from './../components';

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
        permissions: [
            Roles.ADMIN
        ],
    },
]