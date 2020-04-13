import * as React from "react";
import { Table, Button } from "react-bootstrap";
import { observer, inject } from "mobx-react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

class vehicleMakeCreate extends React.Component {
  createVehicleMake = (e) => {
    e.preventDefault();
    this.props.vehicleMakeService.createVehicleMakeAsync({
      id: this.refs.id.value,
      name: this.refs.name.value,
      abrv: this.refs.abrv.value,
    });
    this.refs.id.value = null;
    this.refs.name.value = null;
    this.refs.abrv.value = null;
  };
  render() {
    return (
      <div>
        <div>
          <form onSubmit={this.createVehicleMake}>
            <div className="form-group">
              <input ref="id" id="Id" type="text" placeholder="Id" />
            </div>
            <div className="form-group">
              <input ref="name" id="name" type="text" placeholder="name" />
            </div>
            <div className="form-group">
              <input ref="abrv" id="abrv" type="text" placeholder="Abrv" />
            </div>
            <button type="submit">Save</button>
          </form>
        </div>
      </div>
    );
  }
}

export default inject("./Common/vehicleMakeStore")(observer(vehicleMakeCreate));
