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
                    dispatch(failure(error.ToString()));
                    dispatch(alertActions.error(error.ToString()));
                }
        );
        function request() { return { type: productConstants.CREATE_PRODUCT_REQUEST } }
        function success(product) { return { type: productConstants.CREATE_PRODUCT_SUCCESS, payload: product } }
        function failure(error) { return { type: productConstants.CREATE_PRODUCT_FAILURE, error } }
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
                    dispatch(failure(error.ToString()));
                }
        );
        function request() { return { type: productConstants.CREATE_PRODUCT_REQUEST } }
        function success(products) { return { type: productConstants.CREATE_PRODUCT_SUCCESS, payload: products } }
        function failure(error) { return { type: productConstants.CREATE_PRODUCT_FAILURE, error } }
    }

}

export default{
    newProduct,
    getAll
};