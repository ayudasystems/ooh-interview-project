import React from "react";
import { connect } from "react-redux";

const mapStateToProps = state => {
    return { faces: state.faces };
};

const ConnectedFaceList = ({ faces }) => (
    <ul>
        {faces.map(el => (
            <li key={el.id}>{el.name}</li>
        ))}
    </ul>
);

const FaceList = connect(mapStateToProps)(ConnectedFaceList);

export default FaceList;
