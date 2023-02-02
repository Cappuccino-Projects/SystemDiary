import React, { useState, useContext } from "react";
import "./scss/ProfileCard.scss"
import { UserContext, userContext } from '@Contexts/User'

export function ProfileCard({isActive, setIsActive}) {

    const { name, surname, role, phone, email, birth } = useContext(UserContext)

    const logout = () => {
        localStorage.clear(); 
        window.location.reload();
        
    }

    return(
        <div className={isActive ? "modal active" : "modal"} onClick={() => setIsActive(false)}>
            <div className={isActive ? "modal__content active" : "modal__content"} onClick={e => e.stopPropagation()}>
                
                <div className="profileCard-container">
                    <div className="profileCard-image">
                        <div className="profileavatar-image"/>
                        <p className="profileCard-user">{name} {surname}</p>
                        <p className="profileCard-user profileCard-user__role">{role}</p>
                    </div>
                    <div className="profileCard-info">
                        <div className="profileCard-info__status">
                            <span>Я люблю у</span>
                        </div>
                        <div className="profileCard-indo__paddings">
                            <p>Мобильный телефон:</p>
                            <p>{phone}</p>
                        </div>
                        <div className="profileCard-indo__paddings">
                            <p>Электронная почта:</p>
                            <p>{email}</p>
                        </div>
                        <div className="profileCard-indo__paddings">
                            <p>Год рождения:</p>
                            <p>{birth}</p>
                        </div>
                        <div className="profileCard-button">
                            <p>Редактировать профиль</p>
                            <p onClick={() => logout()}>Вскрыться</p>
                        </div>
                    </div>
                </div> 
            </div>
        </div>
    );
}