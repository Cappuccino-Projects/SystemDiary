import React, { useState } from 'react';
import getData from '../../pages/Disciplines/temp'
import './scss/Discipline.scss'

const data = getData();

export function DisciplineEditBlock(props) {
    let component = [];
    for (let i = 0; i < data.length; i++) {
        component.push(<DisciplineAddblock index={i}/>);
    }

    return(
        <>
            <div>{component}</div>
            <button>save</button>
        </>
    );
}

function DisciplineAddblock(props) {
    const [inputFields, setInputfields] = useState([{ id: '', name: '', description: '' }])
    
    const handleChangeInput = (index, event) => {
        const values = [...inputFields];
        values[index][event.target.name] = event.target.value;
        setInputfields(...inputFields, values);
    }

    function handleSubmit (e) {
        e.preventDefault();
        console.log("InputFields", inputFields);
    }
    
    return(
        <div>
            { inputFields.map((inputFields, index) => (
                <div className='discipline-block' key={index} onSubmit={handleSubmit}>
                        <input name="name" type='text' defaultValue={data[props.index].name} onChange={event => handleChangeInput(index, event)}/>
                        <input name="description" type='text' defaultValue={data[props.index].description} onChange={event => handleChangeInput(index, event)}/> 
                        
                </div>   
            ))}
            <button onClick={handleSubmit}>save</button>
        </div>
    );
}
