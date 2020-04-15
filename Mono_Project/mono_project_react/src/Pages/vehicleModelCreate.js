import * as React from "react";
import { observer, inject } from "mobx-react";
import { VehicleModelEditingTable } from "../Components";

class vehicleModelCreate extends React.Component {
  constructor(props) {
    super(props);
    this.state = this.model;
    this.onChange = this.onChange.bind(this);
  }
  model = { vehicleMakeId: "", id: "", name: "", abrv: "" };

  createVehicleModel = (e) => {
    e.preventDefault();
    this.props.vehicleModelStore.createVehicleModelAsync({
      vehicleMakeId: this.state.vehicleMakeId,
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
          <VehicleModelEditingTable
            editing={this.createVehicleModel}
            state={this.state}
            onChange={this.onChange}
          />
        </div>
      </div>
    );
  }
}

export default inject("vehicleModelStore")(observer(vehicleModelCreate));
