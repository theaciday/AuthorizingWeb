import { cartConstants } from '../../../constants/cartConstants';

const initialState = {
    pageNumber: '',
    pageSize: '',
    totalPages: '',
    data: [],
    isLoading: false,
    isLoaded: false
}
export function cart(state = initialState, action) {
    switch (action.type) {
        case cartConstants.ADD_CART_ITEM_REQUEST:
            return {
                ...state,
                isLoading: false,
                isLoaded: false
            };
        case cartConstants.ADD_CART_ITEM_SUCCESS:
            return {
                ...state,
                data: [action.payload, ...state.data],
                isLoaded: true,
                isLoading: false
            };
        case cartConstants.ADD_CART_ITEM_FAILURE:
            return {
                ...state,
                isLoading: false,
                isLoaded: false
            };
        case cartConstants.GET_CART_ITEMS_REQUEST:
            return {
                ...state,
                isLoading: true,
                isLoaded: false
            };
        case cartConstants.GET_CART_ITEMS_SUCCESS:
            return {
                ...state,
                pageNumber: action.payload.pageNumber,
                pageSize: action.payload.pageSize,
                totalPages: action.payload.totalPages,
                data: action.payload.data,
                isLoading: false,
                isLoaded: true
            };
        case cartConstants.GET_CART_ITEMS_FAILURE:
            return {
                ...state,
                isLoaded: false,
                isLoading: false
            };
        case cartConstants.DELETE_CART_ITEM_REQUEST:
            return {
                ...state,
                isLoading: true,
                isLoaded: false
            };
        case cartConstants.DELETE_CART_ITEM_SUCCESS:
            return {
                ...state,
                data: state.data
                    .filter(item => item.id !== action.payload),
                isLoaded: true,
                isLoading: false
            };
        case cartConstants.DELETE_CART_ITEM_FAILURE:
            return {
                ...state,
                isLoading: false,
                isLoaded: false
            };
        case cartConstants.CHANGE_CART_ITEM_REQUEST:
            return {
                ...state,
                isLoading: true,
                isLoaded: false
            }
        case cartConstants.CHANGE_CART_ITEM_SUCCESS:
            return {
                ...state,
                data: action.payload.count === 0
                    ? state.data.filter(item => item.id !== action.payload.itemId)
                    : state.data.map(item => item.id === action.payload.itemId ?
                        {
                            ...item,
                            quantity: action.payload.count
                        }
                        : item
                    ),
                isLoaded: true,
                isLoading: false
            }
        case cartConstants.CHANGE_CART_ITEM_FAILURE:
            return {
                ...state,
                isLoading: false,
                isLoaded: false
            }
        default:
            return state
    }
}