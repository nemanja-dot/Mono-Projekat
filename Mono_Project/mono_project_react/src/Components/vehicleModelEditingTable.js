import * as React from "react";

const VehicleModelEditingTable = (props) => {
  return (
    <form onSubmit={props.editing}>
      <div className="form-group">
        <input
          tpye="text"
          name="vehicleMakeId"
          placeholder="Make Id"
          value={props.state.vehicleMakeId}
          onChange={props.onChange}
        />
      </div>
      <div className="form-group">
        <input
          type="text"
          name="id"
          placeholder="id"
          value={props.state.id}
          onChange={props.onChange}
        />
      </div>
      <div className="form-group">
        <input
          type="text"
          name="name"
          placeholder="Name"
          value={props.state.name}
          onChange={props.onChange}
        />
      </div>
      <div className="form-group">
        <input
          type="text"
          name="abrv"
          placeholder="Abrv"
          value={props.state.abrv}
          onChange={props.onChange}
        />
      </div>
      <button variant="success" type="submit">
        Save
      </button>
    </form>
  );
};
export default VehicleModelEditingTable;
