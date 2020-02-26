import React, { Component } from "react";
import { connect } from "react-redux";
import { addFace } from "../actions";

function mapDispatchToProps(dispatch) {
    return {
        addFace: article => dispatch(addFace(article))
    };
}

class ConnectedForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            name: ""
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({ [event.target.id]: event.target.name });
    }

    handleSubmit(event) {
        event.preventDefault();
        const { name } = this.state;
        this.props.addFace({ name });
        this.setState({ name: "" });
    }
    render() {
        const { name } = this.state;
        return (
            <form onSubmit={this.handleSubmit}>
                <div>
                    <label htmlFor="title">Title</label>
                    <input
                        type="text"
                        id="name"
                        value={name}
                        onChange={this.handleChange}
                    />
                </div>
                <button type="submit">SAVE</button>
            </form>
        );
    }
}

const Form = connect(
    null,
    mapDispatchToProps
)(ConnectedForm);

export default Form;
