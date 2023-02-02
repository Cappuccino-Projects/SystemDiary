import React, { useState }from 'react'
import './scss/ProfileNav.scss'
import avatarka from './../../images/avatar_default_yellow.png'
import { ProfileCard } from '@Widgets/ProfileCard'

export default function ProfileNav(props) {
    
    const [profileActive, setProfileActive] = useState();

    return (
        <>
        <div className='profile-nav'>
            <div className='profile-nav__data'>
                <div className='profile-nav__names'>
                    <p className='profile-nav__names__title' onClick={() => setProfileActive(true)}>{props.name} {props.surname}</p>
                </div>
                <div className='profile-nav__status'>
                    <p className='profile-nav__status__title'>{props.role}</p>
                </div>
            </div>
            <div className='profile-nav__avatar'>
                <img src={avatarka} alt='avatarka' />
            </div>
        </div>

        <ProfileCard isActive={profileActive} setIsActive={setProfileActive}/>
        </>
    )
}

