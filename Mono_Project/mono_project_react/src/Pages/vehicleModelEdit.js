import * as React from "react";
import { observer, inject } from "mobx-react";
import { VehicleModelEditingTable } from "../Components";

class vehicleModelEdit extends React.Component {
  constructor(props) {
    super(props);
    this.state = this.props.vehicleModelStore.editData;
    this.onChange = this.onChange.bind(this);
  }

  componentDidMount() {
    if (this.props.vehicleModelStore.editData) {
      this.props.vehicleModelStore.getVehicleModelAsync(
        this.props.vehicleModelStore.editData.id
      );
      this.setState(this.props.vehicleModelStore.editData);
    }
  }

  vehicleModelEdit = (e) => {
    e.preventDefault();
    this.props.vehicleModelStore.updateVehicleModelAsync({
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
            editing={this.vehicleModelEdit}
            state={this.state}
            onChange={this.onChange}
          />
        </div>
      </div>
    );
  }
}

export default inject("vehicleModelStore")(observer(vehicleModelEdit));
