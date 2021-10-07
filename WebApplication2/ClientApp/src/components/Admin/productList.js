import { useDispatch, useSelector } from "react-redux"
import React, { useCallback, useEffect, useState } from "react";
import productActions from "../../actions/productActions";
import ProductItem from "./Map/productItem";


const ProductList = () => {
    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(productActions.getAll())
    }, []);
    const products = useSelector((state) => {
        return state.product.data
    });
    
    //const onDelete = useCallback()

    return (
        <div>
            <h2>ListProducts</h2>
            {
                products.map((product, index) =>
                   <div key={product.id}>
                        <ProductItem product={product} index={index} />
                    </div>)
            }
                
        </div>
    );
}
export default ProductList;