import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    name: '',
    surname: '',
    status: '',
    theme: '',
    isDebugMode: false
};

export const dataSlice = createSlice({
    name: 'data',
    initialState,
    
    reducers: {
      setTheme: (state, action) => {
        state.theme = action.payload
      },
      switchDebugMode: (state) => {
        state.isDebugMode = !state.isDebugMode;
      }
    }
  });
  
  export const selectTheme = (state) => state.data.theme;

  export const selectIsDebugMode = (state) => state.data.isDebugMode;
  
  export const { setTheme, switchDebugMode } = dataSlice.actions;
  
  export default dataSlice.reducer;