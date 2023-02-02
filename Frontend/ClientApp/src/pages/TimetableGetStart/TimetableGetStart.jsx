import React from 'react';
import "./scss/style.scss";
import { H1 } from '@Components/Headings'
import { useHistory } from "react-router-dom";

/**
 * Компонент отрисовки страницы если отсутствует расписание
 */
const TimetableGetStart = () => {

    // Данный хук предоставляет доступ к экземпляру истории, который может использоваться для навигации
    const history = useHistory();
    return(

        // Вывод блока с текстом с информацие о том, что распсиание отсутсвует 
        <div className='get-start'>
          <H1>Расписания ещё нет</H1>

          <div className='get-start__message'>
            <span>Ни у одной из групп еще нет общего расписания, необходимо его добавить</span>
          </div>

          {/* Кнопка перенаправления на страницу "1 шаг добавления расписания", добавление звонков */}
          <div className='get-start__redirect-button'>
            <button onClick={() => history.push("/timetable-add-calls")}>Перейти к добавлению</button>
          </div>  

        </div> 
    );
}

// Экспорт компонента Timetable по умолчанию
export default TimetableGetStart;