import * as React from "react";
import { Table, Button } from "react-bootstrap";
import { observer, inject } from "mobx-react";
import { NavLink } from "react-router-dom";

const VehicleModelEditingTable = (props) => {
  //   const vehicleMakeId = React.useRef(props.state.vehicleMakeId);
  //   const id = React.useRef(props.state.id);
  //   const name = React.useRef(props.state.name);
  //   const abrv = React.useRef(props.state.abrv);

  return (
    <table>
      <div className="form-group">
        <input
          //ref={props.vehicleMakeId}
          value={props.state.vehicleMakeId}
          id="vehicleMakeId"
          tpye="text"
          placeholder="Make Id"
        />
      </div>
      <div className="form-group">
        <input
          //ref={props.id}
          value={props.state.id}
          id="id"
          type="text"
          placeholder="id"
        />
      </div>
      <div className="form-group">
        <input
          //ref={props.name}
          type="text"
          name="name"
          placeholder="Name"
          value={props.state.name}
          onChange={props.onChange}
        />
      </div>
      <div className="form-group">
        <input
          //ref={props.abrv}
          type="text"
          name="abrv"
          value={props.state.abrv}
          placeholder="Abrv"
          onChange={props.onChange}
        />
      </div>
    </table>
  );
};
export default VehicleModelEditingTable;
