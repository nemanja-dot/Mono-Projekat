import React from "react";
import { Button } from "react-bootstrap";
import { observer, inject } from "mobx-react";
import { VehicleModelTable } from "../Components";
import { Search } from "../Components";

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

  sortVehicleModel = () => {
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
      <div>
        <div>
          <table>
            <thead>
              <tr>
                <th>
                  <Search search={this.searchVehicleModel} />
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
            </thead>
          </table>
        </div>
        <VehicleModelTable
          vehicleModels={this.props.vehicleModelStore.vehicleModels}
          deleteVehicleModel={this.deleteVehicleModel}
          editUser={this.editUser}
          nextPage={this.nextPage}
          previousPage={this.previousPage}
          perPage={this.perPage}
          pagesIndex={this.props.vehicleModelStore.pagesIndex}
          Pages={this.props.vehicleModelStore.Pages}
        />
      </div>
    );
  }
}

export default inject("vehicleModelStore")(observer(vehicleModelList));
