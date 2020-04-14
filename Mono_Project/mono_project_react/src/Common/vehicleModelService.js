const webApiUrl = "https://localhost:44339/api/VehicleModels";

class vehicleModelService {
  getAll = async (urlParams) => {
    const options = {
      method: "GET",
    };
    const request = new Request(
      webApiUrl + "/GetVehicleModel?" + urlParams,
      options
    );
    const response = await fetch(request);
    return response.json();
  };

  get = async (id) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    const options = {
      method: "GET",
      headers,
    };
    const request = new Request(
      webApiUrl + "/GetVehicleModelId/" + id,
      options
    );
    const response = await fetch(request);
    return response.json();
  };

  post = async (model) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    var options = {
      method: "POST",
      headers,
      body: JSON.stringify(model),
    };
    const request = new Request(webApiUrl + "/CreateVehicleModel", options);
    const response = await fetch(request);
    return response;
  };
  put = async (model) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    var options = {
      method: "PUT",
      headers,
      body: JSON.stringify(model),
    };
    const request = new Request(webApiUrl + "/UpdateVehicleModelId", options);
    const response = await fetch(request);
    return response;
  };
  delete = async (id) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    const options = {
      method: "DELETE",
      headers,
    };
    const request = new Request(
      webApiUrl + "/DeleteVehicleModelId/" + id,
      options
    );
    const response = await fetch(request);
    return response;
  };
}

export default vehicleModelService;
