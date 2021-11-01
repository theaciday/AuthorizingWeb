import React from "react";

const MyInput = (props) => {
    const { type, placeholder,
        style, onChange,
        value, name, step, required, onBlur, min } = props;

    return (
        <div>
            <input type={type}
                placeholder={placeholder}
                style={style}
                onChange={onChange}
                value={value}
                min={min}
                name={name}
                onBlur={onBlur}
                required={required ? required : null}
                step={type === "number" ? step : null}
             />
        </div>
    )
}
export default MyInput;