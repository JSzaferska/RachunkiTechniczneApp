import React, {useState} from "react";
import {addAnswer, addUser} from "../../../api/index.js";
import {useLocation, useNavigate} from "react-router-dom";

const AddAnswer = () => {
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

    const handleAddButton = async (e, data) => {
        e.preventDefault();
        console.log(data);
        var object = {
            ContractId: id,
            isCorrect: data.selectiscorrect === "Tak" ? 1 : (data.selectiscorrect === "Nie" ? 2 : 0),
            correctBalance: data.numbercorrect,
            comment: data.textcomment
        };
        const res = await addAnswer(object);
        console.log(res);
        navigate("/report");
    };

    return (
        <>
            <head>
            </head>
            <main>
                <form onSubmit={(e) => handleAddButton(e, data)}>

                    <label htmlFor="select">Pole select</label>
                    <select id="select" name="selectiscorrect" onChange={handleChange}>
                        <option></option>
                        <option>Tak</option>
                        <option>Nie</option>
                    </select>
                    <label htmlFor="number">Saldo prawidłowe</label>
                    <input type="number" id="number" name="numbercorrect" onChange={handleChange}/>
                    <label htmlFor="text">Uwagi</label>
                    <textarea id="text" name="textcomment" onChange={handleChange}></textarea>
                    <button type={"submit"}>Dodaj</button>
                </form>
            </main>
        </>);
}

export default AddAnswer;
