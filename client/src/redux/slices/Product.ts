import { createSlice,PayloadAction } from '@reduxjs/toolkit';
import { UUID } from 'crypto';

interface Product {
    id:UUID
    name:string,
    image:string,
    url:string,
    role:string
}

export const Product = createSlice({
  name: 'Product',
  initialState: {
    allProduct: [],
    loading:true,
    error:{}
  },
  reducers: {
    reset:() =>{
      return {
        allProduct: [],
        loading:true,
        error:{}
      }
    },
    addProduct: (state,action) => {
      state.allProduct = action.payload;
    },
    setLoadingTrue:(state) => {
      state.loading = true
      state.error= {}
    },
    setLoadingFalse:(state) => {
      state.loading = false
    },
    setError:(state,action) => {
      state.loading = false
      state.error= {message:action.payload.message};
    }

  },
});

export const { 
    addProduct,
    setLoadingTrue,
    setLoadingFalse,
    setError
 } = Product.actions;

export default Product.reducer;