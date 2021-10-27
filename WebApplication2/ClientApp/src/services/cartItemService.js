import request from '../utils/Request';

const addUrl = 'cart/cartitem'
const deleteUrl = 'cart/cartitem'
const getUrl = 'cart/cartitem'
function listCartItems(pageNumber = 1, pageSize = 10) {
    return request(getUrl, { queryParams: { pageNumber, pageSize } });
}
function addCartItem(productId, quantity) {
    return request(getUrl, {method:"Post"},{productId, quantity } );
}
function deleteCartItem(itemId) {
    return request(`${itemId}/removeitem`, { method: "Delete" });
}
export const cartService = {
    deleteCartItem,
    listCartItems,
    addCartItem
}