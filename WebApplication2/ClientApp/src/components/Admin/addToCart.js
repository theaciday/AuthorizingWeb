import { useDispatch } from "react-redux"
import React, { useCallback } from "react";
import { cartActions } from "../../actions/cartActions";


const AddtoCart = (props) => {
    const dispatch = useDispatch();
    const { productId, quantity } = props;
    const onAdd = useCallback(() => {
        dispatch(cartActions.addCartItem(productId,quantity))
    })

    return (
        <button onClick={onAdd}>Add to Cart</button>
        );
}
export default AddtoCart;