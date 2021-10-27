import React from "react";

const MyInput = (props) => {
    const { type, placeholder,
        style, onChange,
        value, name, step, required } = props;

    return (
        <div>
            <input type={type}
                placeholder={placeholder}
                style={style}
                onChange={onChange}
                value={value}
                name={name}
                required={required ? required : null}
                step={type==="number"?step:null}
             />
        </div>
    )
}
export default MyInput;