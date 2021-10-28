import request from '../utils/Request';

const addUrl = 'cart/cartitem'
const deleteUrl = 'removeitem'
const getUrl = 'cart/listitems'
function listCartItems(pageNumber = 1, pageSize = 10) {
    return request(getUrl, { queryParams: { pageNumber, pageSize } });
}
function addToCart(productId, quantity) {
    return request(addUrl, {method:"Post"},{productId, quantity } );
}
function deleteCartItem(itemId) {
    return request(`${itemId}/${deleteUrl}`, { method: "Delete" });
}
export const cartService = {
    deleteCartItem,
    listCartItems,
    addToCart
}