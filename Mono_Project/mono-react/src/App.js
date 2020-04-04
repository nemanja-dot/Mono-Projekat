import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';

function App() {
  const [vehicleMakes, setVehicleMakes] = useState([]);
  
  useEffect(() => {
    axios.get('https://localhost:44339/api/VehicleMakes/GetVehicleMake').then(res => {
      console.log(res.data);  
      setVehicleMakes(res.data);
    });
  }, [setVehicleMakes]);
  console.log(vehicleMakes);

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Izmeni <code>src/App.js</code> i spremi.
        {vehicleMakes && vehicleMakes.map(makes => <p>{makes.name}</p>)}
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
