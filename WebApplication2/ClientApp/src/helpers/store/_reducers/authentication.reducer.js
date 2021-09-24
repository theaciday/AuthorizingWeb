﻿import { userConstants } from '../../../constants/userConstants';

const initialState = {
    loggingIn: false,
    loading: false,
    user: {},
};

export function authentication(state = initialState, action) {
    switch (action.type) {
        case userConstants.LOGIN_REQUEST:
            return {
                ...state,
                loading: true
            };
        case userConstants.LOGIN_SUCCESS:
            return {
                ...state,
                loggingIn: true,
                user: action.user
            };
        case userConstants.LOGIN_FAILURE:
            return initialState;
        case userConstants.GET_CURRENT_USER_SUCCESS:
            return {
                loggingIn: true,
                user: action.user,
                loading: false
            };
        case userConstants.LOGOUT:
            return initialState;
        default:
            return state
    }
}