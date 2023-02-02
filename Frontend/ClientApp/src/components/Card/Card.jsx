import './scss/Card.scss'
import React, { useEffect, useState } from 'react';

export function Card(props) {

    const { children, className } = props;

    const [head, setHead] = useState(null)
    const [body, setBody] = useState(null)
    const [footer, setFooter] = useState(null)

    useEffect(() => {

        React.Children.forEach(children, (child) => {

            switch (child.type.name) {

                case 'CardHead':
                    setHead(child)
                    break;
                case 'CardBody':
                    setBody(child)
                    break;
                case 'CardFooter':
                    setFooter(child)
                    break;
            }
        })

    }, []);

    return (
        <div className={'card ' + className}>
            <div className='card__head'>
                {head ?? null}
            </div>
            <div className='card__body'>
                {body ?? null}
            </div>
            <div className='card__foot'>
                {footer ?? null}
            </div>
        </div>
    )
}

export function CardHead(props) {

    const { children, className } = props

    return (
        <div className={'card__head__content' + className}>
            {children}
        </div>
    )
}

export function CardBody(props) {
    const { children, className } = props

    return (
        <div className={'card__body__content' + className}>
            {children}
        </div>
    )
}

export function CardFooter(props) {

    const { children, className } = props

    return (
        <div className={'card__footer__content' + className}>
            {children}
        </div>
    )
}