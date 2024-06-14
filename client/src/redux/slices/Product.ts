import { createSlice } from '@reduxjs/toolkit';
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
    MvotedProyect:{},
    allProduct: [],
    loading:true,
    error:{}
  },
  reducers: {
    reset:() =>{
      return {
        MvotedProyect:{},
        allProduct: [],
        loading:true,
        error:{}
      }
    },
    addProduct: (state,action) => {
      state.allProduct = action.payload;
    },
    setMvotedProyect: (state,action) => {
      state.MvotedProyect = action.payload;
    },
    setLoadingTrue:(state) => {
      state.loading = true;
      state.error= {};
    },
    setLoadingFalse:(state) => {
      state.loading = false;
    },
    setError:(state,action) => {
      state.loading = false;
      state.error= action.payload;
    }

  },
});

export const { 
  addProduct,
  setLoadingTrue,
  setLoadingFalse,
  setError,
  reset
} = Product.actions;

export default Product.reducer;