import {useState} from 'react';
import {getPhotos} from "../api";
import PropTypes from "prop-types";

const Search = ({setList}) => {
    const [text, setText] = useState("");

    const submitHandler = (e) => {
        e.preventDefault();
        getPhotos(text, setList);
    }

    return (
        <form onSubmit={submitHandler}>
            <label>
                Opis
                <input type="text" value={text} onChange={(e) => setText(e.target.value)} />
            </label>
            <button>Szukaj</button>
        </form>
    );
};

export default Search;

Search.propTypes = {
    setList: PropTypes.func
};