import {React, useEffect, useState} from "react";
import {addRegistry, getRegistry, getUser} from "../../../api/index.js";
import {useLocation, useNavigate} from "react-router-dom";

const RegistryViewEditContract = () => {
    const [data, setData] = useState({
    });

    const navigate = useNavigate();
    const { id } = useLocation().state;

    const handleChange = (e) => {
        const { name, value } = e.target;
        setData({
            ...data,
            [name]: value,
        });
    };

    const onLoadData = (contract) => {
        setData(
            {
                textOwner: contract.owner,
                textContract: contract.contract,
                textOpeningDate: contract.openingDate,
                textProductCode: contract.productCode,
                textCurrency: contract.currency,
                textAccount: contract.account,
                textSubaccount: contract.subAccount
            }
        )
    };

    useEffect(() => {
        console.log(id);
        return getRegistry(id, onLoadData);
    }, []);

    const handleAddButton = async (e, data) => {
        e.preventDefault();
        console.log(data);
        var object = {
            owner: data.textOwner,
            contract: data.textContract,
            openingDate: data.textOpeningDate,
            productCode: data.textProductCode,
            currency: data.textCurrency,
            account: data.textAccount,
            subAccount: data.textSubaccount
        };
        const res = await addRegistry(object);
        console.log(res);
        navigate("/admin/registry");
    };

    return (
        <>
            <head>
            </head>
            <main>
                <form onSubmit={(e) => handleAddButton(e, data)}>
                    <div>
                        <label htmlFor="text">Właściciel</label>
                        <input type="text" name="textOwner" value={data.textOwner} onChange={handleChange} required/>
                    </div>
                    <div>
                        <label htmlFor="text">Kontrakt</label>
                        <input type="text" name="textContract" value={data.textContract} onChange={handleChange}
                               required/>
                    </div>
                    <div>
                        <label htmlFor="text">Data otwarcia</label>
                        <input type="text" name="textOpeningDate" value={data.textOpeningDate} onChange={handleChange}
                               required/>
                    </div>
                    <div>
                        <label htmlFor="text">Kod produktu</label>
                        <input type="text" name="textProductCode" value={data.textProductCode} onChange={handleChange}
                               required/>
                    </div>
                    <div>
                        <label htmlFor="text">Waluta</label>
                        <input type="text" name="textCurrency" value={data.textCurrency} onChange={handleChange}
                               required/>
                    </div>
                    <div>
                        <label htmlFor="text">Konto</label>
                        <input type="text" name="textAccount" value={data.textAccount} onChange={handleChange}
                               required/>
                    </div>
                    <div>
                        <label htmlFor="text">Subkonto</label>
                        <input type="text" name="textSubaccount" value={data.textSubaccount} onChange={handleChange}
                               required/>
                    </div>
                    <button type={"submit"}>Edytuj</button>
                </form>
            </main>
        </>);
}

export default RegistryViewEditContract;
