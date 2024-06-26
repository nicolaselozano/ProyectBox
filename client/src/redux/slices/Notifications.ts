import { createSlice } from "@reduxjs/toolkit"
import { error } from "console"

const initialState:any = {
    actualNotifications:[],
    error:{},
}

export const Notifications = createSlice({
    name:"Notifications",
    initialState,
    reducers:{
        reset:() => {
            return {
                actualNotifications:[],
                error:{}
            }
        },
        setNotification:(state,action) => {
            state.actualNotifications = action.payload
        },
        addNotification:(state,action) => {
            state.actualNotifications = [...state.actualNotifications,action.payload]
        },
        deleteNotification:(state,action) => {
            let arr = state.actualNotifications;
            state.actualNotifications= arr.splice(arr.indexOf(action.payload), 1);
        },
        setError:(state,action) => {
            state.actualNotifications = []
            state.error = action.payload
        }
    }    
})

export const {
    reset,
    setNotification,
    addNotification,
    deleteNotification,
    setError
} = Notifications.actions;

export default Notifications.reducer;