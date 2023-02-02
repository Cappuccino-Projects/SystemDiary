// импорт react
import React from 'react'
// импорт react-router-dom
import { Switch, Route, Redirect } from "react-router-dom"
// импорт страницы Main
import Main from '@Pages/Main'
// импорт страницы Timetable
import Timetable from '@Pages/Timetable'
// импорт страницы News
import News from '@Pages/News'
// импорт страницы Disciplines
import {DisciplinesStudent} from '@Pages/Disciplines'

/**
 * Компонент авторизованного роутинга
*/
export default function StudentRoute(ptops) {
    // функция рендера компонента
    return (
        // переключатель роутов
        <Switch>
            {/* рендер страницы Main по адресу /main */}
            <Route path='/main'>
                <Main />
            </Route>
            {/* рендер страницы News по адресу /news */}
            <Route path='/news'>
                <News />
            </Route>
            {/* рендер страницы Disciplines по адресу /disciplines */}
            <Route path='/disciplines'>
                <DisciplinesStudent />
            </Route>
            {/* рендер страницы Timetable по адресу /timetable */}
            <Route path='/timetable'>
                <Timetable />
            </Route>
            {/* рендер страницы поумолчанию*/}
            <Route path='*'>
                <Redirect to='/main' />
            </Route>
        </Switch>
    )
}