import request from '../utils/Request';


const url = 'category/list';
const addUrl = 'category/';

function listCategories()
{
    return request(url);
}
function addCategory(categoryName,description) 
{
    return request(addUrl, { method: "Post" }, { categoryName, description })
}
export const categoryService = {
    listCategories,
    addCategory,
    //deleteCategory,

};