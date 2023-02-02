import React, { useRef, useContext } from 'react'
import { UserContext } from "@Contexts/User"
import { useApi } from '@Hooks/useApi'
import { useHistory } from 'react-router-dom'

export default function Login() {

  const history = useHistory();
  const { makeRequest, error } = useApi();

  const { setIsAuth, setName, setSurname } = useContext(UserContext);

  const loginField = useRef(null);
  const passwordField = useRef(null);

  const login = async () => {

    var formdata = new FormData();
    formdata.append("login", loginField.current.value);
    formdata.append("password", passwordField.current.value);

    var requestOptions = {
      url: 'api/public/auth/login', 
      method: 'POST',
      body: formdata
    };

    const request = await makeRequest(requestOptions);

    setIsAuth(request !== null && request !== undefined);
    setName(request.user_name);
    setSurname(request.user_surname);

    localStorage.setItem("userData", JSON.stringify(request));

    history.go('/main');

  }

  return (
    <div>
      <input ref={loginField} /><br />
      <input ref={passwordField} /><br />
      <button onClick={() => login()}>Войти</button>
      <strong>{ error }</strong>
    </div>
  )
}