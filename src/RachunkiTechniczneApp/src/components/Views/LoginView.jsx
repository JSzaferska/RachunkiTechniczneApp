import React, {useState} from "react";
import {isAdmin, login} from "../../api/index.js";
import {useNavigate} from "react-router-dom";

const LoginView = () => {
    const [data, setData] = useState({});
    const navigate = useNavigate();

    const handleChange = (e) => {
        const { name, value } = e.target;
        setData({
            ...data,
            [name]: value,
        });
    };

    const onLoginSuccess = () => {
        if (isAdmin()) {
            navigate("/admin");
        } else {
            navigate("/report");
        }
    }

    const onLoginFail = () => {
        alert("Nie udało się zalogować");
    }

    const onSubmit = (e) => {
        e.preventDefault();
        login(data.username, data.password, onLoginSuccess, onLoginFail);
    }


    return (
        <div id="panel">
            <form onSubmit={onSubmit}>
                <label htmlFor="username">Nazwa użytkownika:</label>
                <input type="text" id="username" name="username" onChange={handleChange} />
                <label htmlFor="password">Hasło:</label>
                <input type="password" id="password" name="password" onChange={handleChange} />
                <div id="lower">
                    <input type="submit" value="Login" />
                </div>
            </form>
        </div>
    );

}

export default LoginView;
