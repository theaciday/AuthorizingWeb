import config from 'config';
import { authHeader } from '../';
import request from '../Utils/Request';

export const userService = {

    login,
    logout,
    register,
    getAll,
    getById,
    update,
    delete: _delete
};
const url = 'auth/login';
const urlForId = 'user/user';
//const url = 'auth/login';


function login(username, password) {
    return request(url, { method: 'Post' }, { username, password });
}
function logout() {
    localStorage.removeItem('user');
    localStorage.removeItem('token');
}
function getAll() {
    const token = localStorage.getItem('token')
    return request(url, { 'Authorization': `${token}` });
}
function getById(id) {
    return request(urlForId, { 'Authorization': `${token}` });
}


