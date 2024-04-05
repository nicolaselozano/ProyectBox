import { Product } from "@/components/Proyects/AllItems/AllItems";
import { createSlice } from "@reduxjs/toolkit";

interface DetailState {
    product: Product | {};
    loading: false | true;
    error: any
}

const initialState:DetailState ={
    product:{},
    loading:false,
    error:{}
}

export const Detail = createSlice({
    name:"detail",
    initialState,
    reducers:{
        reset: () => {
            return {
                product:{},
                loading:false,
                error:{}
            }
        },
        setProduct: (state,action) => {
            state.product = action.payload;
            state.loading = false;
        },
        setLoading: (state,action) => {
            state.loading = action.payload;
        },
        setError: (state,action) => {
            state.error = action.payload;
        }
    }
})

export const {
    setProduct,
    setLoading,
    reset,
    setError
} = Detail.actions;

export default Detail.reducer;