import React from "react";
import { Table, Button } from "react-bootstrap";
import { observer, inject } from "mobx-react";
import { NavLink } from "react-router-dom";

const VehicleModelTable = (props) => (
  <Table>
    <thead>
      <tr>
        <th>Vehicle Make Id</th>
        <th>Id</th>
        <th>Name</th>
        <th>Abrv</th>
      </tr>
    </thead>
    <tbody>
      {props.vehicleModels.map((vehicleModel) => (
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
              onClick={(event) => props.editUser(vehicleModel)}
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
                props.deleteVehicleModel(event, vehicleModel.id)
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
          <Button variant="info" onClick={() => props.previousPage()}>
            Previous Page
          </Button>
        </td>
        <td>
          <Button variant="info" onClick={() => props.nextPage()}>
            Next Page
          </Button>
        </td>
      </tr>
      <tr>
        <td>
          <Button variant="link" onClick={() => props.perPage(10)}>
            Per Page 10
          </Button>
        </td>
        <td>
          <Button variant="link" onClick={() => props.perPage(20)}>
            Per Page 20
          </Button>
        </td>
      </tr>
      <tr>
        <th>
          Pages = {props.pagesIndex + 1}/{props.Pages}
        </th>
      </tr>
    </tfoot>
  </Table>
);

export default VehicleModelTable;
