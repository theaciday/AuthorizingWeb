﻿import { useDispatch, useSelector } from "react-redux"
import React, { useCallback, useEffect, useState } from "react";
import categoriesactions from '../../actions/categories.Actions';
import ProductActions from "../../actions/productActions";
import  CategoriesList from "./categoryList";
import CategoryAdd from "./categoryAdd";
import ProductAdd from "./productAdd";
import ProductList from "./productList";

const Admin = () => {
   
   
   
    return (
        <div>
            <ProductAdd />
            <ProductList/>
            <CategoryAdd/>
            <CategoriesList/>

        </div>
    );
};
export default Admin;