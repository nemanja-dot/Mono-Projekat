import React, { Component } from 'react';  
  
import { Container, Button } from 'react-bootstrap';  
import GetVehicleMake from './GetVehicleMake';  
import AddVehicleMake from './AddVehicleMake';  
import axios from 'axios';  
const apiUrl = 'https://localhost:44339/api/VehicleMakes/';  
  
class ActionVehicleMake extends Component {  
  constructor(props) {  
    super(props);  
  
    this.state = {  
      isAddUser: false,  
      error: null,  
      response: {},  
      userData: {},  
      isEdituser: false,  
      isUserDetails:true,  
    }  
  
    this.onFormSubmit = this.onFormSubmit.bind(this);  
  
  }  
  
  onCreate() {  
    this.setState({ isAddUser: true });  
    this.setState({ isUserDetails: false });  
  }  
  onDetails() {  
    this.setState({ isUserDetails: true });  
    this.setState({ isAddUser: false });  
  }  
  
  onFormSubmit(data) {  
    this.setState({ isAddUser: true });  
    this.setState({ isUserDetails: false });  
    if (this.state.isEdituser) {  
     axios.put(apiUrl + 'UpdateVehicleMakeId',data).then(result => {  
      alert(result.data);  
        this.setState({  
          response:result,    
          isAddUser: false,  
          isEdituser: false  
        })  
      });  
    } else {  
     
     axios.post(apiUrl + 'CreateVehicleMake',data).then(result => {  
      alert(result.data);  
        this.setState({  
          response:result,    
          isAddUser: false,  
          isEdituser: false  
        })  
      });  
    }  
    
  }  
  
  editUser = userId => {  
  
    this.setState({ isUserDetails: false });  
   axios.get(apiUrl + "GetVehicleMakeId/" + userId).then(result => {  
  
        this.setState({  
          isEdituser: true,  
          isAddUser: true,  
          userData: result.data           
        });  
      },  
      (error) => {  
        this.setState({ error });  
      }  
    )  
     
  }  
  
  render() {  
    
    let userForm;  
    if (this.state.isAddUser || this.state.isEditUser) {  
  
      userForm = <AddVehicleMake onFormSubmit={this.onFormSubmit} user={this.state.userData} />  
       
    }  
    return (  
      <div className="App">  
 <Container>  
        <h1 style={{ textAlign: 'center' }}>CURD operation in React</h1>  
        <hr></hr>  
        {!this.state.isUserDetails && <Button variant="primary" onClick={() => this.onDetails()}> User Details</Button>}  
        {!this.state.isAddUser && <Button variant="primary" onClick={() => this.onCreate()}>Add User</Button>}  
        <br></br>  
        {!this.state.isAddUser && <GetVehicleMake editUser={this.editUser} />}  
        {userForm}  
        </Container>  
      </div>  
    );  
  }  
}  
export default ActionVehicleMake; 