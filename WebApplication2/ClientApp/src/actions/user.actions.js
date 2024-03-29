﻿import { userConstants } from '../constants/userConstants';
import { userService } from '../services/user.service';
import { alertActions } from '../actions/alertActions';
import { history } from '../helpers/history';

function getCurrentUserFailure(error) { return { type: userConstants.GET_CURRENT_USER_FAILURE, error } }

function getCurrentUser() {
    return dispatch => {
        dispatch(request());
        userService.getCurrentUser()
            .then(
                user => {
                    dispatch(success(user));
                    const { token } = user;
                    localStorage.setItem('token', token);
                },
                error => {
                    dispatch(getCurrentUserFailure(error.toString()));
                }
            );
    };
    function request() { return { type: userConstants.GET_CURRENT_USER_REQUEST } }
    function success(user) { return { type: userConstants.GET_CURRENT_USER_SUCCESS, user } }
}

function login(username, password) {
    return dispatch => {
        dispatch(request());
        userService.login(username, password)
            .then(
                user => {
                    dispatch(success(user));
                    const { token } = user;
                    localStorage.setItem('token', token);
                    history.push('/');
                },
                error => {
                    dispatch(failure(error.toString()));
                }
            );
    };
    function request(user) { return { type: userConstants.LOGIN_USER_REQUEST, user } }
    function success(user) { return { type: userConstants.LOGIN_USER_SUCCESS, user } }
    function failure(error) { return { type: userConstants.LOGIN_FAILURE, error } }
}

function logout() {
    userService.logout();
    return { type: userConstants.LOGOUT };
}
function register(user) {
    return dispatch => {
        dispatch(request(user));

        userService.register(user)
            .then(
                user => {
                    dispatch(success());
                    history.push('/');
                    dispatch(alertActions.success('Registration successful'));
                },
                error => {
                    dispatch(failure(error.toString()));
                    dispatch(alertActions.error(error.toString()));
                }
            );
    };
    function request(user) { return { type: userConstants.REGISTER_REQUEST, user } }
    function success(user) { return { type: userConstants.REGISTER_SUCCESS, user } }
    function failure(error) { return { type: userConstants.REGISTER_FAILURE, error } }
}
function getById() {
    return dispatch => {
        dispatch(request());
        userService.getById()
            .then(
                user => dispatch(success(user)),
                error => dispatch(failure(error.toString()))
            );
    };
    function request() { return { type: userConstants.GETALL_REQUEST } }
    function success(users) { return { type: userConstants.GETALL_SUCCESS, users } }
    function failure(error) { return { type: userConstants.GETALL_FAILURE, error } }
}

function _delete(id) {
    return dispatch => {
        dispatch(request(id));

        userService.delete(id)
            .then(
                user => dispatch(success(id)),
                error => dispatch(failure(id, error.toString()))
            );
    };

    function request(id) { return { type: userConstants.DELETE_CATEGORY_REQUEST, id } }
    function success(id) { return { type: userConstants.DELETE_USER_SUCCESS, id } }
    function failure(id, error) { return { type: userConstants.DELETE_USER_FAILURE, id, error } }
}

export default {
    getCurrentUser,
    login,
    logout,
    register,
    delete: _delete,
    getCurrentUserFailure,
};
