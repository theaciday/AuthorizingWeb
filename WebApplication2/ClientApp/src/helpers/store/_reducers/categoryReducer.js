import { categoryConstants } from "../../../constants/categoryConstants"

const initialState = {
    pageNumber: '',
    pageSize: '',
    totalPages: '',
    data: [],
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
                pageNumber: action.payload.pageNumber,
                pageSize: action.payload.pageSize,
                totalPages: action.payload.totalPages,
                data: action.payload.data,
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
                data: [action.payload, ...state.data],
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
                data: state.data
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