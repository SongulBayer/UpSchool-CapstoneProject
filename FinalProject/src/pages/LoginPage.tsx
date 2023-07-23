import React, {useContext, useState} from "react";
import {Button, Form, Grid, Header, Icon, Image, Segment} from "semantic-ui-react";

const BASE_URL = import.meta.env.VITE_API_URL;

 function LoginPage() {
  const onGoogleLoginClick = (e:React.FormEvent) => {
    e.preventDefault();

    window.location.href = `${BASE_URL}/Authentication/GoogleSignInStart`;
};
  return (
    <div style={{ marginTop: "300px" }}>
    <center>
   <Button color='blue' fluid onClick={onGoogleLoginClick} size='large' style={{ marginTop: "5px", width: "300px" }} type="button">
      <Icon name='google' /> Sign in with Google
    </Button>
    </center>
  </div>
  )
}

export default LoginPage;


