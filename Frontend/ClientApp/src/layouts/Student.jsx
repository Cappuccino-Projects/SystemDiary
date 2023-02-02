// Импорт react
import React, { useEffect, useContext } from "react"
// Импорт redux
import { useSelector, useDispatch } from "react-redux"
// Импорт компонента Header
import Header from "@Components/Header"
// Импорт компонента Wrapper
import Wrapper from "@Components/Wrapper"
// Импорт компонента Menu
import Menu from "@Components/Menu"
// Импорт компонента Content
import Content from "@Components/Content"
// Импорт компонента Heading
import { H2 } from "@Components/Headings"
// Импорт компонента MenuButton
import MenuButton from "@Components/MenuButton"
// Импорт компонента ProfileNav
import ProfileNav from "@Widgets/ProfileNav"
// Импорт роута студента
import StudentRoute from "@Routes/StudentRoute"
// Импорт контекста польтзователя
import { UserContext, themes } from "@Contexts/User"
// Импорт редюсера пользовательских данных
import { selectTheme, setTheme } from "@Reducers/userDataSlice"

// экспорт компонента Student
export default function Student(props) {
  const data = useSelector(selectTheme);
  const dispatch = useDispatch();

  // использование контекста
  const { name, surname, role } = useContext(UserContext);

  // использование хука useEffect
  useEffect(() => {
    const theme = localStorage.getItem("theme");

    if (data === null || data === undefined || data === "")
      dispatch(setTheme(theme));
  });

  // использование хука useEffect для отслеживания data
  useEffect(() => {
    localStorage.setItem("theme", data);
  }, [data]);

  // переключение темы
  function switchTheme() {
    dispatch(setTheme(data === themes.dark ? themes.default : themes.dark));
  }

  // функция построения меню
  function buildMenu() {
    return [
      { icon: "icon-fi-rr-home", page: "/main", caption: "Главная" },
      { icon: "icon-fi-rr-id-badge", page: "/news", caption: "Новости" },
      {
        icon: "icon-fi-rr-graduation-cap",
        page: "/disciplines",
        caption: "Дисциплины",
      },
      { icon: "icon-fi-rr-book-bookmark", page: "/journal", caption: "Журнал" },
      {
        icon: "icon-fi-rr-calendar",
        page: "/timetable",
        caption: "Расписание",
      },
      { icon: "icon-fi-rr-book-alt", page: "/materials", caption: "Материалы" },
      { icon: "icon-fi-rr-envelope", page: "/chats", caption: "Чаты" },
      { icon: "icon-fi-rr-info", page: "/manual", caption: "Справка" }
    ];
  }

  // инициализация ProfileNav компонента
  const profileNav =
    <ProfileNav
      name={name}
      surname={surname}
      role={role} />;

  // инициализация заголовка
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

  // построение меню
  const menuItems = buildMenu();

  // Возврат компонента
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
          <StudentRoute />
        </Content>
      </Wrapper>
    </>
  );
}
