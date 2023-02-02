import React from 'react';
import "./scss/style.scss";
import { TimetableAddCallsHeader as TBHeader} from "@Widgets/TimetableAddCallsHeader";

/**
 * Компонент отрисовки страницы изменений распсиания (3 шаг)
 */
export default function TimetableAddEditings () {
    return(
        <div className='timetable-add-editings'>

          {/* Компонент. Отрисовка шапки страницы третьего шага*/}
          <TBHeader indexPage={2}/>
          
        </div> 
    );
}