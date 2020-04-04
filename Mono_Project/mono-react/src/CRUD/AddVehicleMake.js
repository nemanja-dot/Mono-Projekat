import React from 'react';  
import { Row, Form, Col, Button } from 'react-bootstrap';  
  
class AddVehicleMake extends React.Component {  
  constructor(props) {  
    super(props);  
   
    this.initialState = {  
      Id: '',  
      Name: '',  
      Abrv: '', 
    }  
  
    if (props.user.id) {  
      this.state = props.user  
    } else {  
      this.state = this.initialState;  
    }  
  
    this.handleChange = this.handleChange.bind(this);  
    this.handleSubmit = this.handleSubmit.bind(this);  
  
  }  
  
  handleChange(event) {  
    const name = event.target.name;  
    const value = event.target.value;  
  
    this.setState({  
      [name]: value  
    })  
  }  
  
  handleSubmit(event) {  
    event.preventDefault();  
    this.props.onFormSubmit(this.state);  
    this.setState(this.initialState);  
  }  
  render() {  
    let pageTitle;  
    let actionStatus;  
    if (this.state.id) {  
  
      pageTitle = <h2>Edit User</h2>  
      actionStatus = <b>Update</b>  
    } else {  
      pageTitle = <h2>Add User</h2>  
      actionStatus = <b>Save</b>  
    }  
  
    return (  
      <div>        
        <h2> {pageTitle}</h2>  
        <Row>  
          <Col sm={7}>  
            <Form onSubmit={this.handleSubmit}>  
              <Form.Group controlId="Id">  
                <Form.Label>Id</Form.Label>  
                <Form.Control  
                  type="text"  
                  name="Id"  
                  value={this.state.id}  
                  onChange={this.handleChange}  
                  placeholder="Id" />  
              </Form.Group>  
              <Form.Group controlId="Name">  
                <Form.Label>Name</Form.Label>  
                <Form.Control  
                  type="text"  
                  name="Name"  
                  value={this.state.name}  
                  onChange={this.handleChange}  
                  placeholder="Name" />  
              </Form.Group>  
              <Form.Group controlId="Abrv">  
                <Form.Label>Abrv</Form.Label>  
                <Form.Control  
                  type="text"  
                  name="Abrv"  
                  value={this.state.abrv}  
                  onChange={this.handleChange}  
                  placeholder="Abrrv" />  
              </Form.Group>   
              <Form.Group>  
                <Form.Control type="hidden" name="UserId" value={this.state.UserId} />  
                <Button variant="success" type="submit">{actionStatus}</Button>            
  
              </Form.Group>  
            </Form>  
          </Col>  
        </Row>  
      </div>  
    )  
  }  
}  
  
export default AddVehicleMake;