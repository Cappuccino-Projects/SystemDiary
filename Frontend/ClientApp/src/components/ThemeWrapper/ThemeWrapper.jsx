import React, { useEffect } from "react";
import { themes } from "@Contexts/User";
import "./scss/ThemeWrapper.scss";
import { useSelector, useDispatch } from "react-redux";
import { selectTheme, setTheme, selectIsDebugMode, switchDebugMode } from "@Reducers/userDataSlice";

export default function ThemeWrapper(props) {

  const data = useSelector(selectTheme);
  const isDebug = useSelector(selectIsDebugMode);
  const dispatch = useDispatch();

  useEffect(() => {

    const themeIsExist = localStorage.getItem('theme') !== null 
    && localStorage.getItem('theme') !== undefined 
    && localStorage.getItem('theme') !== '';

    localStorage.setItem('theme', themeIsExist ? localStorage.getItem('theme') : themes.default)

    dispatch(setTheme(localStorage.getItem('theme')))
  }, []);

  return (
    <div className={data + " theme-wrapper" + (!isDebug ? '' : ' debug-mode-enabled')}>
      {props.children}
    </div>
  );
}
