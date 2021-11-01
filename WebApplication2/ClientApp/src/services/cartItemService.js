import request from '../utils/Request';

const addUrl = 'cart/cartitem'
const getUrl = 'cart/listitems'
const addItem='cart/changecount'
function listCartItems(pageNumber = 1, pageSize = 10) {
    return request(getUrl, { queryParams: { pageNumber, pageSize } });
}
function addToCart(productId) {
    return request(addUrl, {method:"Post"},{productId } );
}
function deleteCartItem(itemId) {
    return request(`cart/${itemId}/removeitem`, { method: "Delete" }, { itemId });
}
function changeCount(Id,count)
{
    return request(`${addItem}`, { method: "Put" }, {Id, count});
}
export const cartService = {    
    deleteCartItem,
    listCartItems,
    addToCart,
    changeCount
}