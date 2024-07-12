import React from "react";
import {getContractsList} from "../../../api/index.js";

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
        getContractsList(this.parseContracts);
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
                        <th>Kontrakt</th>
                        <th>Kod produktu</th>
                        <th>Waluta</th>
                        <th>Saldo</th>
                        <th>Czy saldo się zgadza?</th>
                        <th>Saldo prawidłowe</th>
                        <th>Uwagi</th>
                    </tr>
                    </thead>
                    <tbody>
                    {this.state.contracts.map(contract => (
                        <tr>
                            <th>{this.formatDate(contract.date)}</th>
                            <th>{contract.contract}</th>
                            <th>{contract.productCode}</th>
                            <th>{contract.currency}</th>
                            <th>{contract.balance}</th>
                        </tr>
                    ))}
                    </tbody>
                </table>
                <form>
                    <label htmlFor="select">Pole select</label>
                    <select id="select">
                        <option>Tak</option>
                        <option>Nie</option>
                    </select>
                    <label htmlFor="number">Saldo prawidłowe</label>
                    <input type="number" id="number"/>
                    <label htmlFor="text">Uwagi</label>
                    <textarea id="text"></textarea>
                </form>
                {JSON.stringify(this.state.contracts)}
            </>
        );
    }
}

export default ReportView;
