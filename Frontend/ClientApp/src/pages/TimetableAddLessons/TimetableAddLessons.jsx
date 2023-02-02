import React, { useState, useEffect } from 'react';
import "./scss/style.scss";
import { TimetableAddCallsHeader as TBHeader } from "@Widgets/TimetableAddCallsHeader";
import { AddLessonsCourse } from "@Widgets/TimetableAddLessons";
import { AddLessonsSpeciality } from "@Widgets/TimetableAddLessons";
import { AddLessonsGroup } from "@Widgets/TimetableAddLessons";
import { Tab, Tabs } from '@Components/Tabs'

/**
 * Компонент отрисовки страницы добавления уроков (2 шаг)
 */
export default function TimetableAddLessons() {

  const [curse, setCurse] = useState();
  const [speciality, setSpeciality] = useState();

  // используй константы
  const SpecialityHtml =
    <div className="add-timetable__navigation__faculty">
      <div className="navigation__faculty__choose">
        <div className='add-timetable-specific' onClick={() => setSpeciality("40.02.01")}>
          <AddLessonsSpeciality codeSpeciality="Специальность 40.02.01" speciality="Право и организация социального обеспечения" />
        </div>
        <div className='add-timetable-specific'>
          <AddLessonsSpeciality codeSpeciality="Специальность 09.02.07" speciality="Информационные системы и программирование" />
        </div>
        <div className='add-timetable-specific'>
          <AddLessonsSpeciality codeSpeciality="Специальность 10.02.05" speciality="Обеспечение информационной безопасности автоматизированных систем" />
        </div>
        <div className='add-timetable-specific'>
          <AddLessonsSpeciality codeSpeciality="Специальность 34.02.01" speciality="Сестринское дело" />
        </div>
        <div className='add-timetable-specific'>
          <AddLessonsSpeciality codeSpeciality="Специальность 14.02.02" speciality="Радиационная безопасность" />
        </div>
        <div className='add-timetable-specific'>
          <AddLessonsSpeciality codeSpeciality="Специальность 14.02.01" speciality="Атомные электрические станции и установки" />
        </div>
        <div className='add-timetable-specific'>
          <AddLessonsSpeciality codeSpeciality="Специальность 18.02.12" speciality="Технология аналитического контроля химических соединений" />
        </div>
      </div>
    </div>;

  return (
    <div className='timetable-add-lessons'>

      {/* Компонент. Отрисовка шапки страницы второго шага*/}
      <TBHeader indexPage={1} />

      <div className='add-timetable__navigation'>
        <Tabs className="">
          <Tab title={
            <span>
              1 курс
              <i className='icon-fi-rr-check'></i>
            </span>
          }>
            <Tabs>
              <Tab title={
                <div className='tab-item__specialy'>
                  <strong>Специальность 09.02.7</strong>
                  <p>право и организация социального</p>
                </div>
              } />
              <Tab title={
                <div className='tab-item__specialy'>
                  <strong>Специальность 09.02.07</strong>
                  <p>Информационные системы и программирование</p>
                </div>
              }>
                <Tabs>
                  <Tab title="131 группа"></Tab>
                  <Tab title="231 группа"></Tab>
                </Tabs>
              </Tab>
              <Tab title={
                <div className='tab-item__specialy'>
                  <strong>Специальность 10.02.05</strong>
                  <p>Обеспечение информационной безопасности автоматизированных систем</p>
                </div>
              } />
            </Tabs>
          </Tab>
          <Tab title="2 курс">
            <p>2 курс</p>
          </Tab>
          <Tab title="3 курс">
            <p>3 курс</p>
          </Tab>
        </Tabs>

        <div className="tabContent" hidden={curse !== 0}>
          {SpecialityHtml}
          1
        </div>
        <div className="tabContent" hidden={curse !== 1}>
          {SpecialityHtml}
          2
        </div>
        <div className="tabContent" hidden={curse !== 2}>
          {SpecialityHtml}
          3
        </div>
        <div className="tabContent" hidden={curse !== 3}>
          {SpecialityHtml}
          4
        </div>
      </div>

    </div>
  );
}