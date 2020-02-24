import React from "react";
import FaceList from "./FaceList";
import Form from "./Form";

const App = () => (
    <>
        <div>
            <h2>Faces</h2>
            <FaceList />
        </div>
        <div>
            <h2>Add a new face</h2>
            <Form />
        </div>
    </>
);

export default App;
