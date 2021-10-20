import { useDispatch, useSelector } from "react-redux"
import React, { useCallback, useEffect } from "react";
import productActions from "../../actions/productActions";
import ProductItem from "./Map/productItem";
import Pages from "./pages";


const ProductList = () => {
    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(productActions.getAll())
    }, []);
    const deleteImage = useCallback((id, imageId) => {
        dispatch(productActions.deleteImage(imageId,id))
    });
    const products = useSelector((state) => {
        return state.product.data
    });
    const totalPages = useSelector((state) => {
        return state.product.totalPages
    });
    const pageNumber = useSelector((state) => {
        return state.product.pageNumber
    });
    const changePage = (index) => {
        dispatch(productActions.getAll(index))
    }

    return (
        <div>
            <h2>ListProducts</h2>
            {
                products.map((product, index) =>
                    <div key={product.id}>
                        <ProductItem product={product}
                            onClick={deleteImage} index={index} />
                    </div>)
            }
            <Pages total={totalPages - 1}
                page={pageNumber}
                onClick={changePage} />
        </div>
    );
}
export default ProductList;