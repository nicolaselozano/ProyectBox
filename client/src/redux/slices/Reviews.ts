import { createSlice } from "@reduxjs/toolkit"

interface Reviews {
    loading:boolean
    error:{}
}

export const Reviews = createSlice({
    name:"reviews",
    initialState:{
        loading:false,
        error:{}
    },
    reducers:{
        reset: () => {
            return{
                loading:false,
                error:{}
            }
        },
        setError: (state,action) => {
            state.error = action.payload
            state.loading = false;
        },
        setLoading: (state,action) => {
            state.loading = action.payload
        }
    }
});

export const { 
    setLoading,
    setError,
    reset
 } = Reviews.actions;

export default Reviews.reducer;
