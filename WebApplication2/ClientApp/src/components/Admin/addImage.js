import React, { useCallback } from "react";
import { useDispatch } from "react-redux"
import productActions from "../../actions/productActions";

const AddImage = (props) => {
    const dispatch = useDispatch();
    const onAddImage = useCallback(() => {
        let data = new FormData();
        if (props.imageFile) {
            data.append('imageFile', props.imageFile);
            dispatch(
                productActions
                    .addImage(
                        data,
                        props.productId
                    ))
        }
    }, [props.imageFile, dispatch, props.productId]);
    return (
        <button onClick={onAddImage} disabled={!props.imageFile}>Add Image  </button>
    );
}
export default AddImage;
