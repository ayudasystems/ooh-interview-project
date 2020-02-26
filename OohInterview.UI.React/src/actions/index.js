import { ADD_FACE } from "../constants/action-types";

export const addFace = payload => {
    return dispatch => {
        dispatch({ type: ADD_FACE, payload });
    }
};
