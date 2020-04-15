import * as React from "react";

const VehicleMakeEditingTable = (props) => {
  return (
    <form onSubmit={props.editing}>
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
export default VehicleMakeEditingTable;
