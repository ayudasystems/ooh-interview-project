import {ADD_FACE} from "../constants/action-types";

const initialState = {
    faces: []
};

function rootReducer(state = initialState, action) {
    if (action.type === ADD_FACE) {
        return Object.assign({}, state, {
            faces: state.faces.concat(action.payload)
        });
    }

    return state;
};

export default rootReducer;
