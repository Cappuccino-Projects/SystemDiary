import React from 'react'
import { useHistory } from "react-router-dom";

export function DisciplinesOperator(props) {
    // Данный хук предоставляет доступ к экземпляру истории, который может использоваться для навигации
    const history = useHistory();

    return(
        <>
            <h1 className='title-h1'>Дисциплины для операторов</h1>
            <button onClick={() => history.push('/disciplines-add')}>Добавить дисциплины</button>
            <button onClick={() => history.push('/disciplines-edit')}>Изменить дисциплины</button>
        </>
    )
}