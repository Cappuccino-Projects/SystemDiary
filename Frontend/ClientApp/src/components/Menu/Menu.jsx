import React from 'react'
import { NavLink } from "react-router-dom"
import { v4 as uuidv4 } from 'uuid';
import './scss/Menu.scss'

export default class Menu extends React.Component {
    render() {

        const items = this.props.items;

        return (
            <div className="menu">
                <ul className='menu-content'>
                    {
                        items.map(item => (
                            <li key={uuidv4()} className='menu-content__item'>
                                <NavLink className={isActive => (isActive ? "item-active" : "")} to={item.page}>
                                    <span className={item.icon}></span>
                                    <span className='menu-content__item__caption'>
                                        {item.caption}
                                    </span>
                                </NavLink>
                            </li>
                        ))
                    }
                    <li className='menu-content__item'>
                        <NavLink to={{pathname: "https://disk.yandex.ru/i/Olt0bDxgzSCe7Q"}} target="_blank">
                            <span className={"icon-fi-rr-info"}></span>
                            <span className='menu-content__item__caption'>
                                Справка
                            </span>
                        </NavLink>
                    </li>
                </ul>
            </div>
        )
    }
}