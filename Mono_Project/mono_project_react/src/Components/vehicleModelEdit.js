import * as React from "react";
import { observer, inject } from "mobx-react";
import VehicleModelEditingTable from "./vehicleModelEditingTable";

class vehicleModelEdit extends React.Component {
  constructor(props) {
    super(props);
    this.state = this.props.vehicleModelStore.editData;
    this.onChange = this.onChange.bind(this);
    // const vehicleMakeId = React.useRef(this.state.vehicleMakeId);
    // const id = React.useRef(this.state.id);
    // const name = React.useRef(this.state.name);
    // const abrv = React.useRef(this.state.abrv);
  }
  model = { vehicleMakeId: "", id: "", name: "", abrv: "" };

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
      vehicleMakeId: this.state.vehicleMakeId, // this.model.vehicleMakeId,
      id: this.state.id, // this.model.id,
      name: this.state.name, // this.model.name,
      abrv: this.state.abrv, // this.model.abrv,
    });

    // this.refs.vehicleMakeId.value = null;
    // this.refs.id.value = null;
    // this.refs.name.value = null;
    // this.refs.abrv.value = null;
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
          <form onSubmit={this.vehicleModelEdit}>
            <VehicleModelEditingTable
              state={this.state}
              onChange={this.onChange}
              // vehicleMakeId={this.state.vehicleMakeId}
              // id={this.state.id}
              // name={this.state.id}
              // abrv={this.state.id}
              // vehicleMakeId={this.refs.vehicleMakeId.value}
              // id={this.refs.id.value}
              // name={this.refs.name.value}
              // abrv={this.refs.abrv.value}
              // vehicleMakeId={this.model.vehicleMakeId}
              // id={this.model.id}
              // name={this.model.name}
              // abrv={this.model.abrv}
              // vehicleMakeId={this.ref}
              // id={this.ref}
              // name={this.ref}
              // abrv={this.ref}
            />
            <button variant="success" type="submit">
              Save
            </button>
          </form>
        </div>
      </div>
    );
  }
}

export default inject("vehicleModelStore")(observer(vehicleModelEdit));
