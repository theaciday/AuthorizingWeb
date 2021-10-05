import { useDispatch, useSelector } from "react-redux"
import React, { useCallback, useEffect, useState } from "react";
import categoriesactions from '../../actions/categories.Actions';

const CategoryAdd=() => {
    const dispatch = useDispatch();
    const [categoryData, setCategoryData] = useState({ name: '', description: '' });
    const onChangeCategoryData = useCallback(event => {
        const { target: { name, value } } = event
        setCategoryData({
            ...categoryData,
            [name]: value,
        })
    }, [categoryData])
    const submit = async (e) => {
        e.preventDefault()
        dispatch(categoriesactions.addCategory(categoryData.name, categoryData.description))
    }
    return (
        <form onSubmit={submit}>
            <h1 style={{ marginBottom: 30, marginTop: 15 }}>Add Category</h1>
            <input
                style={{ marginBottom: 20 }}
                value={categoryData.name}
                placeholder="Category Name"
                type="text"
                name="name"
                onChange={onChangeCategoryData} required />

            <input
                style={{ marginBottom: 20 }}
                value={categoryData.description}
                placeholder="Description"
                type="text"
                name="description"
                onChange={onChangeCategoryData} />

            <button disabled={!categoryData.name} name="button" type="submit" >Create Category</button>
        </form>

        );
}
export default CategoryAdd;