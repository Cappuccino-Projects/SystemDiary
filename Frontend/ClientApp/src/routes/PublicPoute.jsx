// импорт react
import React from 'react'
// импорт react-router-dom
import { Switch, Route, Redirect } from "react-router-dom"
import Login from '@Pages/Login/Login'

/**
 * Компонент авторизованного роутинга
*/
export default function PublicRoute(ptops) {
    // функция рендера компонента
    return (
        // переключатель роутов
        <Switch>
            {/* рендер страницы Main по адресу /main */}
            <Route path='/login'>
                <Login />
            </Route>
            {/* рендер страницы поумолчанию*/}
            <Route path='*'>
                <Redirect to='/login' />
            </Route>
        </Switch>
    )
}