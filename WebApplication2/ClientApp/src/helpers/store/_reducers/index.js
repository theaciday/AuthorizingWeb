import { combineReducers } from "redux";

import { authentication } from "./authentication.reducer"
import { registration } from "./registration.reducer"
import { users } from "./users.reducer"
import { alert } from "./alertReducer"
import { loginReducer } from "./loginReducer"
import { category } from "./categoryReducer"

const rootReducer = combineReducers(
    {
        authentication,
        registration,
        users,
        alert,
        loginReducer,
        category,
    }
);
export default rootReducer;