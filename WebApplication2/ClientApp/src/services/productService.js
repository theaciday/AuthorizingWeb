import request from '../utils/Request';
const url = 'product';
const addUrl = 'product';
const deleteUrl = 'product/';

function listProducts()
{
    return request(url);
}
function deleteProduct(id)
{
    return request(`${deleteUrl}${id}`, { method: "Delete" }, { id });
}
function addProduct(name, unitPrice, description, categories)
{
    return request(addUrl, { method: "Post" }, { name, unitPrice, description, categories });
}
export const productService = {    
    addProduct,
    listProducts,
    deleteProduct
};