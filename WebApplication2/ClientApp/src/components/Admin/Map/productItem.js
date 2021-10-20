﻿import React, { useState } from "react";
import AddImage from "../addImage";
import DeleteProduct from "../deleteProduct";

const ProductItem = (props) => {
    const {
        index,
        product: {
            id, name, unitPrice, description, categories, images
        },
    } = props
    const [imageData, setImageData] = useState({
        imageName: '',
        imageFile: null,
        imageSrc: null
    });
    const preview = e => {
        if (e.target.files && e.target.files[0]) {
            let imageFile = e.target.files[0];
            const reader = new FileReader();
            reader.onload = x => {
                setImageData
                    ({
                        imageFile,
                        imageSrc: x.target.result
                    })
            }
            reader.readAsDataURL(imageFile)
        }
        else {
            setImageData({
                imageFile: null,
            })
        }
    }
    return (
        <div>
            <div key={id}>
                {props.index + 1}) {name}.___.
                <span style={{ color: "seagreen" }}>
                    Price:{unitPrice}$
                </span>
                <span>
                    Category:
                </span>
                {categories.map((category) =>
                    <div style={{ color: "red" }} key={category.id}>
                        {category.categoryName}
                    </div>
                )}
                Description:
                <span style={{ color: "blueviolet" }}>
                    {description}
                </span>
                {images.map((image) =>
                    <div key={index}>
                        <button onClick={
                            () => props.onClick(id,image.id)}>
                            delete Image</button>
                        <img src={image.imageSrc} />
                    </div>
                )}
            </div>
            <input type="file" accept="image/*" src={imageData.imageSrc} onChange={preview} />
            <AddImage productId={id} imageFile={imageData.imageFile} />
            <DeleteProduct productId={id} />
        </div>
    )
}
export default ProductItem;