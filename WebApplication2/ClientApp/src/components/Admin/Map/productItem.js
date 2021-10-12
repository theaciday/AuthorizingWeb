import React from "react";
import DeleteProduct from "../deleteProduct";

const ProductItem = (props) => {
    const {
        index,
        product: {
            id, name, description, categories, imageSrc
        },
    } = props
    return (
        <div>
            <div key={id}>
                {props.index + 1}) {name}
                <span>{description}</span>
                <span>   Category:</span>
                {categories.map((category) =>
                    <div key={category.id}>
                        {category.categoryName}
                        <img src={imageSrc} />
                    </div>
                )}

            </div>
            <DeleteProduct productId={id} />
        </div>
    )
}
export default ProductItem;