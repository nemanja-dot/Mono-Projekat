import React from "react";
import { Table, Button } from "react-bootstrap";
import { NavLink } from "react-router-dom";

const VehicleMakeTable = (props) => (
  <Table>
    <thead>
      <tr>
        <th>Id</th>
        <th>Name</th>
        <th>Abrv</th>
      </tr>
    </thead>

    <tbody>
      {props.vehicleMakes.map((vehicleMake) => (
        <tr key={vehicleMake.id}>
          <td>{vehicleMake.id}</td>
          <td>{vehicleMake.name}</td>
          <td>{vehicleMake.abrv}</td>
          <td>
            <NavLink
              className="badge badge-warning"
              activeClassName="active"
              exact
              onClick={(event) => props.editUser(vehicleMake)}
              to="./vehicleMakeEdit"
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
              to="./vehicleMakeCreate"
            >
              Add Vehicle Make
            </NavLink>
          </td>
          <td>
            <Button
              size="sm"
              variant="badge badge-danger mr-2"
              onClick={(event) =>
                props.deleteVehicleMake(event, vehicleMake.id)
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

export default VehicleMakeTable;
