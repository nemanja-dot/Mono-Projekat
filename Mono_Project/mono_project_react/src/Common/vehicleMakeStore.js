import { observable, runInAction, decorate } from "mobx";
import vehicleMakeService from "./vehicleMakeService";

class vehicleMakeStore {
  constructor() {
    this.vehicleMakeService = new vehicleMakeService();
  }
  countryData = {
    model: [],
  };
  vehicleMakes = [];

  editData = [];
  Pages;
  pagesIndex;
  status = "initial";
  SearchString = "";

  getAllVehicleMakesAsync = async () => {
    try {
      var pagingData = {
        Page: this.countryData.pageNumber,
        SearchString: this.SearchString,
        SortOrder: this.countryData.isAscending,
        Count: this.perPage,
      };
      const urlParams = new URLSearchParams(Object.entries(pagingData));
      const data = await this.vehicleMakeService.getAll(urlParams);
      runInAction(() => {
        console.log(data);
        this.vehicleMakes = data.items;
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
  getVehicleMakeAsync = async (id) => {
    try {
      const dataId = await this.vehicleMakeService.get(id);
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
  createVehicleMakeAsync = async (model) => {
    try {
      const response = await this.vehicleMakeService.post(model);
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
  updateVehicleMakeAsync = async (vehicle) => {
    try {
      const response = await this.vehicleMakeService.put(vehicle);
      if (response.status === 200) {
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
  deleteVehicleMakeAsync = async (id) => {
    try {
      const response = await this.vehicleMakeService.delete(id);
      if (response.status === 200) {
        runInAction(() => {
          this.countryData.pageNumber = 0;
          this.perPage = 5;
          this.getAllVehicleMakesAsync();
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

decorate(vehicleMakeStore, {
  countryData: observable,
  vehicleMakes: observable,
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

export default new vehicleMakeStore();
