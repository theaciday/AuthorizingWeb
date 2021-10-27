import { useDispatch, useSelector } from "react-redux"
import React, { useCallback, useState } from "react";
import productActions from "../../actions/productActions";
import defaultImage from '../../image/review_avatar.png'
import Pages from "./pages";
import categoriesActions from "../../actions/categories.Actions";
import MyInput from "../../utils/TextInput";
import ImgInput from "../../utils/imgInput";
import CheckBoxInput from "../../utils/checkBoxInput";

const ProductAdd = () => {
    const dispatch = useDispatch();
    const totalPages = useSelector((state) => {
        return state.category.totalPages
    });
    const pageNumber = useSelector((state) => {
        return state.category.pageNumber
    });
    const changePage = (index) => {
        dispatch(categoriesActions.getListCategories(index))
    }
    const defaultImageSrc = defaultImage;
    const [imageData, setImageData] = useState({
        imageName: '',
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
            productActions
                .newProduct(
                    productData.productName,
                    productData.unitPrice,
                    productData.productDescription,
                    propCategories.map(categoryId =>
                        ({ id: categoryId })),
                ))
        const productId = createdProduct.payload.id;
        let data = new FormData();
        if (imageData.imageFile) {
            data.append('imageFile', imageData.imageFile);
            await dispatch(
                productActions
                    .addImage(
                        data,
                        productId
                    )
            )
        }


    }
    return (
        <form id="categories" onSubmit={productSubmit}>
            <div>
                <h1>Add Product</h1>
                <MyInput
                    name={"productName"}
                    value={productData.productName}
                    placeholder={"Product Name"}
                    type={"text"}
                    onChange={onChangeProductData} required={true} />
                <MyInput
                    name={"productDescription"}
                    value={productData.productDescription}
                    placeholder={"Description"}
                    type={"text"}
                    onChange={onChangeProductData} />
                <MyInput name={"unitPrice"}
                    value={productData.unitPrice}
                    placeholder={"Price"}
                    type={"number"}
                    step={"0.01"}
                    onChange={onChangeProductData} />
                <ImgInput  name={"image"}
                    onChange={showPreview}
                    accept={"image/*"}/>
                <img src={imageData.imageSrc} />
                <h5>Categories</h5>
                {categories.map((category) =>
                    <div key={category.id}>
                        <CheckBoxInput
                            onChange={onChangeProductCategory}
                            checked={propCategories.some(c => c === category.id)}
                            value={category.id}
                            id={category.id} />
                        <label htmlFor={category.id}>
                            {category.categoryName}
                        </label>
                    </div>
                )}
                <Pages total={totalPages}
                    page={pageNumber}
                    onClick={changePage} />
                <button disabled={!productData.productName && productData.imageFile} type="submit">Create Product</button>
            </div>
        </form>
    )

}
export default ProductAdd;