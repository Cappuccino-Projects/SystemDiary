import React, { useState } from "react";
import "./scss/style.scss";
import getData from "./data";
import { H1 } from '@Components/Headings'
import { useHistory } from "react-router-dom";

const data = getData();

export function TimetableAddCallsHeader(props) {
    return (
      <div className="timetableaddcallsheader">
            <AddCallsHeader indexPage={props.indexPage}/>
      </div>
    );
};

/////////////////  Шапка /////////////////

const AddCallsHeader = (props) => {
    const history = useHistory();
    const [Step, setStep] = useState(0);

    let activeStepFirst;
    let activeStepSecond;
    let activeStepThird;

    if (data[props.indexPage].step === 1){
        activeStepFirst = 'styleActivePage';
    }
    if (data[props.indexPage].step === 2){
        activeStepFirst = 'styleActivePage';
        activeStepSecond = 'styleActivePage';
    }
    if (data[props.indexPage].step === 3){
        activeStepFirst = 'styleActivePage';
        activeStepSecond = 'styleActivePage';
        activeStepThird = 'styleActivePage';
    }

    if(Step === 1){
        if(data[props.indexPage].step === 1){
            history.push("/timetable-get-start")
        }
        if(data[props.indexPage].step === 2){
            history.push("/timetable-add-calls")
        }
        if(data[props.indexPage].step === 3){
            history.push("/timetable-add-lessons")
        }
    }
    if(Step === 2){
        if(data[props.indexPage].step === 1){
            history.push("/timetable-add-lessons")
        }
        if(data[props.indexPage].step === 2){
            history.push("/timetable-add-editings")
        }
        if(data[props.indexPage].step === 3){
            history.push("/timetable")
        }
    }

    let backButton = " Назад";
    let nextButton = "Далее ";

    /////////////////  Шапка /////////////////

    return(
        <div>
            <div className='timetable-add-calls__header'>
                <div className='timetable-add-calls__header__header-inner'>
                    <div className='timetable-add-calls__header__title'>
                        <H1>{data[props.indexPage].title}</H1>
                        <div className='title-span-style'>
                            <span>{data[props.indexPage].subtitle}</span>
                        </div>
                    </div>
                    <div className='timetable-add-calls__header__steps'>
                        {/* Кнопки назад и вперёд */}
                        <div className='timetable-step-buttons'>
                                <div className="buttons-style-hover" onClick={() => setStep(1)}><i className="icon-fi-rr-angle-double-left style-icon" ></i>{ backButton }</div>
                                <div className="buttons-style-hover" onClick={() => setStep(2)}>{ nextButton }<i className="icon-fi-rr-angle-double-right style-icon" ></i></div>
                        </div>
                        {/* Маркеры шагов */}
                        <div className='timetable-step-marker'>
                            {/* 1 */}
                            <div className={'timetable-step-marker__container ' + activeStepFirst}>
                                <span>1</span>    
                            </div>
                            {/* - */}
                            <div className='timetable-step-marker__line'>
                                <div className={'timetable-step-marker__line__container ' + activeStepSecond}></div>
                            </div>
                            {/* 2 */}
                            <div className={'timetable-step-marker__container ' + activeStepSecond}>
                                <span>2</span>  
                            </div>
                            {/* - */}
                            <div className='timetable-step-marker__line'>
                                <div className={'timetable-step-marker__line__container ' + activeStepThird}></div>
                            </div>
                            {/* 3 */}
                            <div className={'timetable-step-marker__container ' + activeStepThird}>
                                <span>3</span>  
                            </div>
                        </div>
                    </div>
                </div>
          </div>
        </div>
    );
}