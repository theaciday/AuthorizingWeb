import { useDispatch, useSelector } from "react-redux"
import React, { useCallback, useState } from "react";
import ProductActions from "../../actions/productActions";
import productActions from "../../actions/productActions";

const ProductAdd = () => {
    const dispatch = useDispatch();
    const defaultImageSrc = '../../image/review_avatar.png';
    const [imageData, setImageData] = useState({
        imageName:'',
        imageFile: null,
        imageSrc: defaultImageSrc
    });
    const [propCategories, setPropCategories] = useState([]);
    const [productData, setProductData] = useState({
        productName: '',
        unitPrice: '',
        productDescription: '',
    });


    const onChangeProductCategory = useCallback(event => {
        const { target: { value, checked } } = event
        if (checked) {
            setPropCategories([
                ...propCategories,
                +value,
            ])
        } else {
            setPropCategories(propCategories.filter(category => category !== +value))
        }
    }, [propCategories])

    const onChangeProductData = useCallback(event => {
        const { target: { name, value } } = event
        setProductData({
            ...productData,
            [name]: value,
        })
    }, [productData])

    const showPreview = e => {
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
                imageSrc: defaultImageSrc
            })
        }
    }

    const categories = useSelector((state) => {
        return state.category.data
    });
    
    const productSubmit = async (e) => {
        e.preventDefault()
        const createdProduct = await dispatch(
            ProductActions
                .newProduct(
                    productData.productName,
                    productData.unitPrice,
                    productData.productDescription,
                    propCategories.map(categoryId => ({ id: categoryId })),
            ))
        const productId = createdProduct.payload.id;
        let data = new FormData();
        data.append('imageFile', imageData.imageFile);
        const createdImage = await dispatch(
            productActions
                .addImage(
                    data,
                    productId
                )
        )

    }
    return (
        <form id="categories" onSubmit={productSubmit}>
            <div>
                <h1>Add Product</h1>
                <input name="productName" value={productData.productName} placeholder="Product Name" type="text" onChange={onChangeProductData} required />
                <input name="productDescription" value={productData.productDescription} placeholder="Description" type="text" onChange={onChangeProductData} />
                <input name="unitPrice" value={productData.unitPrice} placeholder="Price" type="number" step="0.01" onChange={onChangeProductData} />
                <input type="file" name="image"
                    onChange={showPreview}
                    accept="image/*" />
                <img src={imageData.imageSrc} />
                <h5>Categories</h5>
                {categories.map((category) =>
                    <div key={category.id}>
                        <input
                            onChange={onChangeProductCategory}
                            type="checkbox"
                            checked={propCategories.some(c => c === category.id)}
                            value={category.id}
                            id={category.id} />
                        <label htmlFor={category.id}>
                            {category.categoryName}
                        </label>
                    </div>
                )}
                <button disabled={!productData.productName && productData.imageFile} type="submit">Create Product</button>
            </div>
        </form>
    )

}
export default ProductAdd;