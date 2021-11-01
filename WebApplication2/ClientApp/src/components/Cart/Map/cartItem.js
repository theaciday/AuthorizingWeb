import React, { useState } from "react";
import DeleteFromCart from "./deleteFromCart";

const CartItem = props => {
    const {
        index,
        item: {
            id, quantity, dateCreated, productName,price,imageSrc
        },
    } = props


    return (
        <div>
            <div key={id}>
                {index + 1}){productName}.
                <span style={{ color: "seashell" }}>
                    Price:{price}$
                </span>
                <div>
                    Date Added:
                    {dateCreated}
                </div>
                
                <span style={{ fontStyle: 'italic', color: "azure" }}>{quantity} pcs.</span>
                <div>{imageSrc.map((image, index) =>
                    <div key={index + 1}>
                        <img src={image} />
                    </div>
                )}
                </div>
                <DeleteFromCart id={id} />
            </div>
        </div>
    )
}
export default CartItem;