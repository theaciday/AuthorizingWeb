import React, { useState } from "react";
import DeleteFromCart from "./deleteFromCart";

const CartItem = props => {
    const {
        index,
        item: {
            id, quantity, dateCreated, product
        },
    } = props


    return (
        <div>
            <div key={id}>
                {index + 1}){product.name}.
                <span style={{ color: "seashell" }}>
                    Price:{product.unitPrice}$
                </span>
                <span>
                    Categories:
                    {product.categories.map((category) =>
                        <div>
                            <div style={{ color: 'skyblue' }} key={category.id}>
                                {category.categoryName}
                            </div>
                            Category description:
                            <div>
                                {category.description}
                            </div>
                        </div>
                    )}
                </span>
                <div>
                    Date Added:
                    {dateCreated}
                </div>
                Description:
                <span>{product.description}</span>
                <span style={{ fontStyle: 'italic', color: "azure" }}>{quantity} pcs.</span>
                <div>{product.images.map((image, index) =>
                    <div key={index + 1}>
                        <img src={image.imageSrc} />
                    </div>
                )}
                </div>
                <DeleteFromCart id={id} />
            </div>
        </div>
    )
}
export default CartItem;