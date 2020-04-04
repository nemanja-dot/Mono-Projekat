import React from 'react';  
import ReactDOM from 'react-dom';  
import './index.css';  
import * as serviceWorker from './serviceWorker';  
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';  
import ActionVehicleMake from './CRUD/ActionVehicleMake';  

ReactDOM.render(<ActionVehicleMake />, document.getElementById('root'));  
serviceWorker.unregister(); 
