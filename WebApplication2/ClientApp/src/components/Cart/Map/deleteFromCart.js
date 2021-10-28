import React, { useCallback } from "react";
import { useDispatch } from "react-redux"
import { cartActions } from "../../../actions/cartActions";



const DeleteFromCart = props =>
{
    const dispatch = useDispatch();
    const onDelete = useCallback(() => {
        dispatch(cartActions.DeleteFromCart(props.id))
    }, [props.id,dispatch]);
    return (

        <button onClick={onDelete}>
            Delete
        </button>
        );
}
export default DeleteFromCart;