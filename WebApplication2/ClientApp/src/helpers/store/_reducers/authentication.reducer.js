import { userConstants } from '../../../constants/userConstants';

const initialState = {
    loggingIn: false,
    user: {},
};

export function authentication(state = initialState, action) {
    switch (action.type) {
        case userConstants.LOGIN_REQUEST:
            return {
                ...state,
                loggingIn: true
            };
        case userConstants.LOGIN_SUCCESS:
            return {
                ...state,
                loggedIn: true,
                user: action.user
            };
        case userConstants.LOGIN_FAILURE:
            return initialState;
        case userConstants.GET_CURRENT_USER_SUCCESS:
            return {
                loggedIn: true,
                user: action.user,
            };
        case userConstants.LOGOUT:
            return initialState;
        default:
            return state
    }
}