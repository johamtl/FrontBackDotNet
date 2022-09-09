import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import {
  setLoggedIn,
  setAccessToken,
  setTokenExpiryDate,
  selectIsLoggedIn,
  selectTokenExpiryDate,
} from './authorizationSlice';
import styles from '../counter/Counter.module.css';
import { getHashParams, removeHashParamsFromUrl } from '../../utils/hashUtils';

import { useMsal } from "@azure/msal-react";
import { myapiLoginRequest } from "../../oauthConfigAzure";
import Button from "react-bootstrap/Button";
import axios, { AxiosRequestConfig, AxiosResponse } from 'axios';

export function Authorization() {

  const dispatch = useDispatch();

  const { instance, accounts } = useMsal();
  const [dogData, setDogData] = useState(null);

  function RequestProfileData() {
    const request = {
      ...myapiLoginRequest,
      account: accounts[0]
    };

    instance.acquireTokenSilent(request).then((response: { accessToken: string; }) => {
      console.log("accessToken: ", response.accessToken);

      //use axios 
      const bearer = `Bearer ${response.accessToken}`;
      const headers = { 'Authorization': bearer };
      const config: AxiosRequestConfig = {
        headers: headers
      };

      axios.get('https://localhost:44319/api/dog', config).then((response) => {
        setDogData(response.data[0].name);      
      }).catch((error) => {
          console.log("ERRRRRRRROOOOOORRRRRRRR ");
        })
    });
  }

  useEffect(() => { //Keep for Redux
    // (access_token) { 
    // dispatch(setAccessToken(access_token));
    // dispatch(setTokenExpiryDate(Number(expires_in)));
    // dispatch(setUserProfileAsync(access_token));
    // }
  }, []);

  return (
    <>
      <h5 className="card-title">Welcome {accounts[0].name}</h5>
      {dogData ?
        <div> Succeed!!! Name: <h5 className="card-title">{dogData}</h5></div>
        :
        <Button variant="secondary" onClick={RequestProfileData}>Request Profile Information</Button>
      }
    </>
  );
}