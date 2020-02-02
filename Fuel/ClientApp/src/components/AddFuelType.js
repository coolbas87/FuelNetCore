import React, { Component } from 'react';

export class AddFuelType extends Component {

    constructor(props) {
        super(props);
        this.fuelType = { code: null, name: null, isActive: true, isHasIncome: false, isHasOutcome: false, isHasRemains: false }
        this.state = { fuelType: this.fuelType }
    }

    handleChange(event) {
        const fuelType = this.state.fuelType;
        fuelType[event.target.name] = event.target.value;
        this.setState({ fuelType: fuelType });
    }

    handleChangeCheckbox(event) {
        const fuelType = this.state.fuelType;
        fuelType[event.target.name] = event.target.checked;
        this.setState({ fuelType: fuelType });
    }


    render() {
        return (
            <form>
                <label>Code</label>
                <input type="text" value={this.state.fuelType.code} name="code" onChange={this.handleChange.bind(this)}></input>
                <label>Name</label>
                <input type="text" value={this.state.fuelType.name} name="name" onChange={this.handleChange.bind(this)} />
                <input type="checkbox" checked={this.state.fuelType.isActive} name='isActive' onChange={this.handleChangeCheckbox.bind(this)} ></input>
                <input type="checkbox" checked={this.state.fuelType.isHasIncome} name='isHasIncome' onChange={this.handleChangeCheckbox.bind(this)} />
                <input type="checkbox" checked={this.state.fuelType.isHasOutcome} name='isHasOutcome' onChange={this.handleChangeCheckbox.bind(this)}/>
                <input type="checkbox" checked={this.state.fuelType.isHasRemains} name='isHasRemains' onChange={this.handleChangeCheckbox.bind(this)}/>
                <button>Add new user</button>
            </form>
        )
    }
}

export default AddFuelType