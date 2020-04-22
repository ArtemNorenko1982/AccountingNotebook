import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { transactions: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderTransactionsTable(transactions) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Sum. (C)</th>
            <th>Operation. (F)</th>
            <th>Is Success</th>
          </tr>
        </thead>
        <tbody>
          {transactions.map(trn =>
            <tr key={trn.date}>
              <td>{trn.date}</td>
              <td>{trn.transactionSum}</td>
              <td>{trn.operation}</td>
              <td>{trn.isSuccess}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderTransactionsTable(this.state.transactions);

    return (
      <div>
        <h1 id="tabelLabel" >Account Notebook</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('\\api\\account').catch(err => console.log(err));
    const data = await response.json().catch(err => []);
    this.setState({ transactions: data, loading: false });
  }
}
