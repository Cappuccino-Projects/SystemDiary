import { useState } from "react";
import "./scss/MenuButton.scss";
 
/**
 * MenuButton - кнопка переключатель меню в мобильном виде
 *
 * @param {any} props.OnClick - пропс отвечающий за клик на кнопку
 */
export default function MenuButton(props) {
  const [isOpen, setIsOpen] = useState(false);

  const onClickEvent = () => {
    setIsOpen(!isOpen);
    if (props.OnClick === null || props.OnClick === undefined)
        return;
    
    props.OnClick();
  };

  return (
    <button 
      className="menu_button-action-mobile-button" 
      onClick={() => onClickEvent()}>
      <i className="icon-fi-rr-menu-burger"></i>
    </button>
  );
}
