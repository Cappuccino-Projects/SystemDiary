import React from "react";
import Container from "@Components/Container";
import "./scss/Header.scss";

export default function Header(props) {

    return (
        <div className="header">
            <Container>
                <div className="header-inner">
                    <div className="left-side">{props.left}</div>
                    <div className="center">{props.center}</div>
                    <div className="right-side">{props.right}</div>
                </div>
            </Container>
        </div>
  );
}
