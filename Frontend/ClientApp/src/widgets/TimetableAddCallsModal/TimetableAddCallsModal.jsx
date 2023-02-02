import React from "react";
import "./scss/style.scss";

export function TimetableAddCallsModal ({active, setActive}) {
    return(
        <div className={active ? "modal active" : "modal"} onClick={() => setActive(false)}>
            <div className={active ? "modal__content active" : "modal__content"} onClick={e => e.stopPropagation()} >
                
            </div>
        </div>
    );
}