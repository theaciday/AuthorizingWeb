import React from "react";

const CheckBoxInput = (props) => {
    const {
        style, onChange,
        cheked,value,} = props;
    return (
        <div>
            <input type="checkbox" 
                onChange={onChange}
                style={style}
                value={value}
                checked={cheked}
                style={style} />
        </div>
    )
}
export default CheckBoxInput;