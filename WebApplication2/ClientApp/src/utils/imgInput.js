import React from "react";

const ImgInput = (props) => {
    const { accept,
        style, onChange,
        name  } = props;
    return (
        <div>
            <input type="file" name={name}
                onChange={onChange}
                accept={accept}
                style={style} />
        </div>
        )
}
export default ImgInput;