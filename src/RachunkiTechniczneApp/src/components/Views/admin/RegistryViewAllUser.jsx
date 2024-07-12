import React from "react";
import {getUsersRegistryListAdmin} from "../../../api/index.js";

class RegistryViewAllUser extends React.Component {

    state = {
        users: [],
    };

    parseUsers = (data) => {
        console.log(data);
        this.setState(prevState => {
            return {
                users: data
            }
        });
    }

    componentDidMount() {
        getUsersRegistryListAdmin(this.parseUsers);
    }

    formatDate(string) {
        var options = {
            year: 'numeric',
            month: 'long',
            day: 'numeric',
        };
        return new Date(string).toLocaleDateString([], options);
    }

    render() {
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
                        {this.state.users.map((user, index) => (
                            <tr>
                                <td>{index}</td>
                                <td>{user.owner}</td>
                                <td>{user.login}</td>
                                <td>{user.isAdmin ? "Admin" : "Użyszkodnik"}</td>
                                <button>Edytuj</button>
                                <button>Usuń</button>
                            </tr>
                        ))}
                        </tbody>
                    </table>

                    <button>Dodaj nowego właściciela</button>

                </main>
            </>
        );
    }
}

export default RegistryViewAllUser;
