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
        cartService.deleteCartItem(itemId)
            .then(
                () => {
                    return dispatch(success(itemId));
                },
                error => {
                    return dispatch(failure(error.toString()));
                }
            );
        function request() { return { type: cartConstants.DELETE_CART_ITEM_REQUEST } }
        function success(itemId) { return { type: cartConstants.DELETE_CART_ITEM_SUCCESS, payload: itemId } }
        function failure(error) { return { type: cartConstants.DELETE_CART_ITEM_FAILURE, error } }
    };
}

function addCartItem(productId) {
    return dispatch => {
        dispatch(request());
        cartService.addToCart(productId)
            .then(
                response => {
                    dispatch(success(response));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
            );
        function request() { return { type: cartConstants.ADD_CART_ITEM_REQUEST } }
        function success(payload) { return { type: cartConstants.ADD_CART_ITEM_SUCCESS, payload } }
        function failure(error) { return { type: cartConstants.ADD_CART_ITEM_FAILURE, error } }
    };
}
function changeItemCount(itemId, count) {
    return dispatch => {
        dispatch(request());
        cartService.changeCount(itemId, count)
            .then(
                () => {
                    dispatch(success({ itemId, count }));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
            );
        function request() { return { type: cartConstants.CHANGE_CART_ITEM_REQUEST } }
        function success(payload) {return { type: cartConstants.CHANGE_CART_ITEM_SUCCESS, payload} }
        function failure(error) { return { type: cartConstants.CHANGE_CART_ITEM_FAILURE,error } }
    }
};

export const cartActions =
{
    addCartItem,
    deleteCartItem,
    getCartListItems,
    changeItemCount
}