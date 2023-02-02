import React from 'react'
import { UserContext, userContext } from '@Contexts/User'
import HotTaskCard from '@Widgets/HotTaskCard'
import { H1, H2 } from '@Components/Headings'
import Calendar from '@Widgets/Calendar'
import { v4 as uuidv4 } from 'uuid';
import './scss/Main.scss'

export default class Main extends React.Component {

    static contextType = UserContext;

    constructor(props) {
        super(props);

        this.state = {
            hour: null,
            userData: userContext
        }

        this.setState({
            hour: this.state.hour,
            userData: this.context
        });
    }

    componentDidMount() {
        this.getHour();
    }

    getHour() {
        this.setState({
            hour: new Date().getHours()
        });
    }

    render() {

        const { hour } = this.state;

        const welcomeMessage =
            (hour >= 6 && hour < 12) ? 'Доброе утро' :
                (hour >= 12 && hour < 18) ? 'Добрый день' :
                    (hour >= 18) ? 'Добрый вечер' : 'Доброй ночи';

        const data = {
            title: 'Разработка программных модулей',
            description: 'Тестирование. “Разновидности математических моделей”',
            deadline: 'Завершается сегодня, 12:00'
        }

        return (
            <div className='main-page'>
                <H1>{welcomeMessage}, {this.state.userData.name}</H1>

                <div className='main-page__columns'>
                    <div className='main-page__columns__tasks'>
                        <div className='main-page__columns__tasks__title'>
                            <H2 className='page-title'>Горящий дедлайн</H2>
                        </div>
                        <div className='card-list'>
                            <HotTaskCard key={ uuidv4() } {...data} />
                            <HotTaskCard key={ uuidv4() } {...data} />
                            <HotTaskCard key={ uuidv4() } {...data} />
                            <HotTaskCard key={ uuidv4() } {...data} />
                            <HotTaskCard key={ uuidv4() } {...data} />
                            <HotTaskCard key={ uuidv4() } {...data} />
                        </div>
                    </div>
                    <div className='main-page__columns__calendar'>
                        <Calendar/>
                    </div>
                </div>
            </div>

        )
    }
}