import React from 'react'
import './scss/HotTaskCard.scss'
import { H6 } from '@Components/Headings'

export default class HotTaskCard extends React.Component {
    render() {
        return(
            <div className={ 'hot-task-card ' + this.props.theme }>
                <div className='hot-task-card__data'>
                    <div className='hot-task-card__data__title'>
                        <H6>{ this.props.title }</H6>
                    </div>
                    <div className='hot-task-card__data__description'>
                        <p>{ this.props.description }</p>
                    </div>
                    <div className='hot-task-card__data__deadline'>
                        <p>{ this.props.deadline }</p>
                    </div>
                </div>
                <div className='hot-task-card__image'>

                </div>
            </div>
        )
    }
}