import React from "react";

const Search = (props) => (
  <input type="search" placeholder="Search" onKeyPress={props.search} />
);

export default Search;
