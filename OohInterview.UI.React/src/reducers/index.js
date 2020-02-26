import {ADD_FACE} from "../constants/action-types";

const initialState = {
    faces: []
};

const rootReducer = (state = initialState, action) => {
    const newState = { ...state };
    switch(action.type) {
        case ADD_FACE: {
            newState.faces = newState.faces.concat(action.payload);
            break;
        }
        default:
            break;
    }
    return newState;
};

export default rootReducer;
