import React from "react";
import {getContractsListAdmin} from "../../../api/index.js";

class ReportView extends React.Component {
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
        getContractsListAdmin(this.parseContracts);
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
                <table>
                    <thead>
                    <tr>
                        <th>Data raportu</th>
                        <th>Właściciel</th>
                        <th>Kontrakt</th>
                        <th>Kod produktu</th>
                        <th>Konto</th>
                        <th>Waluta</th>
                        <th>Saldo</th>
                        <th>Czy saldo się zgadza?</th>
                        <th>Saldo prawidłowe</th>
                        <th>Uwagi</th>
                        {/* Te trzy ostatnie to wczytanie zmian, których dokonali userzy*/}
                    </tr>
                    </thead>
                    <tbody>
                    {this.state.contracts.map((contract) => (
                        <tr>
                            <td>{this.formatDate(contract.date)}</td>
                            <td>{contract.owner}</td>
                            <td>{contract.contract}</td>
                            <td>{contract.productCode}</td>
                            <td>{contract.account}{contract.subAccount}</td>
                            <td>{contract.currency}</td>
                            <td>{contract.balance}</td>
                            <td>{contract.isCorrect}</td>
                            <td>{contract.correctBalance}</td>
                            <td>{contract.comment}</td>
                        </tr>
                    ))}
                    </tbody>
                </table>

            </>
        );
    }
}
export default ReportView;
