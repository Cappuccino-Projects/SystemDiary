import React, { useState } from "react"
import { BrowserRouter as Router } from "react-router-dom"
import { UserContext } from "@Contexts/User"
import ThemeWrapper from "@Components/ThemeWrapper"
import AuthWrapper from "@Components/AuthWrapper"
import UnAuthWrapper from "@Components/UnAuthWrapper"
import Layout from '@Components/Layout'
import Student from "@Layout/Student"
import Administrator from "@Layout/Administrator"
import Operator from '@Layout/Operator'
import { Provider } from "react-redux"
import { store } from "@Reducers/stores/store"
import "@Styles/main.scss"
import Public from "@Layout/Public"
import { useEffect } from "react"

export default function App() {

  //TODO(letnull19a) поместить это всё в один объект
  const [name, setName] = useState(null)
  const [surname, setSurname] = useState(null)
  const [role, setRole] = useState(null)
  const [state, setState] = useState(null)
  const [isAuth, setIsAuth] = useState(true)
  const [email, setEmail] = useState(null)
  const [phone, setPhone] = useState(null)
  const [birth, setBirth] = useState(null)
  const [aboutMe, setAboutMe] = useState(null)

  const data = JSON.parse(localStorage.getItem('userData'));
  
  useEffect(() => {

    if (data !== null && data !== undefined) {
      setIsAuth(data.access_token !== null && data.access_token !== undefined);
      setName(data.user_name);
      setSurname(data.user_surname);
      setRole(data.user_role);
      setEmail("alexvolkovdd@googlemail.com");
      setPhone("+79998883344");
      setBirth("07.03.2004");
    }
  }, []);

  return (
    <Router>
      <UserContext.Provider value={{
        setName,
        name,
        setSurname,
        surname,
        setRole,
        role,
        setIsAuth,
        isAuth,
        email,
        setEmail,
        phone,
        setPhone,
        birth,
        setBirth
      }}>
        <Provider store={store}>
          <ThemeWrapper>
            <AuthWrapper>
              <Layout
                target={"Администратор"}
                layout={<Administrator />} />
              <Layout
                target={"Студент"}
                layout={<Student />} />
              <Layout
                traget={"Оператор"}
                layout={<Operator />} />
            </AuthWrapper>
            <UnAuthWrapper>
              <Layout
              target={null}
              layout={<Public />}/>
            </UnAuthWrapper>
          </ThemeWrapper>
        </Provider>
      </UserContext.Provider>
    </Router>
  );
}
