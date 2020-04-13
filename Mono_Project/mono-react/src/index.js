import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import "./index.css";
import * as serviceWorker from "./serviceWorker";
import "../node_modules/bootstrap/dist/css/bootstrap.min.css";
import App from "./App";
import { Provider } from "mobx-react";
import vehicleMakeStore from "./Common/vehicleMakeStore";

ReactDOM.render(
  <BrowserRouter>
    <Provider vehicleMakeStore={vehicleMakeStore}>
      <App />
    </Provider>
  </BrowserRouter>,
  document.getElementById("root")
);

serviceWorker.unregister();
