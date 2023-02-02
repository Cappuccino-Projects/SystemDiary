import React, { useEffect, useContext } from "react"
import { useSelector, useDispatch } from "react-redux"
import Header from "@Components/Header"
import Wrapper from "@Components/Wrapper"
import Menu from "@Components/Menu"
import Content from "@Components/Content"
import { H2 } from "@Components/Headings"
import MenuButton from "@Components/MenuButton"
import ProfileNav from "@Widgets/ProfileNav"
import AdministratorRoutiing from "@Routes/AdministratorRouting"
import { UserContext, themes } from "@Contexts/User"
import { selectTheme, setTheme, switchDebugMode, selectIsDebugMode } from "@Reducers/userDataSlice"

export default function Administrator(props) {
  const data = useSelector(selectTheme);
  const debugMode = useSelector(selectIsDebugMode);
  const dispatch = useDispatch();

  const { name, surname, role } = useContext(UserContext);

  useEffect(() => {
    const theme = localStorage.getItem("theme");

    if (data === null || data === undefined || data === "")
      dispatch(setTheme(theme));
  });

  useEffect(() => {
    localStorage.setItem("theme", data);
  }, [data]);
  
  useEffect(() => {
   localStorage.setItem("debug_mode", debugMode);
  }, [debugMode]);

  function switchTheme() {
    dispatch(setTheme(data === themes.dark ? themes.default : themes.dark));
  }

  function switchDebugModeEvent() {
    dispatch(switchDebugMode());
  }

  function buildMenu() {
    return [
      { icon: "icon-fi-rr-home", page: "/main", caption: "Главная" },
      { icon: "icon-fi-rr-id-badge", page: "/news", caption: "Новости" },
      {
        icon: "icon-fi-rr-graduation-cap",
        page: "/disciplines",
        caption: "Дисциплины",
      },
      { icon: "icon-fi-rr-users", page: "/users", caption: "Пользователи" },
      {
        icon: "icon-fi-rr-calendar",
        page: "/timetable",
        caption: "Расписание",
      },
    ];
  }

  const profileNav = 
  <ProfileNav 
  name={name}
  surname={surname}
  role={role} />;

  const title = (
    <>
      <div className="menu_button">
        <MenuButton />
      </div>
      <H2 className="title" onClick={() => switchTheme()}>
        SystemDiary
      </H2>
    </>
  );

  const center = (
    <button className="debug-mode" onClick={() => switchDebugModeEvent()}>
      <i className="icon-fi-rr-bug"></i>
    </button>
  );

  const menuItems = buildMenu();

  return (
    <>
      <Header 
        left={ title } 
        center={ center } 
        right={ profileNav } />
      <Wrapper 
        theme={data} 
        flex="row">
        <Menu items={menuItems} />
        <Content>
          <AdministratorRoutiing />
        </Content>
      </Wrapper>
    </>
  );
}
