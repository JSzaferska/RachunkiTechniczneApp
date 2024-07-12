import React from "react";
import {getContractsList} from "../../../api/index.js";

class ChoiceView extends React.Component {

    render() {
        return (
            <>
                <h1>Wybierz moduł:</h1>
                <button>Rejestr rachunków</button>
                <button>Raport dla rachunków</button>
            </>
        );
    }
}
export default ChoiceView;
