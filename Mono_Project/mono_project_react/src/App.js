import React, { Component } from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import { Container } from "semantic-ui-react";
import { Row, Form, Col, Table, Button } from "react-bootstrap";
import logo from "./logo.svg";
import "./App.css";
import vehicleMakeList from "./Components/vehicleMakeList";
import vehicleMakeCreate from "./Components/vehicleMakeCreate";
import vehicleMakeEdit from "./Components/vehicleMakeEdit";

class App extends Component {
  render() {
    return (
      <Router>
        <div>
          <nav className="navbar navbar-expand navbar-dark bg-dark">
            <a className="navbar-brand">Mono React</a>
            <div className="navbar-nav mr-auto"></div>
          </nav>
          <div className="container mt-3">
            <Switch>
              <Route exact path="/" component={vehicleMakeList} />
              <Route
                path="/Components/vehicleMakeCreate"
                component={vehicleMakeCreate}
              />
              <Route
                path="/Components/vehicleMakeEdit"
                component={vehicleMakeEdit}
              />
              {/* <Route path="/Common/vehicleMakeDelete" component={vehicleMakeDelete} /> */}
            </Switch>
          </div>
        </div>
      </Router>
    );
  }
}

export default App;
