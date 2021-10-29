import request from '../utils/Request';

const addUrl = 'cart/cartitem'
const deleteUrl = 'removeitem'
const getUrl = 'cart/listitems'
function listCartItems(pageNumber = 1, pageSize = 10) {
    return request(getUrl, { queryParams: { pageNumber, pageSize } });
}
function addToCart(productId) {
    return request(addUrl, {method:"Post"},{productId } );
}
function deleteCartItem(itemId) {
    return request(`cart/${itemId}/removeitem`, { method: "Delete" }, { itemId });
}
export const cartService = {
    deleteCartItem,
    listCartItems,
    addToCart
}