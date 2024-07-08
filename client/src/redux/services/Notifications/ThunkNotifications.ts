import { addNotification, deleteNotification, reset, setError } from "@/redux/slices/Notifications";
import { Dispatch } from "@reduxjs/toolkit";

export const AddNotifications = (arrNotifications:[any]|any) => async (dispatch:Dispatch) => {
    try {
        dispatch(addNotification(arrNotifications));

    } catch (error) {
        dispatch(setError(error));
        console.error(error);
    }
}
export const ResetNotifications = async (dispatch:Dispatch) => {
    try {
        
        dispatch(reset());

    } catch (error) {
        dispatch(setError(error));
        console.error(error);
    }
}

export const DeleteNotification = (Notification:any) => async (dispatch:Dispatch) => {
    try {
        
        dispatch(deleteNotification(Notification));

    } catch (error) {
        dispatch(setError(error));
        console.error(error);
    }
}
