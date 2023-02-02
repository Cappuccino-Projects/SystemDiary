import React from 'react'
import './scss/Headings.scss'

export class H1 extends React.Component {
    render() {
        return(
            <h1 className={ 'title-h1 ' + this.props.className} onClick={ () => this.props.onClick() }>{ this.props.children }</h1>
        )
    }
}

export class H2 extends React.Component {
    render() {
        return(
            <h2 className={ 'title-h2 ' + this.props.className} onClick={ () => this.props.onClick() }>{ this.props.children }</h2>
        )
    }
}

export class H3 extends React.Component {
    render() {
        return(
            <h3 className={ 'title-h3 ' + this.props.className} onClick={ () => this.props.onClick() }>{ this.props.children }</h3>
        )
    }
}

export class H4 extends React.Component {
    render() {
        return(
            <h4 className={ 'title-h4 ' + this.props.className} onClick={ () => this.props.onClick() }>{ this.props.children }</h4>
        )
    }
}

export class H5 extends React.Component {
    render() {
        return(
            <h5 className={ 'title-h5 ' + this.props.className} onClick={ () => this.props.onClick() }>{ this.props.children }</h5>
        )
    }
}

export class H6 extends React.Component {
    render() {
        return(
            <h6 className={ 'title-h6 ' + this.props.className} onClick={ () => this.props.onClick() }>{ this.props.children }</h6>
        )
    }
}