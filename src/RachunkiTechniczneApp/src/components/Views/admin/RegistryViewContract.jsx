import React, {useEffect, useState} from "react";
import {
    getContractsRegistryListAdmin,
    getUsersRegistryListAdmin,
    removeRegistry,
    removeUser
} from "../../../api/index.js";
import {useNavigate} from "react-router-dom";

const RegistryViewContract = () => {
    const navigate = useNavigate();
    const [contracts, setContracts] = useState([]);

    const parseContracts = (data) => {
        console.log(data);
        setContracts(data);
    }

    useEffect(() => {
        return getContractsRegistryListAdmin(parseContracts);
    }, []);

    const onRemove = (id, contract) => {
        if (confirm("Czy na pewno chcesz usunąć kontrakt " + contract)) {
            removeRegistry(id);
            navigate("/admin/registry");
        }
    };

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
                        <th></th>
                        <th></th>
                    </tr>
                    </thead>
                    <tbody>
                    {contracts.map((contract, index) => (
                        <tr>
                            <td>{contract.contractId}</td>
                            <td>{contract.owner}</td>
                            <td>{contract.contract}</td>
                            <td>{formatDate(contract.openingDate)}</td>
                            <td>{contract.productCode}</td>
                            <td>{contract.currency}</td>
                            <td>{contract.account}{contract.subAccount}</td>
                            <button onClick={() => { navigate("edit", { state: {id: contract.contractId}}) }}>Edytuj</button>
                            <button onClick={() => { onRemove(contract.contractId, contract.contract)}}>Usuń</button>
                        </tr>
                    ))}
                    </tbody>
                </table>
                <button>Filtruj tabelę</button>

                <button onClick={() => { navigate("add") }}>Dodaj nowy rachunek</button>

            </main>
        </>
    );
}

export default RegistryViewContract;
