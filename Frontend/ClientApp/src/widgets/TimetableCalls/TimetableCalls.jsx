import React, { useState } from "react";
import { useEffect } from "react";
import "./scss/TimetableCalls.scss";

export const DISPLAY_MODE = {
  DEFAULT: 0,
  FIVE_MINUTES: 1
};

/**
 * AAA
*/
export function TimetableCalls(props) {

  const enableRecess = props.enableRecess;
  const enableNoLessons = props.enableNoLessons;
  const enableDelete = props.enableDelete;
  const handleRemove = props.handleRemove;
  const data = props.data;

  const [displayMode, setDisplayMode] = useState(DISPLAY_MODE.DEFAULT)

  return (

    <div className="card-container">
      <div className="card-header">
        <span>Общее расписание звонков</span>
      </div>
      <div className="card-body">
        <div className="card-body__flex-container">
          {
            data.lessons.map((item, index) =>
              <div className="card-body__field">
                <span>{(index + 1) + ' пара:'}</span>
                <input type="text" />
                <input type="text" />
              </div>
            )}
        </div>
      </div>
    </div>
  );
};
