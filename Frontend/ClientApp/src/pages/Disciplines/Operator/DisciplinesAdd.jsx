import React, { useState } from 'react'
import "../scss/DisciplinesAdd.scss"

export function DisciplinesAdd (props){
    const [inputFields, setInputfields] = useState([{ name: '', description: '' }])
    let enableFirstElement = false;

    const handleChangeInput = (index, event) => {
        const values = [...inputFields];
        values[index][event.target.name] = event.target.value;
        setInputfields(values);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log("InputFields", inputFields);
    }

    const handleAddFields = () => {
        setInputfields([...inputFields, { name: '', description: ''}])
    }

    const handleRemoveFields = (index) => {
        if (index !== 0) {
            enableFirstElement = true;
            const values = [...inputFields];
            values.splice(index, 1);
            setInputfields(values)
        } else {
            enableFirstElement = false;
        }
    }

    return(
        <>
            <h1 className='title-h1'>Добавление дисциплины</h1>
            <div>
                { inputFields.map((inputFields, index) => (
                    <div key={index} onSubmit={handleSubmit}>
                        <input 
                            className='text-field__input' 
                            name="name" 
                            type="text" 
                            value={inputFields.name} 
                            onChange={event => handleChangeInput(index, event)}/>

                        <input 
                            className='text-field__input' 
                            name="description" 
                            type="text" 
                            value={inputFields.description} 
                            onChange={event => handleChangeInput(index, event)}/>
                        
                        <button 
                            disabled={enableFirstElement} 
                            className='c-button c-button__remove' 
                            type="submit" 
                            onClick={() => handleRemoveFields(index)}>
                        Удалить</button>

                        <button 
                            className='c-button c-button__add' 
                            type="submit" 
                            onClick={() => handleAddFields()}>
                        Добавить</button>
                    </div>
                ))}
                <button className='c-button c-button__send' onClick={handleSubmit}>Отправить</button>
            </div>
        </>
    );
}