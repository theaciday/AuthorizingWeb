import { productService } from '../services/productService';
import { alertActions } from '../actions/alertActions';
import { productConstants } from '../constants/productConstants';


function newProduct(name, unitPrice, description, categories) {
    return dispatch => {
        dispatch(request());
        productService.addProduct(name, unitPrice, description, categories)
            .then(
                product => {
                    dispatch(success(product));
                },
                error => {
                    dispatch(failure(error.toString()));
                    dispatch(alertActions.error(error.toString()));
                }
        );
        function request() { return { type: productConstants.CREATE_PRODUCT_REQUEST } }
        function success(product) { return { type: productConstants.CREATE_PRODUCT_SUCCESS, payload: product } }
        function failure(error) { return { type: productConstants.CREATE_PRODUCT_FAILURE, error } }
    }
}
function deleteProduct(id) {
    return dispatch => {
        dispatch(request());
        productService.deleteProduct(id)
            .then(
                product => {
                    dispatch(success(id));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
        );
        function request() { return { type: productConstants.DELETE_PRODUCT_REQUEST } }
        function success(id) { return { type: productConstants.DELETE_PRODUCT_SUCCESS, payload: id } }
        function failure(error) { return { type: productConstants.DELETE_PRODUCT_FAILURE, error } }
    }

}
function getAll() {
    return dispatch => {
        dispatch(request());
        productService.listProducts()
            .then(
                products => {
                    dispatch(success(products));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
        );
        function request() { return { type: productConstants.GETALL_PRODUCTS_REQUEST } }
        function success(products) { return { type: productConstants.GETALL_PRODUCTS_SUCCESS, payload: products } }
        function failure(error) { return { type: productConstants.GETALL_PRODUCTS_FAILURE, error } }
    }

}

export default{
    newProduct,
    getAll,
    deleteProduct
};