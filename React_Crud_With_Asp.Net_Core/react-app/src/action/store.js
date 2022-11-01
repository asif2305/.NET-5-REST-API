import {createStore, applyMiddleware,compose} from "redux";
import thunk from "react-redux";
import {reducers} from "../reducers"
export const store = createStore(
    reducers,
    compose(
        applyMiddleware(thunk)
    )
)