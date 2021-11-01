import React, { useState } from "react";
import MyInput from "../../../utils/TextInput";
import DeleteFromCart from "./deleteFromCart";

const CartItem = (props) => {
    const {
        index,
        item: {
            id, quantity, dateCreated, productName, price, imageSrc
        },  
    } = props
    const [count, setCount] = useState(quantity);
    const onChangeNumber = e => {
        setCount(e.target.value)
    };

    const onBlur = () => {
        props.onBlur(id, parseInt(count))
    }

    return (
        <div>
            <div key={id}>
                {index + 1}){productName}.
                <span style={{ color: "saddlebrown" }}>
                    Price:{price}$
                </span>
                <div>
                    Date Added:
                    {dateCreated}
                </div>

                <span style={{ fontStyle: 'italic', color: "red" }}>Quantity:{quantity} pcs.</span>
                <div>{imageSrc.map((image, index) =>
                    <div key={index + 1}>
                        <img src={image} />
                    </div>
                )}
                </div>
                <MyInput min={0} value={count} onChange={onChangeNumber}
                    onBlur={onBlur}
                    type={"number"} step={1} />
                <DeleteFromCart id={id} />
            </div>
        </div>
    )
}
export default CartItem;