import request from '../utils/Request';


const url = 'category/list';
const addUrl = 'category/';
const deleteUrl = 'category/';

function listCategories(pageNumber = 1)
{
    return request(url, { queryParams: { pageNumber , pageSize } });
}
function addCategory(categoryName,description) 
{
    return request(addUrl, { method: "Post" }, { categoryName, description });
}
function deleteCategory(id)
{
    return request(`${deleteUrl}${id}`, { method: "Delete" });
}
export const categoryService = {
    listCategories,
    addCategory,
    deleteCategory,
};