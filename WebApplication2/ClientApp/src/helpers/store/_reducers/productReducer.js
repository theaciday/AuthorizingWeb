import { data } from 'jquery';
import { productConstants } from '../../../constants/productConstants'

const initialState = {

    pageNumber: '',
    pageSize: '',
    totalPages: '',
    data: [],
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
                data: [action.payload, ...state.data],
                isLoaded: false,
                isLoading: true
            }
        case productConstants.CREATE_PRODUCT_FAILURE:
            return {
                ...state,
                isLoading: false,
                isLoaded: false
            }
        case productConstants.ADD_PRODUCT_IMAGE_REQUEST:
            return {
                ...state,
                isLoading: true,
                isLoaded: false
            }
        case productConstants.ADD_PRODUCT_IMAGE_SUCCESS:
            return {
                ...state,
                data: state.data.map(product => product.id === action.payload.productId
                    ? {
                        ...product,
                        images: [
                            ...product.images,
                            { id: action.payload.id, imageSrc: action.payload.imageSrc }
                        ],
                    }
                    : product
                ),
                isLoading: false,
                isLoaded: true
            }
        case productConstants.ADD_PRODUCT_IMAGE_FAILURE:
            return {
                ...state,
                isLoaded: false,
                isLoading: false
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
                pageNumber: action.payload.pageNumber,
                pageSize: action.payload.pageSize,
                totalPages: action.payload.totalPages,
                data: action.payload.data,
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
                data: state.data
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