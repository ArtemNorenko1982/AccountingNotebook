import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Accounting application</h1>
        <p>Welcome to your personal accounting assistant</p>
        
        <p>To help you get started, you should</p>
        <ul>
          <li><strong>Select Fetch data</strong> to watch all transactions from your account</li>
          <li><strong>Use tools such as Postman</strong> to manage data into your db</li>
          <li>Enjoy)</li>
        </ul>
        <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p>
      </div>
    );
  }
}
