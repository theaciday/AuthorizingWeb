import { alertContains } from "../constants";

export function alert(state = {}, action) {
    switch (action.type) {
        case alertContains.SUCCESS:
            return {
                type: 'alert-success',
                message: action.message
            };
        case alertContains.ERROR:
            return {
                type: 'alert-danger',
                message: action.message
            };
        case alertContains.CLEAR:
            return {};
        default:
            return state
    }
}
