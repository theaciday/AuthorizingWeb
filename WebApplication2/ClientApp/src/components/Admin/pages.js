import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux"
import categoriesActions from "../../actions/categories.Actions";
import productActions from "../../actions/productActions";

const Pages = (props) => {
    const { pageNumber, pageSize, totalPages } = useSelector((state) => {
        return state.product
    });
    const dispatch = useDispatch();
    const click = (val) => {
        
    }

    return (
        <div>
            {
                Array.from({ length: totalPages }, (val, index) =>
                    <button onClick={() => click(index+1)}>
                        {i + 1}
                    </button>)
            }
        </div>
    )
}
export default Pages;