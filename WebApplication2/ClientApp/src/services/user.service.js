import { authHeader } from '../';
import request from '../utils/Request';

export const userService = {
    login,
    logout,
    getCurrentUser,
    getById,
};
const url = 'auth/login';
const urlForId = 'user/';
const urlcurrent = 'user/current';


function login(username, password) {
    return request(url, { method: 'Post' }, { username, password });
}
function logout() {
    localStorage.removeItem('user');
    localStorage.removeItem('token');
}
function getAll() {
    const token = localStorage.getItem(token)
    return request(url, { 'Authorization': `${token}` });
}
function getById(id) {
    const token = localStorage.getItem(token)
    return request(urlForId, { 'Authorization': `${token}` });
}
function getCurrentUser() {
    const token = localStorage.getItem("token")
    return request(urlcurrent, { 'Authorization': `${token}` });
    
}

  