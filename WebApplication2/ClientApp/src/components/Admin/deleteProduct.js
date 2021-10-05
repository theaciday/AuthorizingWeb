import { useDispatch, useSelector } from "react-redux"
import React, { useCallback, useEffect, useState } from "react";
import categoriesactions from '../../actions/categories.Actions';
import productActions from "../../actions/productActions";

const DeleteProduct = (props) => {
    const dispatch = useDispatch();
    const onDelete = useCallback(() => {
        dispatch(productActions.deleteProduct(props.productId))
    }, [props.productId]);

    return (
        <button onClick={onDelete}>Delete</button>
    );
}
export default DeleteProduct;