import request from '../utils/Request';
const url = 'product';
const addUrl = 'product';
const deleteUrl = 'product/';

function listProducts(pageNumber=1,pageSize=10) {
    return request(url, { queryParams: { pageNumber, pageSize } });
}
function deleteProduct(id) {
    return request(`${deleteUrl}${id}`, { method: "Delete" }, { id });
}
function addProduct(name, unitPrice, description, categories, imageFile) {
    return request(addUrl, { method: "Post" }, { name, unitPrice, description, categories, imageFile});
}
export const productService = {
    addProduct,
    listProducts,
    deleteProduct
};