import React from 'react'
import { UserContext } from '@Contexts/User'
import './scss/Wrapper.scss'

export default class Wrapper extends React.Component {

    static contextType = UserContext;

    render() {
        
        const mode = (this.props.flex === 'column' || 
        this.props.flex === 'undefined' ||
        this.props.flex == null) ? 'column' : 'row';

        return (
            <div className={this.props.theme + ' wrapper wrapper-flex ' + mode}>
                { this.props.children }
            </div>
        )
    }

}