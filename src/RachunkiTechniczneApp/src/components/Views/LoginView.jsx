import React from "react";
import {getContractsList} from "../../api/index.js";

class LoginView extends React.Component {

    render() {
        return (
            <div id="panel">
                <form>
                    <label htmlFor="username">Nazwa użytkownika:</label>
                    <input type="text" id="username" name="username"/>
                    <label htmlFor="password">Hasło:</label>
                    <input type="password" id="password" name="password"/>
                    <div id="lower">
                        <input type="submit" value="Login"/>
                    </div>
                </form>
            </div>
        );
    }
}

export default LoginView;
