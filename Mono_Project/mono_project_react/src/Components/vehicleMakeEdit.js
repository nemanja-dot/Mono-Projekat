import * as React from "react";
import { Table, Button } from "react-bootstrap";
import { observer, inject } from "mobx-react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

class vehicleMakeEdit extends React.Component {
  constructor(props) {
    super(props);
    this.state = this.props.vehicleMakeStore.make;
    this.onChange = this.onChange.bind(this);
  }

  // componentDidMount() {
  //   if (this.props.CountryStore.id == "undefinided") {
  //     this.props.CountryStore.id = 26;
  //   }
  //   // if ((this.props.CountryStore.countryData.pageNumber = "undefinided")) {
  //   //   this.props.CountryStore.countryData.pageNumber = 0;
  //   // }
  //   this.props.CountryStore.getIdCountriesAsync();
  // }
  componentDidMount() {
    if (this.props.vehicleMakeStore.make) {
      this.props.vehicleMakeStore.getVehicleMakeAsync(
        this.props.vehicleMakeStore.make.id
      );
      this.setState(this.props.vehicleMakeStore.make);
    }
  }

  vehicleMakeEdit = (e) => {
    e.preventDefault();
    this.props.vehicleMakeStore.updateVehicleMakeAsync({
      id: this.refs.id.value,
      name: this.refs.name.value,
      abrv: this.refs.abrv.value,
    });
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
          <form onSubmit={this.vehicleMakeEdit}>
            <div className="form-group">
              <input
                ref="id"
                value={this.state.id}
                id="id"
                type="text"
                placeholder="id"
                //onChange={this.onChange}
              />
            </div>
            <div className="form-group">
              <input
                ref="name"
                // id="vehicleMakeName"
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
                // id="abrv"
                // type="text"
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
