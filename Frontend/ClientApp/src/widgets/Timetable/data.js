export default function getData() {
    return [
        //Расписание на сегодня
        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Расписание на сегодня",
            lessons: [
                 {
                    calls: "",
                    subject: "",
                    teacher: "",
                    cabinet: "" 
                },

                {
                    calls: "12:35 - 13:20 13:25 - 14:10",
                    subject: "Физическая культура",
                    teacher: "Махмадулаев И.Л.",
                    cabinet: "c/p" 
                },

                {
                    calls: "14:20 - 15:05 15:10 - 15:55",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                },

                {
                    calls: "16:00 - 16:45 16:50 - 17:35",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                }   
            ]
        },
        
        //Расписание на завтра
        {
            isTimetable: "isSubj",
            isediting: true,
            title: "Изменение на завтра",
            lessons: [
                {
                    calls: ". . .",
                    subject: "",
                    teacher: ". . .",
                    cabinet: "" 
                },

                {
                    calls: "09:55 - 10:40 10:45 - 11:30",
                    subject: "Математическое моделирование",
                    teacher: "Герасимова А.В.",
                    cabinet: "14 каб." 
                },

                {
                    calls: "11:50 - 12:35 12:40 - 13:25",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                },

                {
                    calls: "13:35 - 14:20 14:25 - 15:10",
                    subject: "Физическая культура",
                    teacher: "Махмадулаев С.А.",
                    cabinet: "c/p" 
                }
            ]
        },

        //Расписание звонков
        {
            isTimetable: "isCall",
            title: "Звонки",
            couple: ["1 пара:", "2 пара:", "3 пара:", "4 пара:", "5 пара:", "6 пара:", "7 пара:"],
            callsMondey: ["08:45 - 09:30 09:35 - 10:20","10:40 - 11:25 11:30 - 12:15","12:35 - 13:20 13:25 - 14:10","14:20 - 15:05 15:10 - 15:55","16:00 - 16:45 16:50 - 17:35","17:40 - 18:25 18:30 - 19:15","19:25 - 20:10 20:15 - 21:00"],
            callsGeneral: ["08:00 - 08:45 08:50 - 09:35","09:45 - 10:20 11:25 - 11:20","12:00 - 12:45 12:50 - 13:25","13:35 - 14:20 14:25 - 15:10","15:20 - 16:05 16:10 - 16:55","17:00 - 17:45 17:50 - 18:35","18:40 - 19:25 19:30 - 20:15"],
            callsSaturday: ["08:00 - 09:20","09:40 - 11:00","11:20 - 12:20","12:30 - 13:30","13:40 - 14:40","14:50 - 15:50","16:00 - 17:00"],
        },

        //Расписание 1 неделя
        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Понедельник",
            lessons: [
                 {
                    calls: ". . .",
                    subject: ". . .",
                    teacher: ". . .",
                    cabinet: "" 
                },

                {
                    calls: "12:35 - 13:20 13:25 - 14:10",
                    subject: "Физическая культура",
                    teacher: "Махмадулаев И.Л.",
                    cabinet: "c/p" 
                },

                {
                    calls: "14:20 - 15:05 15:10 - 15:55",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                },

                {
                    calls: "16:00 - 16:45 16:50 - 17:35",
                    subject: "Основы анализа результатов измерений и ведения технологической документации",
                    teacher: "Махмадулаев И.Л.",
                    cabinet: "15 каб." 
                }                
            ]
        },

        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Вторник",
            lessons: [
                {
                    calls: ". . .",
                    subject: ". . .",
                    teacher: ". . .",
                    cabinet: "" 
                },

               {
                    calls: "11:50 - 12:35 12:40 - 13:25",
                    subject: "Английский язык",
                    teacher: "Яббарова А.В.",
                    cabinet: "44 каб." 
                },

                {
                    calls: "13:35 - 14:20 14:25 - 15:10",
                    subject: "Технология разработки программного обеспечения",
                    teacher: "Казынбаева Р.К.",
                    cabinet: "21 каб." 
                }
            ]
        },

        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Среда",
            lessons: [
                {
                    calls: ". . .",
                    subject: ". . .",
                    teacher: ". . .",
                    cabinet: "" 
                },

                {
                    calls: "09:55 - 10:40 10:45 - 11:30",
                    subject: "Разработка программных модулей",
                    teacher: "Надеждина А.В.",
                    cabinet: "28 каб." 
                },

                {
                    calls: "11:50 - 12:35 12:40 - 13:25",
                    subject: "Разработка программных модулей",
                    teacher: "Надеждина А.В.",
                    cabinet: "28 каб." 
                },

                {
                    calls: "13:35 - 14:20 14:25 - 15:10",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                },

                {
                    calls: "15:20 - 16:05 16:10 - 16:55",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                }
            ]
        },

        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Четверг",
            lessons: [
                {
                    calls: ". . .",
                    subject: ". . .",
                    teacher: ". . .",
                    cabinet: "" 
                },

                {
                    calls: "09:55 - 10:40 10:45 - 11:30",
                    subject: "Поддержка и тестирование программных модулей",
                    teacher: "Романов В.А.",
                    cabinet: "37 каб." 
                },

                {
                    calls: "11:50 - 12:35 12:40 - 13:25",
                    subject: "Поддержка и тестирование программных модулей",
                    teacher: "Романов В.А.",
                    cabinet: "37 каб." 
                },

                {
                    calls: "13:35 - 14:20 14:25 - 15:10",
                    subject: "Математическое моделирование",
                    teacher: "Герасимова А.В.",
                    cabinet: "14 каб." 
                }
            ]
        },

        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Пятница",
            lessons: [
                {
                    calls: "08:00 - 08:45 08:50 - 09:35",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                },

                {
                    calls: "09:55 - 10:40 10:45 - 11:30",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                },

                {
                    calls: "11:50 - 12:35 12:40 - 13:25",
                    subject: "Технология разработки программного обеспечения",
                    teacher: "Казынбаева Р.К.",
                    cabinet: "46 каб." 
                },

                {
                    calls: "13:35 - 14:20 14:25 - 15:10",
                    subject: "Разработка программных модулей",
                    teacher: "Надеждина А.В",
                    cabinet: "28 каб." 
                }
            ]
        },
        
        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Суббота",
            lessons: [
                {
                    calls: "",
                    subject: "День самостоятельной подготовки студентов",
                    teacher: "",
                    cabinet: "" 
                }
            ]
        },

        //Расписание 2 неделя
        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Понедельник",
            lessons: [
                {
                    calls: ". . .",
                    subject: ". . .",
                    teacher: ". . .",
                    cabinet: "" 
                },

                {
                    calls: "10:40 - 11:25 11:30 - 12:15",
                    subject: "Физическая культура",
                    teacher: "Махмадулаев И.Л.",
                    cabinet: "c/p" 
                },

                {
                    calls: "12:35 - 13:20 13:25 - 14:10",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                },

                {
                    calls: "14:20 - 15:05 15:10 - 15:55",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                }
            ]
        },

        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Вторник",
            lessons: [
                {
                    calls: ". . .",
                    subject: ". . .",
                    teacher: ". . .",
                    cabinet: "" 
                },

                {
                    calls: "09:55 - 10:40 10:45 - 11:30",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                },

                {
                    calls: "11:50 - 12:35 12:40 - 13:25",
                    subject: "Английский язык",
                    teacher: "Яббарова А.В.",
                    cabinet: "32/1 каб." 
                },

                {
                    calls: "13:35 - 14:20 14:25 - 15:10",
                    subject: "Технология разработки программного обеспечения",
                    teacher: "Казынбаева Р.И.",
                    cabinet: "21 каб." 
                }
            ]
        },

        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Среда",
            lessons: [
                {
                    calls: ". . .",
                    subject: ". . .",
                    teacher: ". . .",
                    cabinet: "" 
                },

                {
                    calls: "09:55 - 10:40 10:45 - 11:30",
                    subject: "Разработка программных модулей",
                    teacher: "Надеждина А.В.",
                    cabinet: "28 каб." 
                },

                {
                    calls: "11:50 - 12:35 12:40 - 13:25",
                    subject: "Разработка программных модулей",
                    teacher: "Надеждина А.В.",
                    cabinet: "28 каб." 
                },

                {
                    calls: "13:35 - 14:20 14:25 - 15:10",
                    subject: "Разработка мобильных приложений",
                    teacher: "Махмадулаев И.Л.",
                    cabinet: "c/p" 
                },

                {
                    calls: "15:20 - 16:05 16:10 - 16:55",
                    subject: "Математическое моделирование",
                    teacher: "Герасимова А.В.",
                    cabinet: "14 каб." 
                }
            ]
        },

        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Четверг",
            lessons: [
                {
                    calls: ". . .",
                    subject: ". . .",
                    teacher: ". . .",
                    cabinet: "" 
                },

                {
                    calls: "11:50 - 12:35 12:40 - 13:25",
                    subject: "Поддержка и тестирование программных модулей",
                    teacher: "Романов В.А.",
                    cabinet: "37 каб." 
                },

                {
                    calls: "13:35 - 14:20 14:25 - 15:10",
                    subject: "Математические моделирование",
                    teacher: "Герасимова А.В.",
                    cabinet: "23 каб." 
                }
            ]
        },

        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Пятница",
            lessons: [

                {
                    calls: "08:00 - 08:45 08:50 - 09:35",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                },

                {
                    calls: "09:55 - 10:40 10:45 - 11:30",
                    subject: "Разработка мобильных приложений",
                    teacher: "Иванов А.А.",
                    cabinet: "15 каб." 
                },

                {
                    calls: "11:50 - 12:35 12:40 - 13:25",
                    subject: "Технология разработки программного обеспечения",
                    teacher: "Казынбаева Р.И.",
                    cabinet: "46 каб."  
                },


                {
                    calls: "13:35 - 14:20 14:25 - 15:10",
                    subject: "Разработка программных модулей",
                    teacher: "Надеждина А.В.",
                    cabinet: "28 каб."
                }
            ]
        },
        
        {
            isTimetable: "isSubj",
            isediting: false,
            title: "Суббота",
            lessons: [
                {
                    calls: "",
                    subject: "День самостоятельной подготовки студентов",
                    teacher: "",
                    cabinet: "" 
                }
            ]
        },
    ]
}