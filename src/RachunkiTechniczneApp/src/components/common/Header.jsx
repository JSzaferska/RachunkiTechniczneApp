import {Link} from "react-router-dom";

const Header = () => {
    return (
        <nav>
            <ul>
                <li><Link to="/">Strona główna</Link></li>
                <li><Link to="/addPhoto">Dodaj zdjęcie</Link></li>
            </ul>
        </nav>
    );
};

export default Header;
