// импорт react
import React from "react";
// импорт react-router-dom
import { Switch, Route, Redirect } from "react-router-dom";
// импорт страницы Main
import Main from "@Pages/Main";
// импорт страницы Timetable
import Timetable from "@Pages/Timetable";
// импорт страницы News
import News from "@Pages/News";
// импорт страницы Disciplines
import { DisciplinesOperator } from "@Pages/Disciplines";
// импорт страницы DisciplinesAdd
import { DisciplinesAdd } from "@Pages/Disciplines";
// импорт страницы DisciplinesEdit
import { DisciplinesEdit } from "@Pages/Disciplines";
// импорт страницы Timetable GetStart
import TimetableGetStart from "@Pages/TimetableGetStart";
// импорт страницы TimetableAddCalls
import TimetableAddCalls from "@Pages/TimetableAddCalls";
// импорт страницы TimetableAddLessons
import TimetableAddLessons from "@Pages/TimetableAddLessons";
// импорт страницы TimetableAddEditing
import TimetableAddEditings from "@Pages/TimetableAddEditings";
// импорт страницы TimetableGeneralMenu
import TimetableGeneralMenu from "@Pages/TimetableGeneralMenu";

export default function OperatorRoute(props) {
  return (
    // переключатель роутов
    <Switch>
      {/* рендер страницы Main по адресу /main */}
      <Route path="/main">
        <Main />
      </Route>
      {/* рендер страницы News по адресу /news */}
      <Route path="/news">
        <News />
      </Route>
      {/* рендер страницы Disciplines по адресу /disciplines */}
      <Route path="/disciplines">
        <DisciplinesOperator />
      </Route>
      {/* рендер страницы DisciplinesAdd по адресу /disciplines */}
      <Route path="/disciplines-add">
        <DisciplinesAdd />
      </Route>
      {/* рендер страницы DisciplinesEdit по адресу /disciplines */}
      <Route path="/disciplines-edit">
        <DisciplinesEdit />
      </Route>
      {/* рендер страницы Timetable по адресу /timetable */}
      <Route path="/timetable"> 
        <Timetable />
      </Route>
      {/* рендер страницы TimetableGetStart по адресу /timetable-get-start */}
      <Route path="/timetable-get-start">
        <TimetableGetStart />
      </Route>
      {/* рендер станциы TimetableAddCalls по адресу /timetable-add-calls */}
      <Route path="/timetable-add-calls">
        <TimetableAddCalls />
      </Route>
      {/* рендер страницы TimetableAddLessons по адресу /timetable-add-lessons */}
      <Route path="/timetable-add-lessons">
        <TimetableAddLessons />
      </Route>
      {/* рендер страницы TimetableAddEditings по адресу /timetable-add-editings */}
      <Route path="/timetable-add-editings">
        <TimetableAddEditings />
      </Route>
      {/* рендер страницы TimetableGeberalMenu по адресу /timetable-general-menu */}
      <Route path="/timetable-general-menu">
        <TimetableGeneralMenu />
      </Route>
      {/* рендер страницы поумолчанию*/}
      <Route path="*">
        <Redirect to="/main" />
      </Route>
    </Switch>
  );
}
