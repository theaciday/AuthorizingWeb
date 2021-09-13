const defaultState =
{
    userName: "",
    id: "",
    firstName: "",
    lastName: "",
    Role: "",
}

export const loginReducer = (state = defaultState, action) => {
    switch (action.type) {
        case "get_userName":
            return { ...state, userName: state.userName = action.userName }
        case "get_password":
            return { ...state, userName: state.password = action.password }
        default:
            return state
    }
}