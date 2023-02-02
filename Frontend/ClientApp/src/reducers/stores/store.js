import { configureStore } from "@reduxjs/toolkit";
import dataReducer from "@Reducers/userDataSlice"

export const store = configureStore({
    reducer: {
        data: dataReducer
    }
});