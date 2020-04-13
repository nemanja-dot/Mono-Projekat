import React from "react";
import { Table, Button } from "react-bootstrap";
import { observer, inject } from "mobx-react";
import { NavLink } from "react-router-dom";

class vehicleMakeList extends React.Component {
  componentDidMount() {
    if ((this.props.vehicleMakeStore.perPage = "undefinided")) {
      this.props.vehicleMakeStore.perPage = 5;
    }
    if ((this.props.vehicleMakeStore.countryData.pageNumber = "undefinided")) {
      this.props.vehicleMakeStore.countryData.pageNumber = 0;
    }
    this.props.vehicleMakeStore.getAllVehicleMakesAsync();
  }

  searchVehicleMake = (e) => {
    if (e.key == "Enter") {
      this.props.vehicleMakeStore.SearchString = e.target.value;
      this.props.vehicleMakeStore.countryData.pageNumber = 0;
      this.props.vehicleMakeStore.perPage = 5;
      this.props.vehicleMakeStore.getAllVehicleMakesAsync();
    }
  };

  sortVehicleMake = () => {
    this.props.vehicleMakeStore.countryData.isAscending = "isAscending";
    this.props.vehicleMakeStore.countryData.pageNumber = 0;
    this.props.vehicleMakeStore.perPage = 5;
    this.props.vehicleMakeStore.getAllVehicleMakesAsync();
  };

  perPage = (count) => {
    if (count == 10) {
      this.props.vehicleMakeStore.perPage = 10;
    }
    if (count == 20) {
      this.props.vehicleMakeStore.perPage = 20;
    }
    this.props.vehicleMakeStore.countryData.pageNumber = 0;
    this.props.vehicleMakeStore.getAllVehicleMakesAsync();
  };

  nextPage = () => {
    if (this.props.vehicleMakeStore.hasNextPage == true) {
      this.props.vehicleMakeStore.countryData.pageNumber =
        this.props.vehicleMakeStore.pagesIndex + 1;
    }
    if (this.props.vehicleMakeStore.hasNextPage == false) {
      this.props.vehicleMakeStore.countryData.pageNumber = this.props.vehicleMakeStore.pagesIndex;
    }
    this.props.vehicleMakeStore.getAllVehicleMakesAsync();
  };

  previousPage = () => {
    if (this.props.vehicleMakeStore.hasPreviousPage == true) {
      this.props.vehicleMakeStore.countryData.pageNumber =
        this.props.vehicleMakeStore.pagesIndex - 1;
    }
    if (this.props.vehicleMakeStore.hasPreviousPage == false) {
      this.props.vehicleMakeStore.countryData.pageNumber = this.props.vehicleMakeStore.pagesIndex;
    }
    this.props.vehicleMakeStore.getAllVehicleMakesAsync();
  };

  deleteVehicleMake = (e, Id) => {
    const { deleteVehicleMakeAsync } = this.props.vehicleMakeStore;
    deleteVehicleMakeAsync(Id);
  };
  editUser = (model) => {
    this.props.vehicleMakeStore.make = model;
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
                onKeyPress={this.searchVehicleMake}
              />
            </th>
            <th>
              <Button
                variant="link"
                className="badge badge-info"
                onClick={() => this.sortVehicleMake()}
              >
                Sort Vehicle Make
              </Button>
            </th>
          </tr>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Abrv</th>
          </tr>
        </thead>
        <tbody>
          {this.props.vehicleMakeStore.vehicleMakes.map((vehicleMake) => (
            <tr key={vehicleMake.id}>
              <td>{vehicleMake.id}</td>
              <td>{vehicleMake.name}</td>
              <td>{vehicleMake.abrv}</td>
              <td>
                <NavLink
                  className="badge badge-warning"
                  activeClassName="active"
                  exact
                  onClick={(event) => this.editUser(vehicleMake)}
                  to="./Components/vehicleMakeEdit"
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
                  to="./Components/vehicleMakeCreate"
                >
                  Add Vehicle Make
                </NavLink>
              </td>
              <td>
                <Button
                  size="sm"
                  variant="badge badge-danger mr-2"
                  onClick={(event) =>
                    this.deleteVehicleMake(event, vehicleMake.id)
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
              Pages = {this.props.vehicleMakeStore.pagesIndex + 1}/
              {this.props.vehicleMakeStore.Pages}
            </th>
          </tr>
        </tfoot>
      </Table>
    );
  }
}

export default inject("vehicleMakeStore")(observer(vehicleMakeList));
