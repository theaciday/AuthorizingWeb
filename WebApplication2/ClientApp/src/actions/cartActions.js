import { cartConstants } from '../constants/cartConstants';
import { cartService } from '../services/cartItemService';

function getCartListItems(pageNumber) {
    return dispatch => {
        dispatch(request());
        cartService.listCartItems(pageNumber)
            .then(
                response => {
                    dispatch(success(response));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
            );
        function request() { return { type: cartConstants.GET_CART_ITEMS_REQUEST } }
        function success(payload) { return { type: cartConstants.GET_CART_ITEMS_SUCCESS, payload } }
        function failure(error) { return { type: cartConstants.GET_CART_ITEMS_FAILURE, error } }
    };
}

function deleteCartItem(itemId) {
    return dispatch => {
        dispatch(request());
        cartService.listCartItems(itemId)
            .then(
                () => {
                    dispatch(success(itemId));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
        );
        function request() { return { type: cartConstants.DELETE_CART_ITEM_REQUEST } }
        function success(itemId) { return { type: cartConstants.DELETE_CART_ITEM_SUCCESS, payload: itemId } }
        function failure(error) { return { type: cartConstants.DELETE_CART_ITEM_FAILURE, error } }
    };
}

function addCartItem(productId,quantity) {
    return dispatch => {
        dispatch(request());
        cartService.addCartItem(productId,quantity)
            .then(
                response => {
                    dispatch(success(response));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
            );
        function request() { return { type: cartConstants.GET_CART_ITEMS_REQUEST } }
        function success(payload) { return { type: cartConstants.GET_CART_ITEMS_SUCCESS, payload } }
        function failure(error) { return { type: cartConstants.GET_CART_ITEMS_FAILURE, error } }
    };
}
