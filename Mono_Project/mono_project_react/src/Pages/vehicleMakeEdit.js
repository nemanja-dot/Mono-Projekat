import * as React from "react";
import { observer, inject } from "mobx-react";
import { VehicleMakeEditingTable } from "../Components";

class vehicleMakeEdit extends React.Component {
  constructor(props) {
    super(props);
    this.state = this.props.vehicleMakeStore.editData;
    this.onChange = this.onChange.bind(this);
  }

  componentDidMount() {
    if (this.props.vehicleMakeStore.editData) {
      this.props.vehicleMakeStore.getVehicleMakeAsync(
        this.props.vehicleMakeStore.editData.id
      );
      this.setState(this.props.vehicleMakeStore.editData);
    }
  }

  vehicleMakeEdit = (e) => {
    e.preventDefault();
    this.props.vehicleMakeStore.updateVehicleMakeAsync({
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
            editing={this.vehicleMakeEdit}
            state={this.state}
            onChange={this.onChange}
          />
        </div>
      </div>
    );
  }
}

export default inject("vehicleMakeStore")(observer(vehicleMakeEdit));
