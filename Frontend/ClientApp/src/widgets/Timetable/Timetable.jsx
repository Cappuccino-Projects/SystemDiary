import React, { useState } from "react";
import "./scss/Timetable.scss";
import "./data";
import getData from "./data";

const data = getData();

/**
 * Компонент расписания
 */
export function Timetable(props) {
  return (
    <div className="timetable">
      <TimetableHeader indexDay={props.indexDay} />
      <TimetableBody indexDay={props.indexDay} />
    </div>
  );
};

/**
 * Компонент шапки расписания
 */
const TimetableHeader = (props) => {
  let classEdit;

  if (data[props.indexDay].isediting) {
    classEdit = "timetable-header__editing";
  }
  
  return (
    <div className={"timetable-header " + classEdit}>
      <span>{data[props.indexDay].title}</span>
    </div>
  );
};

/**
 * Компонент тела расписания
 */
const TimetableBody = (props) => {
  let completeSubject = new Array(4);
  let completeCalls;
  let renderCompleteString;

  let classEdit;
  if (data[props.indexDay].isediting) {
    classEdit = "timetable-body__editing";
  }

  if (data[props.indexDay].isTimetable === "isSubj") {
    for (let index = 0; index < data[props.indexDay].lessons.length; index++) {
      completeSubject.push(
        <TimetableBodyLesson key={index} index1={index} indexDay={props.indexDay} />
      );
    }
  } else {
    completeCalls = <TimetableBodyCalls indexDay={props.indexDay} />;
  }

  if (data[props.indexDay].isTimetable === "isSubj") {
    renderCompleteString = completeSubject;
  } else {
    renderCompleteString = completeCalls;
  }

  return (
    <div className={"timetable-body " + classEdit}>
      <div className="timetable-body_container">{renderCompleteString}</div>
    </div>
  );
};

/**
 * Компонент записи расписания пары
 */
const TimetableBodyLesson = (props) => {
  return (
    <div className="timetable-body__lesson">

      <div className="timetable-body__lesson-container-calls"> 
        <div className="timetable-body__lesson__calls">
          <span>{data[props.indexDay].lessons[props.index1].calls}</span>
        </div>
      </div>

      <div className="timetable-body__lesson-container-subject"> 
        <div className="timetable-body__lesson__subject">
          <span>{data[props.indexDay].lessons[props.index1].subject}</span>
        </div>
      </div>

      <div className="timetable-body__lesson-container-container">

        <div className="timetable-body__lesson__container">

          <div className="timetable-body__lesson__teacher">
            <span>{data[props.indexDay].lessons[props.index1].teacher}</span>
          </div>

          <div className="timetable-body__lesson__cabinet">
            <span>{data[props.indexDay].lessons[props.index1].cabinet}</span>
          </div>
          
        </div>
      </div>

    </div>
  );
};

/**
 * Компонент записи расписания звонка
 */
const TimetableBodyCalls = (props) => {
  let complete = new Array(7);
  const [day, setDay] = useState(0);
  let el;

  for (let index = 0; index < data[props.indexDay].couple.length; index++) {


    if (day === 0) {
      el = data[props.indexDay].callsMondey[index];
    }
    if (day === 1) {
      el = data[props.indexDay].callsGeneral[index];
    }
    if (day === 2) {
      el = data[props.indexDay].callsSaturday[index];
    }

    complete.push(
      <div className="timetable-body-calls" key={index}>

        <div className="flexcontainer">
          <div className="timetable-body-calls__couple">
            <span>{data[props.indexDay].couple[index]}</span>
          </div>
          <div className="timetable-body-calls__time">
            <span>{el}</span>
          </div>
        </div>
      </div>
    );
  }

  let enableTabs;
  enableTabs = (
    <div className="tablist">
      <div className="tabhead" onClick={() => setDay(0)}>
        Понедельник
      </div>
      <div className="tabhead" onClick={() => setDay(1)}>
        Общее
      </div>
      <div className="tabhead" onClick={() => setDay(2)}>
        Суббота
      </div>
    </div>
  );

  return (
    <div className="Tabs">
      <div className="tabContent" hidden={day !== 0}>
        {complete}
      </div>

      <div className="tabContent" hidden={day !== 1}>
        {complete}
      </div>

      <div className="tabContent" hidden={day !== 2}>
        {complete}
      </div>

      {enableTabs}
    </div>
  );
};

