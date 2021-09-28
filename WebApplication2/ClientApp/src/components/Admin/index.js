import { useDispatch, useSelector } from "react-redux"
import React, { useEffect } from "react";
import categoriesactions from '../../actions/categories.Actions';

const Admin = () => {
    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(categoriesactions.getListCategories())
    }, []);
    const { categories } = useSelector((state) => {
        return state.category
    });

    
    return (
        <div>
            <div>{categories.map((category, index) =>
                <p style={{ backgroundColor: "blue", color: "white" }}>{index + 1} {category.categoryName} <p style={{ backgroundColor: "yellow", color: "orangered" }}   >{category.description}</p></p>)}</div>
        </div>  
            );
};
export default Admin;