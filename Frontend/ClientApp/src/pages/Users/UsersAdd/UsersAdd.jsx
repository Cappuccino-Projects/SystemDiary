import { useApi } from '@Hooks/useApi';
import React, { useState } from 'react';
import { useEffect } from 'react';
import './scss/UsersAdd.scss'

export function UsersAdd() {
    const [inputFields, setInputfields] = useState({ name: "", surname: "", fatherName: "", birthday: "", email: "", gender: 2, login: "", password: "", repassword: "" })
    const [pas, setPas] = useState(inputFields.password);
    const [birthday, setBirthday] = useState('дд.мм.ГГГГ');
    const { makeRequest, error } = useApi();

    const handleChangeInput = (event) => {
        if (event.target.name === "birthday") {
            const temp = event.target.value;
            setBirthday(temp.substring(5, 7) + '.' + temp.substring(8, 10) + '.' + temp.substring(0, 4));
            inputFields[event.target.name] = (temp.substring(5, 7) + '/' + temp.substring(8, 10) + '/' + temp.substring(0, 4));
        } else if (event.target.name === "gender") {
            inputFields[event.target.name] = event.target.selectedIndex;
        } else {
            inputFields[event.target.name] = event.target.value;
        }
        setInputfields(inputFields);
    }

    const handleSubmit = (e) => {
        //e.preventDefault();
        addUser();
        console.log(inputFields);
    }

    useEffect(() => {
        generatePassword();
    }, []);

    const generatePassword = () => {
        let randomPassword =
            Math.random().toString(36).slice(2) + Math.random().toString(36).slice(2);
        randomPassword = randomPassword.slice(12);

        inputFields.password = randomPassword;
        setPas(randomPassword);
    }

    const addUser = async () => {

        const formData = new FormData();
        formData.append('name', inputFields.name);
        formData.append('surname', inputFields.surname);
        formData.append('fatherName', inputFields.fatherName);
        formData.append('login', inputFields.login);
        formData.append('birth', inputFields.birthday);
        formData.append('gender', inputFields.gender);
        formData.append('email', inputFields.email);
        formData.append('passwordOriginal', inputFields.password);
        formData.append('passwordDoublicate', inputFields.repassword);

        const params = {
            url: 'api/auth/admin/registration',
            method: 'POST',
            body: formData
        }

        await makeRequest(params);
    }

    return (
        <>
            <h1 className='title-h1'>Добавление пользователя</h1>

            <div className='useradd-input'>
                <input name="name" type="text" placeholder="Имя" onChange={event => handleChangeInput(event)} />
                <input name="surname" type="text" placeholder="Фамилия" onChange={event => handleChangeInput(event)} />
                <input name="fatherName" type="text" placeholder="Отчество"  onChange={event => handleChangeInput(event)} />
                <input name="birthday" type="date" placeholder="дата" onChange={event => handleChangeInput(event)} />
                <div>
                    <span className='data-input'>{birthday}</span>
                </div>
                <select name='gender' onChange={event => handleChangeInput(event)}>
                    <option>Мужской</option>
                    <option>Женский</option>
                    <option selected>Не указан</option>
                </select>
                <input name="email" type="text" placeholder="E-mail" onChange={event => handleChangeInput(event)} />
                <input name="login" type="text" placeholder="Логин" onChange={event => handleChangeInput(event)} />
                <div className='password' title="Сгенерировать пароль" onClick={generatePassword}><span className='password-icon icon-fi-rr-dice-alt'></span></div>
                <input className='field' disabled name="password" type="text" placeholder={pas} onChange={event => handleChangeInput(event)} />
                <input name="repassword" type="text" placeholder="Подтверждение пароля" onChange={event => handleChangeInput(event)} />
            </div>
            <button className='c-button c-button__send' onClick={handleSubmit}>Создать</button>
        </>
    );
}