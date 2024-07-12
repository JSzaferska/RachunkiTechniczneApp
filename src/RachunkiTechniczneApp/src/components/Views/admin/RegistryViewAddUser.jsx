import React, {useState} from "react";
import {addUser} from "../../../api/index.js";

const RegistryViewAddUser = () => {
    const [data, setData] = useState({
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setData({
            ...data,
            [name]: value,
        });
    };

    const handleAddButton = async (e, data) => {
        e.preventDefault();
        console.log(data);
        var object = {
            userId: 0,
            owner: data.textOwner,
            login: data.textLogin,
            password: data.textPassword,
            isAdmin: data.selectRole === "Admin"
        };
        const res = await addUser(object);
        console.log(res);
    };

    return (
        <>
            <head>
            </head>
            <main>
                <form onSubmit={(e) => handleAddButton(e, data)}>
                    <div>
                        <label htmlFor="text">Imię i nazwisko nowego użytkownika</label>
                        <input type="text" name="textOwner" value={data.textOwner} onChange={handleChange} required/>
                    </div>
                    <div>
                        <label htmlFor="text">Login</label>
                        <input type="text" name="textLogin" value={data.textLogin} onChange={handleChange} required/>
                    </div>
                    <div>
                        <label htmlFor="text">Hasło</label>
                        <input type="text" name="textPassword" value={data.textPassword} onChange={handleChange}
                               required/>
                    </div>
                    <div>
                        <label htmlFor="select">Rola</label>
                        <select name="selectRole" value={data.textRole} onChange={handleChange} required>
                            <option></option>
                            <option>Użyszkodnik</option>
                            <option>Admin</option>
                        </select>
                    </div>
                    <button type={"submit"}>Dodaj</button>
                </form>
            </main>
        </>);
}

export default RegistryViewAddUser;
