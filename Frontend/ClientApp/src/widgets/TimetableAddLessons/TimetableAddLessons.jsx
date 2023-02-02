import React, { useState } from "react";

export function AddLessonsCourse (props) {

    const checkedCurse = "container__block__selected-kurs";
    const unCheckedCurse = "container__block";

    const [style, setStyle] = useState(unCheckedCurse);

    //TODO(Denis): использовать хук useEffect
    

    return(
        <>
        
        <div className={style}>
            <span>{props.title}</span>
        </div>
        

                {/* 
                
                Выбранный курс
                <div className="container__block__selected-kurs">
                <span>1 курс</span>
                </div>
                
                Галочка напротив курса
                <div className="container__block">
                <span>3 курс</span>
                <div className="container__block__completed-icon">
                <i className="icon-fi-rr-check" />
                </div>
                </div> 
                
                */}
        </>
    );
}

export function AddLessonsSpeciality (props) {
    return(
            <div className="faculty__block">
                <div className="faculty__block__span">
                    <span>{props.codeSpeciality}</span> <br />
                    <span>{props.speciality}</span>
                </div>
            </div>
    );
}

export function AddLessonsGroup (props) {
    return(
        <div className="container__block">
            <span>1223</span>
        </div>
    );
}