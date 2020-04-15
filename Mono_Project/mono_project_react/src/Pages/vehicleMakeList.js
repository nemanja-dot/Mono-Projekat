import React from "react";
import { Button } from "react-bootstrap";
import { observer, inject } from "mobx-react";
import { VehicleMakeTable } from "../Components";
import { Search } from "../Components";

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
    this.props.vehicleMakeStore.editData = model;
  };

  render() {
    return (
      <div>
        <div>
          <table>
            <thead>
              <tr>
                <th>
                  <Search search={this.searchVehicleMake} />
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
            </thead>
          </table>
        </div>
        <VehicleMakeTable
          vehicleMakes={this.props.vehicleMakeStore.vehicleMakes}
          deleteVehicleMake={this.deleteVehicleMake}
          editUser={this.editUser}
          nextPage={this.nextPage}
          previousPage={this.previousPage}
          perPage={this.perPage}
          pagesIndex={this.props.vehicleMakeStore.pagesIndex}
          Pages={this.props.vehicleMakeStore.Pages}
        />
      </div>
    );
  }
}

export default inject("vehicleMakeStore")(observer(vehicleMakeList));
