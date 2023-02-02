import { useEffect } from "react"
import { UserContext } from "@Contexts/User"
import { useContext } from "react";
import { useState } from "react";

export default function AuthWrapper(props) {

    const children = props.children;
    const { isAuth, role } = useContext(UserContext);

    return (
      ((JSON.parse(localStorage.getItem("userData")) !== null 
      && JSON.parse(localStorage.getItem("userData")) !== undefined && isAuth) ? children : null)
    )
}