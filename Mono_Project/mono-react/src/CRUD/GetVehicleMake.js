import React from "react";
import { Table, Button } from "react-bootstrap";
import axios from "axios";

const apiUrl = "https://localhost:44339/api/VehicleMakes";

class ListVehicleMake extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: undefined,
      users: undefined,
    };
  }

  componentDidMount() {
    axios
      .get(apiUrl + "/GetVehicleMake")
      .then((response) => response.data)
      .then(
        (result) => {
          this.setState({
            users: result,
          });
        },
        (error) => {
          this.setState({ error });
        }
      );
  }

  deleteUser(userId) {
    const { users } = this.state;
    axios.delete(apiUrl + "/DeleteVehicleMakeId/" + userId).then((result) => {
      alert(result.data);
      this.setState({
        response: result,
        users: users.filter((user) => user.UserId !== userId),
      });
    });
  }

  render() {
    const { error, users } = this.state;
    console.log(users);

    if (error) {
      return <div>Error:{error.message}</div>;
    }

    return (
      <div>
        <Table>
          <thead className="btn-primary">
            <tr>
              <th>Id</th>
              <th>Name</th>
              <th>Abrv</th>
            </tr>
          </thead>
          <tbody>
            {!users && (
              <tr>
                <td>Loading...</td>
              </tr>
            )}
            {users &&
              users.items.map((user) => (
                <tr key={user.id}>
                  <td>{user.id}</td>
                  <td>{user.name}</td>
                  <td>{user.abrv}</td>
                  <td>
                    <Button
                      variant="info"
                      onClick={() => this.props.editUser(user.id)}
                    >
                      Edit
                    </Button>
                    <Button
                      variant="danger"
                      onClick={() => this.deleteUser(user.id)}
                    >
                      Delete
                    </Button>
                  </td>
                </tr>
              ))}
          </tbody>
        </Table>
      </div>
    );
  }
}

export default ListVehicleMake;
