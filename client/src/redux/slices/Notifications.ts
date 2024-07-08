import { PayloadAction, createSlice } from "@reduxjs/toolkit"

interface INotifications{
    actualNotifications:[]|[...any]|any
    error:any
    showIcon: boolean;
} 

const initialState:INotifications = {
    actualNotifications:[],
    error:{},
    showIcon:false,
}

export const Notifications = createSlice({
    name:"Notifications",
    initialState,
    reducers:{
        reset:() => {
            return {
                actualNotifications:[],
                error:{},
                showIcon:false
            }
        },
        setNotification:(state,action:PayloadAction<[]>) => {
            state.actualNotifications = action.payload
        },
        addNotification: (state, action: PayloadAction<string>) => {
            const notification = action.payload;
            if (!state.actualNotifications.includes(notification)) {
              state.actualNotifications.push(notification);
            }
        },
        deleteNotification:(state,action) => {
            let arr = state.actualNotifications;
            state.actualNotifications= arr.splice(arr.indexOf(action.payload), 1);
        },
        setError:(state,action) => {
            state.actualNotifications = []
            state.error = action.payload
        },
        setShowIcon: (state, action: PayloadAction<boolean>) => {
            state.showIcon = action.payload;
        },
    }    
})

export const {
    reset,
    setNotification,
    addNotification,
    deleteNotification,
    setError,
    setShowIcon
} = Notifications.actions;

export default Notifications.reducer;