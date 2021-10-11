import { userConstants } from '../../../constants/userConstants';

const initialState = {
    loggingIn: false,
    loading: false,
    loaded: false,
    user: {},
};

export function authentication(state = initialState, action) {
    switch (action.type) {
        case userConstants.LOGIN_USER_REQUEST:
            return {
                ...state,
                loading: true
            };
        case userConstants.LOGIN_USER_SUCCESS:
            return {
                ...state,
                loggingIn: true,
                user: action.user,
                loading: false,
                loaded: true,
            };
        case userConstants.GET_CURRENT_USER_FAILURE:
            return {
                ...state,
                loaded: true,
                loading: false,
            };
        case userConstants.LOGIN_FAILURE:
            return initialState
        case userConstants.GET_CURRENT_USER_FAILURE:
            return { ...initialState, loaded: true };
        case userConstants.GET_CURRENT_USER_SUCCESS:
            return {
                loggingIn: true,
                user: action.user,
                loading: false,
                loaded: true,
            };
        case userConstants.LOGOUT:
            return initialState;
        default:
            return state
    }
}