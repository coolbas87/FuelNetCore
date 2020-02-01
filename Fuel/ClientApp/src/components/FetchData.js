import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor (props) {
    super(props);
    this.state = { forecasts: [], loading: true };

    //fetch('api/SampleData/WeatherForecasts')
    fetch('api/esfFuelTypes')
      .then(response => response.json())
      .then(data => {
        this.setState({ forecasts: data, loading: false });
      });
  }

  static renderForecastsTable (forecasts) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
                    <th>fuID</th>
                    <th>Code</th>
                    <th>Name</th>
                    <th>Is active</th>
                    <th>Is has income</th>
                    <th>Is has outcome</th>
                    <th>Is has remains</th>
                    <th>Create at</th>
                    <th>Create by</th>
                    <th>Edit at</th>
                    <th>Edit by</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.fuID}>
                  <td>{forecast.fuID}</td>
                  <td>{forecast.code}</td>
                  <td>{forecast.name}</td>
                  <td><input type="checkbox" checked={forecast.isActive} /*onChange={this.handleChange.bind(this, index)}*/ /></td>
                  <td><input type="checkbox" checked={forecast.isHasIncome} /*onChange={this.handleChange.bind(this, index)}*/ /></td>
                  <td><input type="checkbox" checked={forecast.isHasOutcome} /*onChange={this.handleChange.bind(this, index)}*/ /></td>
                  <td><input type="checkbox" checked={forecast.isHasRemains} /*onChange={this.handleChange.bind(this, index)}*/ /></td>
                  <td>{forecast.createAt}</td>
                  <td>{forecast.createBy}</td>
                  <td>{forecast.editAt}</td>
                  <td>{forecast.editBy}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
