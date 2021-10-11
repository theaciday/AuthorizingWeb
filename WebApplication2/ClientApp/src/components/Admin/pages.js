import { Button } from "bootstrap";
import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux"
import categoriesActions from "../../actions/categories.Actions";
import productActions from "../../actions/productActions";
import '../../styles/StyleSheet.scss'

const Pages = (props) => {
    const totalPages = props.total;

    return (
        <div>
            <button type="button" onClick={() => props.onClick(props.page - 1)}
                disabled={props.page <= 1}>←</button>
            {
                Array.from({ length: totalPages }, (val, index) =>
                    <button type="button"
                        className={props.page === 1+index ? "btn-clicked" : ""}
                        onClick={() => props.onClick(index + 1)}>
                        {index + 1}
                    </button>)
            }
            <button type="button" onClick={() => props.onClick(props.page + 1)}
                disabled={props.page === totalPages}>→</button>
        </div>
    )
}
export default Pages;