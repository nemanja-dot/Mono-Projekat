import * as React from "react";
import { observer, inject } from "mobx-react";
import { VehicleMakeEditingTable } from "../Components";

class vehicleMakeCreate extends React.Component {
  constructor(props) {
    super(props);
    this.state = this.model;
    this.onChange = this.onChange.bind(this);
  }
  model = { id: "", name: "", abrv: "" };

  createVehicleMake = (e) => {
    e.preventDefault();
    this.props.vehicleMakeStore.createVehicleMakeAsync({
      id: this.state.id,
      name: this.state.name,
      abrv: this.state.abrv,
    });
  };
  onChange(event) {
    console.log(event.target.value);
    const name = event.target.name;
    const value = event.target.value;
    this.setState({
      [name]: value,
    });
  }
  render() {
    return (
      <div>
        <div>
          <VehicleMakeEditingTable
            editing={this.createVehicleMake}
            state={this.state}
            onChange={this.onChange}
          />
        </div>
      </div>
    );
  }
}

export default inject("vehicleMakeStore")(observer(vehicleMakeCreate));
