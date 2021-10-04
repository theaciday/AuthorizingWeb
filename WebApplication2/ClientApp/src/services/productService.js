import request from '../utils/Request';
const url = 'product';
const addUrl = 'product';
const deleteUrl = 'product';

function listProducts()
{
    return request(url);
}
function addProduct(name, unitPrice, description, categories)
{
    return request(addUrl, { method: "Post" }, { name, unitPrice, description, categories });
}
export const productService = {    
    addProduct,
    listProducts
};