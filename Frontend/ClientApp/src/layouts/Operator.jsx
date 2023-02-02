import React, { useEffect, useContext } from "react"
import { useSelector, useDispatch } from "react-redux"
import Header from "@Components/Header"
import Wrapper from "@Components/Wrapper"
import Menu from "@Components/Menu"
import Content from "@Components/Content"
import { H2 } from "@Components/Headings"
import MenuButton from "@Components/MenuButton"
import ProfileNav from "@Widgets/ProfileNav"
import OperatorRoute from "@Routes/OperatorRoute"
import { UserContext, themes } from "@Contexts/User"
import { selectTheme, setTheme, selectIsDebugMode } from "@Reducers/userDataSlice"

export default function Student(props) {
  const data = useSelector(selectTheme);
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

  function switchTheme() {
    dispatch(setTheme(data === themes.dark ? themes.default : themes.dark));
  }

  function buildMenu() {
    return [
      { icon: "icon-fi-rr-id-badge", page: "/news", caption: "Новости" },
      {
        icon: "icon-fi-rr-graduation-cap",
        page: "/disciplines",
        caption: "Дисциплины",
      },
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

  const menuItems = buildMenu();

  return (
    <>
      <Header
        left={title}
        right={profileNav} />
      <Wrapper
        theme={data}
        flex="row">
        <Menu items={menuItems} />
        <Content>
          <OperatorRoute />
        </Content>
      </Wrapper>
    </>
  );
}
