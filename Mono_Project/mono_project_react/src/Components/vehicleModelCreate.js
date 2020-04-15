import * as React from "react";
import { observer, inject } from "mobx-react";

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
      vehicleMakeId: this.refs.vehicleMakeId.value,
      id: this.refs.id.value,
      name: this.refs.name.value,
      abrv: this.refs.abrv.value,
    });
    this.refs.vehicleMakeId.value = null;
    this.refs.id.value = null;
    this.refs.name.value = null;
    this.refs.abrv.value = null;
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
          <form onSubmit={this.createVehicleModel}>
            <div className="form-group">
              <input
                ref="vehicleMakeId"
                value={this.state.vehicleMakeId}
                id="vehicleMakeId"
                type="text"
                name="vehicleMakeId"
                placeholder="Make Id"
                onChange={this.onChange}
              />
            </div>
            <div className="form-group">
              <input
                ref="id"
                value={this.state.id}
                id="id"
                type="text"
                name="id"
                placeholder="id"
                onChange={this.onChange}
              />
            </div>
            <div className="form-group">
              <input
                ref="name"
                type="text"
                name="name"
                placeholder="Name"
                value={this.state.name}
                onChange={this.onChange}
              />
            </div>
            <div className="form-group">
              <input
                ref="abrv"
                type="text"
                name="abrv"
                value={this.state.abrv}
                placeholder="Abrv"
                onChange={this.onChange}
              />
            </div>
            <button type="submit">Save</button>
          </form>
        </div>
      </div>
    );
  }
}

export default inject("vehicleModelStore")(observer(vehicleModelCreate));
