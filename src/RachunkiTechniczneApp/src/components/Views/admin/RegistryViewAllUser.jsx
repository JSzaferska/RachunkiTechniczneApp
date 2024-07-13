import React, {useEffect, useState} from "react";
import {getUsersRegistryListAdmin, removeUser} from "../../../api/index.js";
import {useNavigate} from "react-router-dom";

const RegistryViewAllUser = () => {
    const [users, setUsers] = useState([]);
    const navigate = useNavigate();

    const parseUsers = (data) => {
        console.log(data);
        setUsers(data);
    }

    useEffect(() => {
        return getUsersRegistryListAdmin(parseUsers);
    }, []);

    const onRemove = (id, name) => {
      if (confirm("Czy na pewno chcesz usunąć użytkownika " + name)) {
          removeUser(id);
          navigate("/admin/users");
      }
    };

    return (
        <>
            <head>
            </head>
            <main>
                <table>
                    <caption>Rejestr właścicieli</caption>
                    <thead>
                    <tr>
                        <th>Indeks</th>
                        <th>Właściciel</th>
                        <th>Login</th>
                        <th>Rola</th>
                        <th></th>
                        <th></th>
                    </tr>
                    </thead>
                    <tbody>
                    {users.map((user) => (
                        <tr>
                            <td>{user.userId}</td>
                            <td>{user.owner}</td>
                            <td>{user.login}</td>
                            <td>{user.isAdmin ? "Admin" : "Użyszkodnik"}</td>
                            <td><button onClick={() => { navigate("edit", { state: {id: user.userId}}) }}>Edytuj</button></td>
                            <td><button onClick={() => { onRemove(user.userId, user.owner)}}>Usuń</button></td>
                        </tr>
                    ))}
                    </tbody>
                </table>

                <button onClick={() => navigate("add")}>Dodaj nowego właściciela</button>

            </main>
        </>
    );
}

export default RegistryViewAllUser;
