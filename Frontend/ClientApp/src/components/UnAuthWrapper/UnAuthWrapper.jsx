import { UserContext } from '@Contexts/User'
import { useEffect } from "react"
import { useContext } from 'react'
import { useState } from "react";

export default function UnAuthWrapper(props) {

    const children = props.children;
    const { isAuth } = useContext(UserContext);

    return (
      ((JSON.parse(localStorage.getItem("userData")) === null 
      || JSON.parse(localStorage.getItem("userData")) === undefined || !isAuth) ? children : null)
    )
}