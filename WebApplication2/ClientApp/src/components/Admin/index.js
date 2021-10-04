import { useDispatch, useSelector } from "react-redux"
import React, { useCallback, useEffect, useState } from "react";
import categoriesactions from '../../actions/categories.Actions';
import ProductActions from "../../actions/ProductActions";

const Admin = () => {
    const dispatch = useDispatch();
    const [categoryName, setCategoryName] = useState('');
    const [productName, setProductName] = useState('');
    const [unitPrice, setUnitPrice] = useState('');
    const [propCategories, setPropCategories] = useState({});
    function getSelected(e) {
        var categories = document.querySelectorAll('input[type=checkbox]:checked')
        for (var i = 0; i < categories.length; i++) {
            if (categories[i].checked) {
                if (categories[i] != null) {
                    propCategories.push(categories[i].value);

                }
            }
        }
    }

    const [description, setDescription] = useState('');
    const [productDescription, setProductDescription] = useState('');
    const handleChangePrice = useCallback(e => {
        setUnitPrice(e.target.value);
    }, [setUnitPrice]);
    const handleChangeProdName = useCallback(e => {
        setProductName(e.target.value);
    }, [setProductName]);
    const handleChangeCatName = useCallback(e => {
        setCategoryName(e.target.value);
    }, [setCategoryName]);
    const handleChangeProductDesc = useCallback(e => {
        setProductDescription(e.target.value);
    }, [setProductDescription]);
    const handleChangeCategoryDesc = useCallback(e => {
        setDescription(e.target.value);
    }, [setProductDescription]);
    const onDelete = useCallback((categoryId) => {
        dispatch(categoriesactions.deleteCategory(categoryId))
    });
    const submit = async (e) => {
        e.preventDefault()
        dispatch(categoriesactions.addCategory(categoryName, description))
    }
    useEffect(() => {
        dispatch(categoriesactions.getListCategories())
    }, []);
    const { categories } = useSelector((state) => {
        return state.category
    });
    const productSubmit = async (e) => {
        e.preventDefault()
        dispatch(ProductActions.newProduct(productName, unitPrice, productDescription, propCategories))
    }
    return (
        <div>
            <form onSubmit={submit}>
                <h1 style={{ marginBottom: 30, marginTop: 15 }}>Add Category</h1>
                <input style={{ marginBottom: 20 }} value={categoryName} placeholder="Category Name" type="text" onChange={handleChangeCatName} />
                <p />
                <input style={{ marginBottom: 20 }} value={description} placeholder="Description" type="text" onChange={handleChangeCategoryDesc} />
                <p />
                <button name="button" type="submit" >Add</button>
            </form>
            <form id="categories" onSubmit={productSubmit}>
                <div>

                    <h1>Add Product</h1>
                    <input value={productName} placeholder="Product Name" type="text" onChange={handleChangeProdName} />
                    <p />
                    <input value={productDescription} placeholder="Description" type="text" onChange={handleChangeProductDesc} />
                    <p />
                    <input value={unitPrice} placeholder="Price" type="number" step="0.01" onChange={handleChangePrice} />
                    <p /><h4>Category</h4>
                    {categories.map((category) =>
                        <><td>
                            <input type="checkbox" value={category.id}
                                id={category.categoryName} />
                            <label for={category.id}>
                                <p />{category.categoryName}
                            </label>
                        </td> </>
                    )}
                    <p />
                    <button type="submit" onClick={getSelected}>Create</button>
                </div>
            </form>
            <div><h2 style={{ marginTop: 20 }}>List Categories</h2>
                <div>{categories.map((category, index) =>
                    <p style={{ marginTop: 25 }} >
                        {index + 1} {category.categoryName}
                        <button style={{ marginLeft: 13 }} onClick={() => onDelete(category.id)}>
                            Delete
                        </button>
                        <p>{category.description}</p></p>)}
                </div>
            </div>

        </div>
    );
};
export default Admin;