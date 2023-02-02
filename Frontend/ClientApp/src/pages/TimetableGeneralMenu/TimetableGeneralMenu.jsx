import React from 'react';
import "./scss/TimetableGeneralMenu.scss";

export default function TimetableGeneralMenu () {
    return(
        <>
           <div className="page-timetable">
                <div className="timetable__content">
                    {/* Верхняя flex строка */}
                    {/* Блок.Просмотр общего расписания */}
                    <div className="timetable__view general-menu-block">
                    <div className="timetable__view__title title">
                        <span>Просмотр общего расписания</span>
                    </div>
                    <div className="timetable__view__icon icon" />
                    </div>
                    {/* Блок. Внесение изменений */}
                    <div className="timetable__input-change general-menu-block">
                    <div className="timetable__input__title title">
                        <span>Внесение изменений</span>
                    </div>
                    <div className="timetable__input__icon icon" />
                    </div>
                    {/* Блок. На какие дни будут изменения */}
                    <div className="timetable__change-time-box bigblock">
                    <div className="timetable__change-time-box__title title">
                        <span>Изменения назначены на:</span>
                    </div>
                    <div className="timetable__change-time-box__day day">
                        <span>12.08 Понедельник</span>
                    </div>
                    <div className="timetable__change-time-box__groups groups">
                        <div className="group">134 группа</div>
                        <div className="group">434 группа</div>
                        <div className="group">454 группа</div>
                    </div>
                    <div className="timetable__change-time-box__day day">
                        <span>17.08 Понедельник</span>
                    </div>
                    <div className="timetable__change-time-box__groups groups">
                        <div className="group">134 группа</div>
                        <div className="group">434 группа</div>
                        <div className="group">454 группа</div>
                        <div className="group">134 группа</div>
                        <div className="group">434 группа</div>
                        <div className="group">454 группа</div>
                        <div className="group">134 группа</div>
                        <div className="group">434 группа</div>
                        <div className="group">454 группа</div>
                    </div>
                    <div className="timetable__change-time-box__day day">
                        <span>21.08 Понедельник</span>
                    </div>
                    <div className="timetable__change-time-box__groups groups">
                        <div className="group">134 группа</div>
                        <div className="group">434 группа</div>
                    </div>
                    </div>
                    {/*Нижняя flex строка */}
                    {/* Блок. Вывод расписания в Excel */}
                    <div className="timetable__excel-output general-menu-block">
                    <div className="timetable__excel-output__title title">
                        <span>Вывод общего расписания и звонков в Excel</span>
                    </div>
                    <div className="timetable__excel-output__icon icon" />
                    </div>
                    {/* Блок. Вывод изменений в Excel */}
                    <div className="timetable__excel-change general-menu-block">
                    <div className="timetable__excel-change__title title">
                        <span>Вывод изменений в Excel</span>
                    </div>
                    <div className="timetable__excel-change__icon icon" />
                    </div>
                    {/* Блок. Редактирование */}
                    <div className="timetable__edit-block">
                    {/* Подблок. Редактирование расписания */}
                    <div className="timetable__edit-window middleblock">
                        <div className="timetable__edit-window__title title">
                        <span>Редактирование общего расписания</span>
                        </div>
                        <div className="timetable__edit-window__icon icon" />
                    </div>
                    {/* Подблок. Редактирование звонков */}
                    <div className="timetable__bell-window middleblock">
                        <div className="timetable__bell-window__title title">
                        <span>Редактирование расписания звонков</span>
                        </div>
                        <div className="timetable__bell-window__icon icon" />
                    </div>
                    </div>
                </div>
                <div className="background" />
            </div>
        </>
    );
}