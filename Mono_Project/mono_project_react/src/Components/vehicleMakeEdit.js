import * as React from "react";
import { observer, inject } from "mobx-react";

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
      id: this.refs.id.value,
      name: this.refs.name.value,
      abrv: this.refs.abrv.value,
    });

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
          <form onSubmit={this.vehicleMakeEdit}>
            <div className="form-group">
              <input
                ref="id"
                value={this.state.id}
                id="id"
                type="text"
                placeholder="id"
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
            <button variant="success" type="submit">
              Save
            </button>
          </form>
        </div>
      </div>
    );
  }
}

export default inject("vehicleMakeStore")(observer(vehicleMakeEdit));
