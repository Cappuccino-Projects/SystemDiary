import React, { useState, useEffect } from "react"
import './scss/Tabs.scss'

export function Tab(props) {

    const { className } = props;

    return (
        <div className={"panel " + className}>
            {props.children}
        </div>
    )
}

export function Tabs(props) {

    const [currentTab, setCurrentTab] = useState(0);
    const [titles, setTitles] = useState([])
    const [panels, setPanels] = useState([])
    const { children, className } = props;

    useEffect(() => {

        setCurrentTab(currentTab === undefined ? 0 : currentTab);

        React.Children.forEach(children, (element) => {
            const { title, children } = element.props

            setTitles(prevState => [...prevState, title]);
            setPanels(prevState => [...prevState, children]);

        })

    }, [])

    return (
        <div className={'tabs ' + className}>
            <div className="tabs__head">
                {titles.map((title, index) =>
                    <div
                        className={"tabs__head__title " + ((index === currentTab) ? 'active_tab' : '')}
                        onClick={() => setCurrentTab(index)}
                    >
                        {title}
                    </div>
                )}
            </div>
            <div className="tabs__body">
                <div className="tabContent">
                    {panels[currentTab]}
                </div>
            </div>
        </div>
    )

}