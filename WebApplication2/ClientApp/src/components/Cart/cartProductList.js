import { useDispatch, useSelector } from "react-redux"
import React, { useEffect } from "react";
import { cartActions } from "../../actions/cartActions";
import CartItem from "./Map/cartItem";
import Pages from "../Admin/pages";
import { useCallback } from "react";

const CartProductList = () => {
    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(cartActions.getCartListItems())
    }, []);
    const items = useSelector((state) => {
        return state.cart.data
    });
    const totalPages = useSelector((state) => {
        return state.cart.totalPages
    });
    const pageNumber = useSelector((state) => {
        return state.cart.pageNumber
    })
    const changePage = (index) => {
        dispatch(cartActions.getCartListItems(index))
    }
    const onLostFocus = (id, count) => {
        dispatch(cartActions.changeItemCount(id, count));
    }
        

    return (
        <div>
            {
                items.map((item, index) =>
                    <div key={item.id}>
                        <CartItem item={item} index={index} onBlur={onLostFocus} />
                    </div>)
            }
            <Pages total={totalPages}
                page={pageNumber}
                onClick={changePage} />
        </div>
    );
}
export default CartProductList;