import React, { Component } from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  NavLink,
} from "react-router-dom";
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
            <a href="/" className="navbar-brand">
              Mono React
            </a>
            <NavLink
              variant="info"
              className="item"
              activeClassName="active"
              exact
              to="/"
            >
              Vehicle Make List
            </NavLink>
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
