import { categoryConstants } from '../constants/categoryConstants';
import { categoryService } from '../services/category.service';


function getListCategories(pageNumber) {
    return dispatch => {
        dispatch(request());
        categoryService.listCategories(pageNumber)
            .then(
                response => {
                    dispatch(success(response));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
        );
        function request() { return { type: categoryConstants.GET_CATEGORY_REQUEST } }
        function success(payload) { return { type: categoryConstants.GET_CATEGORY_SUCCESS, payload } }
        function failure(error) { return { type: categoryConstants.GET_CATEGORY_FAILURE, error } }
    };
}

function addCategory(categoryName, description) {
    return dispatch => {
        dispatch(request());
        categoryService.addCategory(categoryName, description)
            .then(
                response => {
                    dispatch(success(response));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
        );
        function request() { return { type: categoryConstants.CREATE_CATEGORY_REQUEST } }
        function success(category) { return { type: categoryConstants.CREATE_CATEGORY_SUCCESS, payload: category } }
        function failure(error) { return { type: categoryConstants.CREATE_CATEGORY_FAILURE, error } }

    }
}
function deleteCategory(id) {
    return dispatch => {
        dispatch(request());
        categoryService.deleteCategory(id)
            .then(
                () => {
                    dispatch(success(id));
                },
                error => {
                    dispatch(failure(error.toString()));
                }
        );
        function request() { return { type: categoryConstants.DELETE_CATEGORY_REQUEST } }
        function success(id) { return { type: categoryConstants.DELETE_CATEGORY_SUCCESS, payload: id }}
        function failure(error) { return { type: categoryConstants.DELETE_CATEGORY_FAILURE, error } }
    }
}
export default{
    getListCategories,
    addCategory,
    deleteCategory
};