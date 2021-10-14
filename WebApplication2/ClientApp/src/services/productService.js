import request from '../utils/Request';
const url = 'product';
const addUrl = 'product';
const deleteUrl = 'product/';
const addImageUrl = 'image/';
const getImageUrl = 'image/';

function listProducts(pageNumber=1,pageSize=10) {
    return request(url, { queryParams: { pageNumber, pageSize } });
}
function deleteProduct(id) {
    return request(`${deleteUrl}${id}`, { method: "Delete" }, { id });
}
function addProduct(name, unitPrice, description, categories) {
    return request(addUrl, { method: "Post" }, { name, unitPrice, description, categories});
}
function addImage(imageFile) {
    return request(addImageUrl, { method: "Post" }, { imageFile });
}
function getImage(id) {
    return request(getImageUrl, {}, {id})
}
export const productService = {
    addProduct,
    listProducts,
    deleteProduct,
    addImage,
    getImage
};