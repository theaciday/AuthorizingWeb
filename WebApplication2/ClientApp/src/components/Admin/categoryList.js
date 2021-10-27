import { useDispatch, useSelector } from "react-redux"
import categoriesactions from '../../actions/categories.Actions';
import React, { useCallback, useEffect } from "react";
import Pages from "./pages";

const CategoriesList = () => {
    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(categoriesactions.getListCategories())
    }, []);
    const categories = useSelector((state) => {
        return state.category.data
    });
    const totalPages = useSelector((state) => {
        return state.category.totalPages
    });
    const changePage = (index) => {
        dispatch(categoriesactions.getListCategories(index))
    }
    const onDelete = useCallback((categoryId) => {
        dispatch(categoriesactions.deleteCategory(categoryId))
    });
    const pageNumber = useSelector((state) => {
        return state.category.pageNumber
    });

    return (
        <div><h2 style={{ marginTop: 20 }}>List Categories</h2>
            <div>{categories.map((category, index) =>
                <div key={category.id} style={{ marginTop: 25 }}>
                    {index + 1} {category.categoryName}
                    <button style={{ marginLeft: 13 }} onClick={() => onDelete(category.id)}>
                        Delete
                    </button>
                    <span>{category.description}</span></div>)}
            </div>
            <Pages total={totalPages} page={pageNumber}  onClick={changePage} />
        </div>
        );
}
export default CategoriesList;