import { combineReducers } from "redux";

import { authentication } from "/_reducers"
import { registration } from "/_reducers"
import { users } from "/_reducers"
import { alert } from "/_reducers"
import { loginReducer } from "/_reducers"

const rootReducer = combineReducers(
    {
        authentication,
        registration,
        users,
        alert,
        loginReducer,
    }
);
export default rootReducer;