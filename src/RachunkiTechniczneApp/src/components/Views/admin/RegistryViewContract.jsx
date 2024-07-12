import React from "react";
import {getContractsRegistryListAdmin} from "../../../api/index.js";

class RegistryViewContract extends React.Component {

    state = {
        contracts: [],
    };

    parseContracts = (data) => {
        console.log(data);
        this.setState(prevState => {
            return {
                contracts: data
            }
        });
    }

    componentDidMount() {
        getContractsRegistryListAdmin(this.parseContracts);
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
                        <caption>Rejestr rachunków technicznych</caption>
                        <thead>
                        <tr>
                            <th>Indeks</th>
                            <th>Właściciel</th>
                            <th>Kontrakt</th>
                            <th>Data otwarcia</th>
                            <th>Kod produktu</th>
                            <th>Waluta</th>
                            <th>Konto</th>
                        </tr>
                        </thead>
                        <tbody>
                        {this.state.contracts.map((contract, index) => (
                            <tr>
                                <td>{index}</td>
                                <td>{contract.owner}</td>
                                <td>{contract.contract}</td>
                                <td>{this.formatDate(contract.openingDate)}</td>
                                <td>{contract.productCode}</td>
                                <td>{contract.currency}</td>
                                <td>{contract.account}{contract.subAccount}</td>
                            </tr>
                        ))}
                        </tbody>
                    </table>
                    <button>Filtruj tabelę</button>

                    <button>Dodaj nowy rachunek</button>
                    <button>Edytuj rachunek</button>
                    <button>Usuń rachunek</button>s
                </main>
            </>
        );
    }
}

export default RegistryViewContract;
