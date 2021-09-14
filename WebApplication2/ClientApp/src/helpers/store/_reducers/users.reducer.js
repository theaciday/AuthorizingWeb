import { userConstants } from "../../../constants/userConstants";

export function users(state = {}, action) {
    switch (action.type) {
        case userConstants.GET_USER_REQUEST:
            return { loadding: true };
        case userConstants.GET_USER_SUCCESS:
            return { items: action.users };
        case userConstants.GET_USER_FAILURE:
            return { error: action.error };
        case userConstants.DELETE_REQUEST:
            return {
                ...state,
                items: state.items.map(user =>
                    user.id === action.id
                        ? { ...user, deleting: true }
                        : user
                )
            };
        case userConstants.DELETE_SUCCESS:
            return { items: state.items.filter(user => user.id !== action.id) };
        case userConstants.DELETE_FAILURE:
            return {
                ...state,
                items: state.items.map(user =>
                {
                    if (user.id === action.id) {
                        const { deleting, ...userCopy } = user;
                        return { ...userCopy, deleteError: action.error };
                    }
                    return user;
                })
            };
        default:
            return state
    }


}