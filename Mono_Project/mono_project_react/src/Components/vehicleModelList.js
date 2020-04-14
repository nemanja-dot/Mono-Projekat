import React from "react";
import { Table, Button } from "react-bootstrap";
import { observer, inject } from "mobx-react";
import { NavLink } from "react-router-dom";

class vehicleModelList extends React.Component {
  componentDidMount() {
    if ((this.props.vehicleModelStore.perPage = "undefinided")) {
      this.props.vehicleModelStore.perPage = 5;
    }
    if ((this.props.vehicleModelStore.countryData.pageNumber = "undefinided")) {
      this.props.vehicleModelStore.countryData.pageNumber = 0;
    }
    this.props.vehicleModelStore.getAllVehicleModelsAsync();
  }

  searchVehicleModel = (e) => {
    if (e.key == "Enter") {
      this.props.vehicleModelStore.SearchString = e.target.value;
      this.props.vehicleModelStore.countryData.pageNumber = 0;
      this.props.vehicleModelStore.perPage = 5;
      this.props.vehicleModelStore.getAllVehicleModelsAsync();
    }
  };

  sortVehicle = () => {
    this.props.vehicleModelStore.countryData.isAscending = "isAscending";
    this.props.vehicleModelStore.countryData.pageNumber = 0;
    this.props.vehicleModelStore.perPage = 5;
    this.props.vehicleModelStore.getAllVehicleModelsAsync();
  };

  perPage = (count) => {
    if (count == 10) {
      this.props.vehicleModelStore.perPage = 10;
    }
    if (count == 20) {
      this.props.vehicleModelStore.perPage = 20;
    }
    this.props.vehicleModelStore.countryData.pageNumber = 0;
    this.props.vehicleModelStore.getAllVehicleModelsAsync();
  };

  nextPage = () => {
    if (this.props.vehicleModelStore.hasNextPage == true) {
      this.props.vehicleModelStore.countryData.pageNumber =
        this.props.vehicleModelStore.pagesIndex + 1;
    }
    if (this.props.vehicleModelStore.hasNextPage == false) {
      this.props.vehicleModelStore.countryData.pageNumber = this.props.vehicleModelStore.pagesIndex;
    }
    this.props.vehicleModelStore.getAllVehicleModelsAsync();
  };

  previousPage = () => {
    if (this.props.vehicleModelStore.hasPreviousPage == true) {
      this.props.vehicleModelStore.countryData.pageNumber =
        this.props.vehicleModelStore.pagesIndex - 1;
    }
    if (this.props.vehicleModelStore.hasPreviousPage == false) {
      this.props.vehicleModelStore.countryData.pageNumber = this.props.vehicleModelStore.pagesIndex;
    }
    this.props.vehicleModelStore.getAllVehicleModelsAsync();
  };

  deleteVehicleModel = (e, Id) => {
    const { deleteVehicleModelAsync } = this.props.vehicleModelStore;
    deleteVehicleModelAsync(Id);
  };
  editUser = (model) => {
    this.props.vehicleModelStore.editData = model;
  };

  render() {
    return (
      <Table>
        <thead>
          <tr>
            <th>
              <input
                type="search"
                placeholder="Search"
                onKeyPress={this.searchVehicleModel}
              />
            </th>
            <th>
              <Button
                variant="link"
                className="badge badge-info"
                onClick={() => this.sortVehicleModel()}
              >
                Sort Vehicle Make
              </Button>
            </th>
          </tr>
          <tr>
            <th>Vehicle Make Id</th>
            <th>Id</th>
            <th>Name</th>
            <th>Abrv</th>
          </tr>
        </thead>
        <tbody>
          {this.props.vehicleModelStore.vehicleModels.map((vehicleModel) => (
            <tr key={vehicleModel.id}>
              <td>{vehicleModel.vehicleMakeId}</td>
              <td>{vehicleModel.id}</td>
              <td>{vehicleModel.name}</td>
              <td>{vehicleModel.abrv}</td>
              <td>
                <NavLink
                  className="badge badge-warning"
                  activeClassName="active"
                  exact
                  onClick={(event) => this.editUser(vehicleModel)}
                  to="./vehicleModelEdit"
                >
                  Edit
                </NavLink>
              </td>
              <td>
                <NavLink
                  variant="pills"
                  className="badge badge-info"
                  activeClassName="active"
                  exact
                  to="./vehicleModelCreate"
                >
                  Add Vehicle Model
                </NavLink>
              </td>
              <td>
                <Button
                  size="sm"
                  variant="badge badge-danger mr-2"
                  onClick={(event) =>
                    this.deleteVehicleModel(event, vehicleModel.id)
                  }
                >
                  Delete
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
        <tfoot>
          <tr>
            <td>
              <Button variant="info" onClick={() => this.previousPage()}>
                Previous Page
              </Button>
            </td>
            <td>
              <Button variant="info" onClick={() => this.nextPage()}>
                Next Page
              </Button>
            </td>
          </tr>
          <tr>
            <td>
              <Button variant="link" onClick={() => this.perPage(10)}>
                Per Page 10
              </Button>
            </td>
            <td>
              <Button variant="link" onClick={() => this.perPage(20)}>
                Per Page 20
              </Button>
            </td>
          </tr>
          <tr>
            <th>
              Pages = {this.props.vehicleModelStore.pagesIndex + 1}/
              {this.props.vehicleModelStore.Pages}
            </th>
          </tr>
        </tfoot>
      </Table>
    );
  }
}

export default inject("vehicleModelStore")(observer(vehicleModelList));
