import React from "react";
import CategoriesList from "./categoryList";
import CategoryAdd from "./categoryAdd";
import ProductAdd from "./productAdd";
import ProductList from "./productList";

const Admin = () => {

    return (
        <div>
            <ProductAdd />
            <ProductList />
            <CategoryAdd />
            <CategoriesList />
        </div>
    );
};
export default Admin;