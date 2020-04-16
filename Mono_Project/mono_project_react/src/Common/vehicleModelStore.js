import { observable, runInAction, decorate } from "mobx";
import vehicleModelService from "./vehicleModelService";

class vehicleModelStore {
  constructor() {
    this.vehicleModelService = new vehicleModelService();
  }
  countryData = {
    model: [],
  };
  vehicleModels = [];

  editData = [];
  Pages;
  pagesIndex;
  status = "initial";
  SearchString = "";

  getAllVehicleModelsAsync = async () => {
    try {
      var pagingData = {
        Page: this.countryData.pageNumber,
        SearchString: this.SearchString,
        SortOrder: this.countryData.isAscending,
        Count: this.perPage,
      };
      const urlParams = new URLSearchParams(Object.entries(pagingData));
      const data = await this.vehicleModelService.getAll(urlParams);
      runInAction(() => {
        console.log(data);
        this.vehicleModels = data.items;
        this.Pages = data.totalPages;
        this.pagesIndex = data.pageIndex;
        this.countryData = data;
        this.hasNextPage = data.hasNextPage;
        this.hasPreviousPage = data.hasPreviousPage;
      });
    } catch (error) {
      runInAction(() => {
        this.status = "error";
      });
    }
  };
  getVehicleModelAsync = async (id) => {
    try {
      const dataId = await this.vehicleModelService.get(id);
      runInAction(() => {
        console.log(dataId);
        // this.vehicleMakeId = dataId.id;
        // this.vehicleMakeName = dataId.name;
        // this.vehicleMakeAbrv = dataId.abrv;
        this.editData = dataId;
      });
    } catch (error) {
      runInAction(() => {
        this.status = "error";
      });
    }
  };
  createVehicleModelAsync = async (model) => {
    try {
      const response = await this.vehicleModelService.post(model);
      if (response.status === 201) {
        runInAction(() => {
          this.status = "success";
        });
      }
    } catch (error) {
      runInAction(() => {
        this.status = "error";
      });
    }
  };
  updateVehicleModelAsync = async (vehicle) => {
    try {
      const response = await this.vehicleModelService.put(vehicle);
      if (response.status === 204) {
        runInAction(() => {
          this.status = "success";
        });
      }
    } catch (error) {
      runInAction(() => {
        this.status = "error";
      });
    }
  };
  deleteVehicleModelAsync = async (id) => {
    try {
      const response = await this.vehicleModelService.delete(id);
      if (response.status === 200) {
        runInAction(() => {
          this.countryData.pageNumber = 0;
          this.perPage = 5;
          this.getAllVehicleModelsAsync();
          this.status = "success";
        });
      }
    } catch (error) {
      runInAction(() => {
        this.status = "error";
      });
    }
  };
}

decorate(vehicleModelStore, {
  countryData: observable,
  vehicleModels: observable,
  //   vehicleMakeId: observable,
  //   vehicleMakeName: observable,
  //   vehicleMakeAbrv: observable,
  Pages: observable,
  pagesIndex: observable,
  hasNextPage: observable,
  hasPreviousPage: observable,
  SearchString: observable,
  status: observable,
  urlParams: observable,
  urlParamsId: observable,
  perPage: observable,
  editData: observable,
});

export default new vehicleModelStore();
