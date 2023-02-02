import { UserContext } from "@Contexts/User"
import { useEffect } from "react";
import { useContext } from "react";

/**
 * Компонент отвечет за переключение слоёв под 
 * конкретную рольпользователя
*/
export default function Layout(props) {
    const target = props.target;
    const layout = props.layout;

    const { role } = useContext(UserContext);

    return (
        (target === role) ? (layout) : null
    );

}