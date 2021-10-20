import { productService } from '../services/productService';
import { productConstants } from '../constants/productConstants';

function newProduct(productName, unitPrice, description, categories) {
    function request() { return { type: productConstants.CREATE_PRODUCT_REQUEST } }
    function success(product) { return { type: productConstants.CREATE_PRODUCT_SUCCESS, payload: product } }
    function failure(error) { return { type: productConstants.CREATE_PRODUCT_FAILURE, error } }
    return dispatch => {
        dispatch(request());
        return productService.addProduct(productName, unitPrice, description, categories)
            .then(
                product => {
                    return dispatch(success(product));
                },
                error => {
                    return dispatch(failure(error.toString()));
                }
            );
    }
}
function addImage(imageFile, productId) {
    return dispatch => {
        dispatch(request());
        productService.addImage(imageFile, productId)
            .then(
                response => {
                    return dispatch(success({ ...response, productId }));
                },
                error => {
                    return dispatch(failure(error.toString()));
                }
            );
        function request() { return { type: productConstants.ADD_PRODUCT_IMAGE_REQUEST } }
        function success(payload) { return { type: productConstants.ADD_PRODUCT_IMAGE_SUCCESS, payload } }
        function failure(error) { return { type: productConstants.ADD_PRODUCT_IMAGE_FAILURE, error } }

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
function getImage(id) {
    return dispatch => {
        dispatch(request());
        productService.getImage(id)
            .then(
                response => {
                    dispatch(success(response));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
            );
        function request() { return { type: productConstants.GET_PRODUCT_IMAGE_REQUEST } }
        function success(payload) { return { type: productConstants.GET_PRODUCT_IMAGE_SUCCESS, payload } }
        function failure(error) { return { type: productConstants.GET_PRODUCT_IMAGE_FAILURE, error } }
    }

}
function getAll(pageNumber) {
    return dispatch => {
        dispatch(request());
        productService.listProducts(pageNumber)
            .then(
                response => {
                    dispatch(success(response));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
            );
        function request() { return { type: productConstants.GETALL_PRODUCTS_REQUEST } }
        function success(payload) { return { type: productConstants.GETALL_PRODUCTS_SUCCESS, payload } }
        function failure(error) { return { type: productConstants.GETALL_PRODUCTS_FAILURE, error } }
    }
}
function deleteImage(id, productId) {
    return dispatch => {
        dispatch(request());
        productService.deleteImage(id)
            .then(
                response => {
                    dispatch(success({
                        id,
                        productId
                    }));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
            );
        function request() { return { type: productConstants.DELETE_PRODUCT_IMAGE_REQUEST } }
        function success(payload) { return { type: productConstants.DELETE_PRODUCT_IMAGE_SUCCESS, payload } }
        function failure(error) { return { type: productConstants.DELETE_PRODUCT_IMAGE_FAILURE, error } }
    }
}
export default {
    newProduct,
    getAll,
    deleteProduct,
    addImage,
    getImage,
    deleteImage
};