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
    error:{message:""}
  },
  reducers: {
    reset:() =>{
      return {
        MvotedProyect:{},
        allProduct: [],
        loading:true,
        error:{message:""}
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
      state.error= {message:""};
    },
    setLoadingFalse:(state) => {
      state.loading = false;
    },
    setError:(state,action) => {
      state.loading = false;
      state.error= {message:action.payload.message};
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