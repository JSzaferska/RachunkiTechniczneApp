import React from "react";
import {useNavigate} from "react-router-dom";
import {loggout} from "../../../api/index.js";

const ChoiceView = () => {
    const navigate = useNavigate();

    return (
        <>
            <h1>Wybierz moduł:</h1>
            <button onClick={() => navigate("registry")}>Rejestr rachunków</button>
            <button onClick={() => navigate("report")}>Raport dla rachunków</button>
            <button onClick={() => navigate("users")}>Użytkownicy</button>
            <button onClick={() => loggout()}>Wyloguj</button>
        </>
    );
}
export default ChoiceView;
