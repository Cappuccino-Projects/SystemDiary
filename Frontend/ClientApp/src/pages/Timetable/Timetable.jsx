import React from 'react';
import { Timetable as Tb, TimetableWeek } from '@Widgets/Timetable';
import { useHistory } from "react-router-dom";
import "./scss/main1.scss";

/**
 * Компонент создания страницы расписания
 */
const Timetable = () => {

    // Данный хук предоставляет доступ к экземпляру истории, который может использоваться для навигации
    const history = useHistory();
    return(
        <div>
            {/* Кнопка перенапрвления на страницу добавления расписания */}
            <button onClick={() => history.push('/timetable-get-start')}>Добавление расписания</button>

            {/* Кнопка перенапрвления на страницу добавления расписания */}
            <button onClick={() => history.push('/timetable-general-menu')}>Главное меню расписания</button>

            {/* Отрисовка компонентов расписания и звонков*/}
            <div className='today-yesterday-calls'>
                {/* Отрисовка компонента "Расписание на сегодня" */}
                <div><Tb indexDay={0}/></div>

                {/* Отрисовка компонента "Расписание на завтра / Изменения на завтра" */}
                <div><Tb indexDay={1}/></div>

                {/* Отрисовка компонента "Звонки" */}
                <div><Tb indexDay={2}/></div>

            </div>

            {/* Отрисовка компонента "Расписание на неделю" включает в себя 1 и 2 неделю */}
            <div className="week">
                {/* отправляет в props массив индексов каждого дня 1 и 2 недели */}
                <div><TimetableWeek dataArrayFirst={ [3, 4, 5, 6, 7, 8]} dataArraySecond={ [9, 10, 11, 12, 13, 14]} indexWeek={3}/></div>
            </div>
        </div> 
    );
}

// Экспорт компонента Timetable по умолчанию
export default Timetable;