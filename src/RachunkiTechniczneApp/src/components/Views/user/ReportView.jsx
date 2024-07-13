import React, {useEffect, useState} from "react";
import {getContractsList, getContractsRegistryListAdmin, loggout} from "../../../api/index.js";
import {useNavigate} from "react-router-dom";

const ReportView = () => {
    const [contracts, setContracts] = useState([]);

    const parseContracts = (data) => {
        console.log(data);
        setContracts(data);
    }

    const navigate = useNavigate();

    useEffect(() => {
        return  getContractsList(parseContracts);
    }, []);


    const formatDate = (string) => {
        var options = {
            year: 'numeric',
            month: 'long',
            day: 'numeric',
        };
        return new Date(string).toLocaleDateString([], options);
    }


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
                        <th></th>
                    </tr>
                    </thead>
                    <tbody>
                    {contracts.map(contract => (
                        <tr>
                            <th>{formatDate(contract.date)}</th>
                            <th>{contract.contract}</th>
                            <th>{contract.productCode}</th>
                            <th>{contract.currency}</th>
                            <th>{contract.balance}</th>
                            <th>{contract.isCorrect}</th>
                            <th>{contract.correctBalance}</th>
                            <th>{contract.comment}</th>
                            <th>
                                <td>
                                    <button onClick={() => {
                                        navigate("answer", {state: {id: contract.contractId}})
                                    }}>Odpowiedz
                                    </button>
                                </td>
                            </th>
                        </tr>
                    ))}
                    </tbody>
                </table>
                <button onClick={() => loggout()}>Wyloguj</button>
            </>
        );
    }


export default ReportView;
