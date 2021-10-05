import { productConstants } from '../../../constants/productConstants'

const initialState = {

    products: [],
    isLoading: false,
    isLoaded: false
};

export function product(state = initialState, action) {
    switch (action.type) {
        case productConstants.CREATE_PRODUCT_REQUEST:
            return {
                ...state,
                isLoading: true,
                isLoaded: false
            };
        case productConstants.CREATE_PRODUCT_SUCCESS:
            return {
                ...state,
                products: [action.payload, ...state.products],
                isLoaded: false,
                isLoading: true
            }
        case productConstants.CREATE_PRODUCT_FAILURE:
            return {
                ...state,
                isLoading: false,
                isLoaded: false
            }
        case productConstants.GETALL_PRODUCTS_REQUEST:
            return {
                ...state,
                isLoaded: false,
                isLoading: true
            }
        case productConstants.GETALL_PRODUCTS_SUCCESS:
            return {
                ...state,
                products: action.payload,
                isLoading: false,
                isLoaded: true
            }
        case productConstants.GETALL_PRODUCTS_FAILURE:
            return {
                ...state,
                isLoaded: false,
                isLoading: false
            }
        case productConstants.DELETE_PRODUCT_REQUEST:
            return {
                ...state,
                isLoading: true,
                isLoaded: false
            }
        case productConstants.DELETE_PRODUCT_SUCCESS:
            return {
                ...state,
                products: state.products
                    .filter(product => product.id !== action.payload),
                isLoading: false,
                isLoaded: true
            }
        case productConstants.DELETE_PRODUCT_FAILURE:
            return {
                ...state,
                isLoading: false,
                isLoaded: false
            }
        default:
            return state

    }

}