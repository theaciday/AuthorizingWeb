import { useDispatch, useSelector } from "react-redux"
import React, { useCallback, useEffect, useState } from "react";
import categoriesactions from '../../actions/categories.Actions';

const Admin = () => {
    const dispatch = useDispatch();
    const [categoryName, setCategoryName] = useState('');
    const [name, setName] = useState('');
    const [unitPrice, setUnitPrice] = useState('');
    const [desc]
    const [description, setDescription] = useState('');
    const handleChangeCatName = useCallback(e => {
        setCategoryName(e.target.value);
    }, [setCategoryName]);
    const handleChangeDescrip = useCallback(e => {
        setDescription(e.target.value);
    }, [setDescription]);
    const onDelete = useCallback((categoryId) => {
        dispatch(categoriesActions.deleteCategory(categoryId))
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

    
    return (
        <div>
            <form onSubmit={submit}>
                <h1 style={{ marginBottom: 30, marginTop: 15 }}>Add Category</h1>
                <input style={{ marginBottom: 20 }} value={categoryName} placeholder="Category Name" type="text" onChange={handleChangeCatName} />
                <p/>
                <input style={{ marginBottom: 20 }} value={description} placeholder="Description" type="text" onChange={handleChangeDescrip} />
                <button name="button" type="submit" >KNOPKA</button>
            </form>
        <div>
            <div>{categories.map((category, index) =>
                <p >
                    {index + 1} {category.categoryName}
                    <button onClick={() => onDelete(category.id)}>
                        Delete
                    </button>
                <p>{category.description}</p></p>)}
                   
                </div>
            </div>
        </div>
            );
};
export default Admin;