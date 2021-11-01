import React from "react";
import '../../styles/StyleSheet.scss'

const Pages = (props) => {
    const totalPages = props.total;

    return (
        <div>
            <button type="button" onClick={() => props.onClick(props.page - 1)}
                disabled={props.page <= 1}>←</button>
            {
                Array.from({ length: totalPages }, (val, index) =>
                    <button key={index} type="button"
                        className={props.page === 1 + index
                            ? "btn-clicked"
                            : ""}
                        onClick={() => props.onClick(index + 1)}>
                        {index + 1}
                    </button>)
            }
            <button type="button" onClick={() => props.onClick(props.page + 1)}
                disabled={props.page >= totalPages}>→</button>
        </div>
    )
}
export default Pages;