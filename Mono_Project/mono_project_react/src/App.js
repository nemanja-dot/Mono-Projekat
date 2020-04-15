import React, { Component } from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  NavLink,
} from "react-router-dom";
import "./App.css";
import { Layout } from "./Layouts/Layout";
import vehicleMakeList from "./Components/vehicleMakeList";
import vehicleModelList from "./Pages/vehicleModelList";
import {
  vehicleMakeCreate,
  vehicleMakeEdit,
  vehicleModelCreate,
  vehicleModelEdit,
} from "./Components";

// class App extends Component {
//   render() {
//     return (
//       <Router>
//         <div>
//           <nav className="navbar navbar-expand navbar-dark bg-dark">
//             <a href="/" className="navbar-brand">
//               Mono React
//             </a>
//             <NavLink
//               variant="info"
//               className="item"
//               activeClassName="active"
//               exact
//               to="/Components/vehicleMakeList"
//             >
//               Vehicle Make List
//             </NavLink>
//             <NavLink
//               variant="info"
//               className="item"
//               activeClassName="active"
//               exact
//               to="/Components/vehicleModelList"
//             >
//               Vehicle Model List
//             </NavLink>
//             <div className="navbar-nav mr-auto"></div>
//           </nav>
//           <div className="container mt-3">
//             <Switch>
//               <Route
//                 exact
//                 path="/Components/vehicleMakeList"
//                 component={vehicleMakeList}
//               />
//               <Route
//                 exact
//                 path="/Components/vehicleModelList"
//                 component={vehicleModelList}
//               />
//               <Route
//                 path="/Components/vehicleMakeCreate"
//                 component={vehicleMakeCreate}
//               />
//               <Route
//                 path="/Components/vehicleModelCreate"
//                 component={vehicleModelCreate}
//               />
//               <Route
//                 path="/Components/vehicleMakeEdit"
//                 component={vehicleMakeEdit}
//               />
//               <Route
//                 path="/Components/vehicleModelEdit"
//                 component={vehicleModelEdit}
//               />
//               {/* <Route path="/Common/vehicleMakeDelete" component={vehicleMakeDelete} /> */}
//             </Switch>
//           </div>
//         </div>
//       </Router>
//     );
//   }
// }

// export default App;

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route
          exact
          path="/Components/vehicleMakeList"
          component={vehicleMakeList}
        />
        <Route
          path="/Components/vehicleModelList"
          component={vehicleModelList}
        />
        <Route
          path="/Components/vehicleMakeCreate"
          component={vehicleMakeCreate}
        />
        <Route
          path="/Components/vehicleModelCreate"
          component={vehicleModelCreate}
        />
        <Route path="/Components/vehicleMakeEdit" component={vehicleMakeEdit} />
        <Route
          path="/Components/vehicleModelEdit"
          component={vehicleModelEdit}
        />
      </Layout>
    );
  }
}
