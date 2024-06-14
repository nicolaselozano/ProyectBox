import { Product } from "@/components/Proyects/AllItems/AllItems";
import { createSlice } from "@reduxjs/toolkit";

interface DetailState {
    product: Product | {};
    reviews: number | null;
    loading: false | true;
    error: any
}

const initialState:DetailState ={
    product:{},
    reviews:null,
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
                error:{},
                reviews:null,
            }
        },
        setProduct: (state,action) => {
            state.product = action.payload.product;
            state.reviews = action.payload.reviews;
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