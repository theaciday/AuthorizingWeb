import { categoryConstants } from "../../../constants/categoryConstants"

const initialState = {
    categories: [],
    isLoading: false,
    isLoaded: false
};

export function category(state = initialState, action) {
    switch (action.type) {
        case categoryConstants.GET_CATEGORY_REQUEST:
            return {
                ...state,
                isLoading: true,
                isLoaded: false
            };
        case categoryConstants.GET_CATEGORY_SUCCESS:
            return {
                ...state,
                categories: action.payload,
                isLoading: false,
                isLoaded: true
            };
        case categoryConstants.GET_CATEGORY_FAILURE:
            return {
                ...state,
                isLoading: false,
                isLoaded: false
            };
        case categoryConstants.CREATE_CATEGORY_REQUEST:
            return {
                ...state,
                isLoading: true,
                isLoaded: false
            }
        case categoryConstants.CREATE_CATEGORY_SUCCESS:
            return {
                ...state,
                categories: [action.payload, ...state.categories],
                isLoading: false,
                isLoaded: true
            }
        case categoryConstants.CREATE_CATEGORY_FAILURE:
            return {
                ...state,
                isLoading: false,
                isLoaded: false
            }
        case categoryConstants.DELETE_CATEGORY_REQUEST:
            return {
                ...state,
                isLoading: true,
                isLoaded: false
            }
        case categoryConstants.DELETE_CATEGORY_SUCCESS:
            return {
                ...state,
                categories: state.categories
                    .filter(category => category.id !== action.payload),
                isLoading: false,
                isLoaded: true
            }
        case categoryConstants.DELETE_CATEGORY_FAILURE:
            return {
                ...state,
                isLoaded: false,
                isLoading: false
            }

        default:
            return state
    }

}