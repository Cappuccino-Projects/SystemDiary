import React from 'react'
import './scss/Container.scss'

export default class Container extends React.Component {
    render() {
        return (
            <div className='container'>
                {this.props.children}
            </div>
        )
    }
}