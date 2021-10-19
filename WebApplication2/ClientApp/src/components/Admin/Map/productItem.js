import React from "react";
import DeleteProduct from "../deleteProduct";

const ProductItem = (props) => {
    const {
        index,
        product: {
            id, name, unitPrice, description, categories, images
        },
    } = props
    return (
        <div>
            <div key={id}>
                {props.index + 1}) {name}.___.
                <span style={{ color: "seagreen" }}>Price:{unitPrice}$</span>
                <span>   Category:</span>
                {categories.map((category) =>
                    <div style={{ color:"red" }} key={category.id}>
                        {category.categoryName}
                    </div>
                )}___
                Description:
                <span style={{ color: "blueviolet" }}>{description}</span>
                {images.map((image) =>
                    <><img src={image.imageSrc} />
                        <button onClick={
                            () => props.onClick(image.id)}>
                            delete Image</button></>
                )}
            </div>
            <DeleteProduct productId={id} />
        </div>
    )
}
export default ProductItem;