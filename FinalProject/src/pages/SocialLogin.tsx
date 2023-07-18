import React, { useContext, useEffect } from 'react'
import {useNavigate, useSearchParams} from "react-router-dom";
import { AppUserContext } from '../context/StateContext';
import { LocalJwt } from '../types/AuthTypes';
import { getClaimsFromJwt } from '../utils/jwtHelper';

function SocialLogin() {

  const [searchParams] = useSearchParams();

  const navigate = useNavigate();

  const { setAppUser } = useContext(AppUserContext);

  useEffect(() => {

      const accessToken = searchParams.get("access_token");

      const expiryDate = searchParams.get("expiry_date");

      const { uid, email, given_name, family_name} = getClaimsFromJwt(accessToken);

      const expires:string = expiryDate;

      setAppUser({ id:uid, email, firstName:given_name, lastName:family_name, expires, accessToken });

      const localJwt:LocalJwt ={
          accessToken,
          expires
      }

      localStorage.setItem("upstorage_user",JSON.stringify(localJwt));

      navigate("/");

      console.log(email);

      console.log(given_name);

      console.log(family_name);


  },[]);

  return (
 <></>
  )
}


export default SocialLogin;