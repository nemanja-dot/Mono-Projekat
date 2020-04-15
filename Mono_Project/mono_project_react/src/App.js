import React, { Component } from "react";
import { BrowserRouter as Router, Route } from "react-router-dom";
import "./App.css";
import { Layout } from "./Layouts";
import {
  vehicleMakeCreate,
  vehicleMakeEdit,
  vehicleModelCreate,
  vehicleModelEdit,
  vehicleMakeList,
  vehicleModelList,
} from "./Pages";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/vehicleMakeList" component={vehicleMakeList} />
        <Route path="/vehicleModelList" component={vehicleModelList} />
        <Route path="/vehicleMakeCreate" component={vehicleMakeCreate} />
        <Route path="/vehicleModelCreate" component={vehicleModelCreate} />
        <Route path="/vehicleMakeEdit" component={vehicleMakeEdit} />
        <Route path="/vehicleModelEdit" component={vehicleModelEdit} />
      </Layout>
    );
  }
}
