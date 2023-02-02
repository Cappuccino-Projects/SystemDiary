import React from 'react'
import { H2 } from '@Components/Headings'
import './scss/Calendar.scss'

/**
 *  Этот класс отвечает за управление календарём
 */
export class CalendarControls extends React.Component {

  getWeekName(day) {
    return (
      [
          "Воскресенье",
          "Понедельник",
          "Вторник",
          "Среда",
          "Четверг",
          "Пятница",
          "Суббота"
      ][day] || null
  );
  }

  getMonthName(month) {
    return (
      [
        "Января",
        "Февраля",
        "Марта",
        "Апреля",
        "Мая",
        "Июня",
        "Июля",
        "Августа",
        "Сентября",
        "Октября",
        "Ноября",
        "Декабря"
      ][month] || null
    );
  }

  render() {

    const month = this.props.currentDate.getMonth();
    const monthName = this.getMonthName(month);
    const day = this.props.currentDate.getDate();
    const weekDay = this.props.currentDate.getDay();
    const weekName = this.getWeekName(weekDay);

    return (
      <div className='calendar-controls'>
        <div className='calendar-controls__date'>
          <H2 className='page-title'>{ weekName }, { day } { monthName }</H2>
        </div>
        <div className='calendar-controls__controls'>
          <span className='icon-arrow-left'></span>
          <span className='icon-arrow-right'></span>
        </div>
      </div>
    )
  }
}

/**
 *  Этот класс отвечает за шапку календаря
 */
export class CalendarHead extends React.Component {
  render() {
    return (
      <div className='calendar-head'>
        <div className='calendar-head-item'>
          <span className="calendar-head-item__display-mode-laptop">
          Понедельник
          </span>
          <span className="calendar-head-item__diplsay-mode-mobile">
          Пн
          </span>
        </div>
        <div className='calendar-head-item'>
          <span className="calendar-head-item__display-mode-laptop">
          Вторник
          </span>
          <span className="calendar-head-item__diplsay-mode-mobile">
          Вт
          </span>
        </div>
        <div className='calendar-head-item'>
          <span className="calendar-head-item__display-mode-laptop">
          Среда
          </span>
          <span className="calendar-head-item__diplsay-mode-mobile">
          Ср
          </span>
        </div>
        <div className='calendar-head-item'>
          <span className="calendar-head-item__display-mode-laptop">
          Четверг
          </span>
          <span className="calendar-head-item__diplsay-mode-mobile">
          Чт
          </span>
        </div>
        <div className='calendar-head-item'>
          <span className="calendar-head-item__display-mode-laptop">
          Пятница
          </span>
          <span className="calendar-head-item__diplsay-mode-mobile">
          Пт
          </span>
        </div>
        <div className='calendar-head-item'>
          <span className="calendar-head-item__display-mode-laptop">
          Суббота
          </span>
          <span className="calendar-head-item__diplsay-mode-mobile">
          Сб
          </span>
        </div>
        <div className='calendar-head-item'>
          <span className="calendar-head-item__display-mode-laptop">
          Воскресенье
          </span>
          <span className="calendar-head-item__diplsay-mode-mobile">
          Вс
          </span>
        </div>
      </div>
    )
  }
}

/**
 *  Этот класс отвечает за неделю календаря
 */
export class CalendarWeek extends React.Component {
  render() {

    const days = this.props.days;

    let i = 0;
    return (
      <div className='calendar-body__week'>
        {
          days.map(day => <CalendarDay key={ i++ } day={day.day} note={day.note} />)
        }
      </div>
    )
  }
}

/**
 *  Этот класс отвечает за день в календаре
 */
export class CalendarDay extends React.Component {
  render() {
    return (
      <div className={'calendar-body__day ' + this.props.type}>
        <div className='calendar-body__container'>
          <div className='calendar-body__day__date'>
            {this.props.day}
          </div>
          <div className='calendar-body__day__notes'>
            {this.props.note}
          </div>
        </div>

      </div>
    )
  }
}

/**
 *  Этот класс отвечает за тело календаря содержащий ячейки
 */
export class CalendarBody extends React.Component {

  initializeDay(day, note) {
    return { day: day, note: note }
  }

  daysInMonth = function () {
    let date = new Date();
    return new Date(date.getFullYear(), date.getMonth() + 1, 0).getDate();
  };

  getDayOfMonthBegin = function () {
    let date = new Date();
    return new Date(date.getFullYear(), date.getMonth(), 1).getDay();
  };

  render() {

    let weeks = new Array(6);
    let daysData;
    let increment = 0;
    let day;
    let daysInMonth = this.daysInMonth();

    for (var i = 0; i < 6; i++) {
      daysData = new Array(7);

      for (var j = 0; j < 7; j++) {
        if ((i === 0 && j < this.getDayOfMonthBegin() - 1) || increment > daysInMonth) {
          day = '';
        } else {
          increment++;
          day = (increment <= daysInMonth) ? increment.toString() : '';
        }

        daysData[j] = this.initializeDay(day, (i === 1 && j === 4) ? '2 задания' : '');
      }

      weeks.push(<CalendarWeek key={ i } days={daysData} />);
    }

    return (
      <div className='calendar-body'>
        {weeks}
      </div>
    )
  }
}

/**
 *  Этот класс отвечает за готовую сборку календаря
 */
export default class Calendar extends React.Component {

  constructor(props) {
    super(props);

    this.state = {
      currentDate: new Date(),
      displayDate: new Date()
    }
  }

  render() {
    return (
      <div className='calendar'>
        <CalendarControls currentDate={this.state.displayDate} />
        <CalendarHead />
        <CalendarBody />
      </div>
    )
  }
}