/**
 * Компонент отрисовки дней недели
 */
export function TimetableWeek(props) {
  const [Week, setWeek] = useState(0);
  //Изменение стилей кнопок 1 и 2 недели
  let styleWeekButtonFirst;
  let styleWeekButtonSecond;
  if (Week === 0) {
    styleWeekButtonFirst = "tabWeekCheked";
  } else {
    styleWeekButtonSecond = "tabWeekCheked";
  }

  //Нажатие на кнопки 1 и 2 недели
  let enableTabs;
  enableTabs = (
    <div className="tablistWeek">
      <div className={"tabheadWeek " + styleWeekButtonFirst} onClick={() => setWeek(0)}>
        1 неделя
      </div>
      <div className={"tabheadWeek " + styleWeekButtonSecond} onClick={() => setWeek(1)}>
        2 неделя
      </div>
    </div>
  )
  
  let drawWeek;
  let completeWeekFirst =
    props.dataArrayFirst.map((item) =>
      <div className="timetable">
        <TimetableHeaderWeek key={item} indexWeek={item} />
        <TimetableWeekDays key={item + "WW"} indexWeek={item} week={Week} />
      </div>
    );
  let completeWeekSecond = 
    props.dataArraySecond.map((item) =>
      <div className="timetable">
        <TimetableHeaderWeek key={item} indexWeek={item} />
        <TimetableWeekDays key={item + "WW"} indexWeek={item} week={Week} />
      </div>
    );
  
  if(Week === 0){
    drawWeek = completeWeekFirst;
  } else {
    drawWeek = completeWeekSecond;
  }

  return (
    <div className="wrap">
      {enableTabs}
      <div className="block">
        {drawWeek}
      </div>
    </div>
  );
}

const TimetableHeaderWeek = (props) => {
  return (
    <div className="timetable-header">
      <span>{data[props.indexWeek].title}</span>
    </div>
  );
};

const TimetableWeekDays = (props) => {

  let completeSubject = new Array(4);
  let styleSelfTraningDay;
  //Шаблон который будет дублироваться
  for (let index = 0; index < (data[props.indexWeek].lessons.length); index++) {
    completeSubject.push(
      <TimetableBodyLessonWeek key={index} index1={index} indexWeek={props.indexWeek} />
      );

     
    if(data[props.indexWeek].lessons[index].subject
      === 'День самостоятельной подготовки студентов'){
        styleSelfTraningDay = 'styleSelfTraningDay';
    };
  }
  
  return (
    <div>

      <div className="tabWeeks">

        <div className="firstWeek" hidden={props.week !== 0}>
          <div className="timetable-body-week">
            <div className={"timetable-body_container " + styleSelfTraningDay}>{completeSubject}</div>
          </div>
        </div>

        <div className="secondWeek" hidden={props.week !== 1}>
          <div className="timetable-body-week">
            <div className={"timetable-body_container " + styleSelfTraningDay}>{completeSubject}</div>
          </div>
        </div>

      </div>

    </div>
  );
}

const TimetableBodyLessonWeek = (props) => {

  return (
    <div className="timetable-body__lesson">

      <div className="timetable-body__lesson-container-calls"> 
        <div className="timetable-body__lesson__calls">
          <span>{data[props.indexWeek].lessons[props.index1].calls}</span>
        </div>
      </div>

      <div className="timetable-body__lesson-container-subject"> 
        <div className="timetable-body__lesson__subject">
          <span>{data[props.indexWeek].lessons[props.index1].subject}</span>
        </div>
      </div>

      <div className="timetable-body__lesson-container-container"> 
        <div className="timetable-body__lesson__container">
          <div className="timetable-body__lesson__teacher">
            <span>{data[props.indexWeek].lessons[props.index1].teacher}</span>
          </div>
          <div className="timetable-body__lesson__cabinet">
            <span>{data[props.indexWeek].lessons[props.index1].cabinet}</span>
          </div>
        </div>
      </div>

    </div>
  );
};