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
    return request(url);
}
function getById(id) {
    return request(urlForId);
}
function getCurrentUser() {
    return request(urlcurrent);
    
}

  