import React, { useState, useRef } from 'react'
import { useHistory } from 'react-router-dom'
import { H1, H4 } from '@Components/Headings'
import { useApi } from '@Hooks/useApi'
import { v4 as uuidv4 } from 'uuid';

export default function Debug() {

  const history = useHistory();

  const { makeRequest, error } = useApi();
  const [res1, setRes1] = useState(null)
  const [res2, setRes2] = useState(null)

  const ref1 = useRef(null);
  const ref2 = useRef(null);

  const [res3, setRes3] = useState();
  const [res4, setRes4] = useState();

  const checkLogin = async () => {

    var formdata = new FormData();
    formdata.append("login", 'login');
    formdata.append("password", '1111');

    var requestOptions = {
      url: 'api/public/auth/login',
      method: 'POST',
      body: formdata
    };

    const t = await makeRequest(requestOptions);

    setRes1(JSON.stringify(t));

  }

  const getDisciplines = async () => {

    var requestOptions = {
      url: 'api/auth/discipline/get/all',
      method: 'POST',
      body: null,
      headers: new Headers({
        'Authorization': 'bearer ' + localStorage.getItem("access_token"), 
        'Content-Type': 'application/x-www-form-urlencoded'
      })
    }

    const t = await makeRequest(requestOptions);

    if (error) {
      refresh();
    }

    setRes2(JSON.stringify(t));
  }

  const addDiscipline = async () => {

    var formdata1 = new FormData();
    formdata1.append("name", ref1.current.value);
    formdata1.append("description", ref2.current.value);

    var requestOptions = {
      url: 'api/auth/discipline/add',
      method: 'POST',
      body: formdata1,
      headers: new Headers({
        'Authorization': 'bearer ' + localStorage.getItem("access_token")
      })
    }

    const t = await makeRequest(requestOptions);

    setRes3(JSON.stringify(t));
  }

  const logout = () => {
    localStorage.removeItem("access_token");
    localStorage.removeItem("refresh_token");
    history.go('/login');
  }

  const refresh = async () => {

    const access_token = localStorage.getItem("access_token");
    const refresh_token = localStorage.getItem("refresh_token");

    var formdata = new FormData();
    formdata.append("accessToken", access_token);
    formdata.append("refreshToken", refresh_token);

    var requestOptions = {
      url: 'api/public/auth/refresh',
      body: formdata,
      method: 'POST',
      headers: new Headers({
        'Authorization': 'bearer ' + localStorage.getItem("access_token")
      })
    }

    const t = await makeRequest(requestOptions);

    console.log(JSON.stringify(t));
    localStorage.setItem("access_token", t.access_token);
    localStorage.setItem("refresh_token", t.refresh_token);

    setRes4(JSON.stringify(t));
  }

  return (
    <>
      <H1>Это страница для проверки API</H1>
      <button onClick={() => checkLogin()}>логин</button><br/>
      <p Style='font-size: 12px;max-width: 70%;word-break: break-all;'>Ответ: { res1 }</p>
      <button onClick={() => getDisciplines()}>получение дисциплин</button>
      <p Style='font-size: 12px;max-width: 70%;word-break: break-all;'>Ответ: { res2 }</p>
      <input ref={ref1}/><br/>
      <input ref={ref2}/><br/>
      <button onClick={() => addDiscipline()}>Добавить дисциплину</button>
      <p Style='font-size: 12px;max-width: 70%;word-break: break-all;'>Ответ: { res3 }</p>
      <button onClick={() => logout()}>Выйти</button>
      <H4>Расписание</H4>
      <Card/>
      <button onClick={() => refresh()}>Обновить токен доступа</button>
      <p Style='font-size: 12px;max-width: 70%;word-break: break-all;'>Ответ: { res4 }</p>
    </>
  )

}

function Card() {

  const [fields, setFields] = useState([{ id: uuidv4(), discipline: '', time: '' }]);

  const setValues = (id, e) => {
    const result = fields.map(item => {
      if (item.id === id)
        item[e.target.name] = e.target.value

      return item;
    });

    setFields(result);

  }

  return(
    <div Style='display: flex; flex-direction: column; width: 150px;'>
      {fields.map((item, index) => (
        <div Style='display: flex; flex-direction: row;'>
          <span Style='font-size: 16px;'>{index}</span>
          <input
            value={item}
          />
          <input/>
        </div>
      ))}
    </div>
  )

}