import { H3 } from '@Components/Headings';
import { useApi } from '@Hooks/useApi';
import React from 'react';
import { useCallback } from 'react';
import { useEffect } from 'react';
import { useState } from 'react';
import { useHistory } from "react-router-dom";
import './scss/Users.scss'

export function Users(props) {
    // Данный хук предоставляет доступ к экземпляру истории, который может использоваться для навигации
    const history = useHistory();
    const [isLoaded, setIsLoaded] = useState(false)
    const [message, setMessage] = useState();
    const [userList, setUserList] = useState([]);
    const { makeRequest, error } = useApi();

    const fetchUserData = useCallback(async () => {

        const params = {
            url: 'api/auth/user/get/list',
            method: 'POST',
            body: null
        }

        const request = await makeRequest(params);

        setUserList(request);

    }, []);

    useEffect(async () => {
        setTimeout(() => {
            setIsLoaded(true);
            fetchUserData();
        }, 3000);
    }, []);

    useEffect(() => {
        setMessage(userList.length === 0 ? 'Список пользователей пустой' : 'Список пользователей');
    }, [userList])

    return (
        <div>
            <button onClick={() => history.push('/users-add')} >Добавить пользователя </button>
            <H3>{isLoaded ? message : 'Загрузка данных...'}</H3>
            <ul className='user-list'>
                {userList.map((data, index) => (
                    <li className='user-list__item'>
                        <div className='user-list__item__card'>
                            <div className='user-list__item__card__personal-queue-id'>
                                <span>#{index + 1}</span>
                            </div>
                            <div className='user-list__item__card__personal-data'>
                                <span>{data.name} {data.surname} {data.fathername}</span>
                            </div>
                            <div className='user-list__item__card__personal-role'>
                                {data.role}
                            </div>
                        </div>
                    </li>
                ))}
            </ul>
        </div>
    );
}