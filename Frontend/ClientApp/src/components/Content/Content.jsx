import React from 'react'
import './scss/Content.scss'

export default class Content extends React.Component {
    render() {
        return(
            <div className="content">
                { this.props.children }
            </div>
        )
    }
}