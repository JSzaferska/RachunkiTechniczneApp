import {useState} from "react";
import Search from "../Search";
import PhotoList from "../PhotoList";

const Main = () => {
    const [list, setList] = useState([]);
    return (
        <>
            <Search setList={setList} />
            <PhotoList list={list} />
        </>
    );
};

export default Main;
