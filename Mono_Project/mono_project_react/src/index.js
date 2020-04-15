import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import "./index.css";
import "../node_modules/bootstrap/dist/css/bootstrap.min.css";
import App from "./App";
import * as serviceWorker from "./serviceWorker";
import { Provider } from "mobx-react";
import { vehicleMakeStore } from "./Common";
import { vehicleModelStore } from "./Common";

ReactDOM.render(
  <BrowserRouter>
    <Provider
      vehicleMakeStore={vehicleMakeStore}
      vehicleModelStore={vehicleModelStore}
    >
      <App />
    </Provider>
  </BrowserRouter>,
  document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
