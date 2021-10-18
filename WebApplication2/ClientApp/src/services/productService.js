import request from '../utils/Request';
const url = 'product';
const addUrl = 'product';
const deleteUrl = 'product/';
const addImageUrl = 'product/';
const getImageUrl = 'image/';

function listProducts(pageNumber=1,pageSize=10) {
    return request(url, { queryParams: { pageNumber, pageSize } });
}
function deleteProduct(id) {
    return request(`${deleteUrl}${id}`, { method: "Delete" }, { id });
}
function addProduct(productName, unitPrice, description, categories) {
    return request(addUrl, { method: "Post" }, { productName, unitPrice, description, categories});
}
function addImage(imageFile,id) {
    return request(`${addImageUrl}${id}/image/`, { method: "Post", contentType: 'multipart/form-data' }, imageFile);
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