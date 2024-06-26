import { configureStore } from "@reduxjs/toolkit";
import productReducer from "./slices/Product";
import detailReducer from "./slices/Detail";
import reviewReducer from "./slices/Reviews";
import {thunk} from 'redux-thunk';
import { TypedUseSelectorHook, useSelector } from 'react-redux';

export const store = configureStore({
    reducer: {
      productReducer,
      detailReducer,
      reviewReducer
    },
    middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(thunk),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppSelector:TypedUseSelectorHook<RootState> = useSelector